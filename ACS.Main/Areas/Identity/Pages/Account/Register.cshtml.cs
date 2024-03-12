using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using ACS.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using ACS.Core.Entities.Bases;
using System.Net.Http;
using Newtonsoft.Json;
using ACS.Web.Providers;
using System.Net.Http.Headers;
using System.Net.Mail;

namespace ACS.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private static Random random = new Random();
        private readonly SignInManager<BaseUser> _signInManager;
        private readonly UserManager<BaseUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<BaseUser> userManager,
            SignInManager<BaseUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "أدخل رقم الملف")]
            [DataType(DataType.CreditCard)]
            [Display(Name = "رقم الملف")]
            public string FileNumber { get; set; }

            //[Required(ErrorMessage = "أدخل البريد الإلكتروني")]
            //[EmailAddress]
            //[Display(Name = "البريد الإلكتروني")]
            //public string Email { get; set; }

            [Required(ErrorMessage = "أدخل كلمة المرور")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "كلمة المرور")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "تأكيد كلمة المرور")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        private class tempEmployee
        {
            [Key]
            public string EmpFileNo { get; set; }
            public string EmpName { get; set; }
            public string EmpPhone { get; set; }
            public string EmpEmail { get; set; }
            public string EmpResponsibilitycode { get; set; }
            public string PerRespCodeNoName { get; set; }
            public int JobCatId { get; set; }
            public string JobStatus { get; set; }
            public string RespCodeId { get; set; }
            public int DesignationId { get; set; }
            public string JobtypeName { get; set; }
           // public string ArchiveUserPassword { get; set; }
        }

        private async Task<tempEmployee> GetEmployeeDataAsync(string fileNumber)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = PathsProvider.CERPS_API_URL
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result = (await client.GetAsync(fileNumber)).Content.ReadAsStringAsync().Result;
            var employee = JsonConvert.DeserializeObject<tempEmployee>(result);
            return employee;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var employeeData = await GetEmployeeDataAsync(Input.FileNumber);
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid && employeeData != null)
            {
                var ConfirmationCode = RandomString(5);

                //var user = new ApplicationUser { UserName = Input.FileNumber, Email = Input.Email, FileNumber = Input.FileNumber, PhoneConfirmationCode = ConfirmationCode }; OrigenallCode

                var user = new ApplicationUser { 
                    UserName = employeeData.EmpFileNo
                    , Email = employeeData.EmpEmail
                    , FileNumber = employeeData.EmpFileNo
                    , PhoneNumber = employeeData.EmpPhone
                    , FullName = employeeData.EmpName
                    , ResponsibilityCode = employeeData.EmpResponsibilitycode
                    , JobCatId = employeeData.JobCatId
                    , JobStatus = employeeData.JobStatus
                    , Department = employeeData.PerRespCodeNoName
                    , PhoneConfirmationCode = ConfirmationCode 
                    , RespCodeId = Int32.Parse(employeeData.RespCodeId)
                    , DesignationId = employeeData.DesignationId
                    , JobtypeName = employeeData.JobtypeName
                    , ArchiveUserPassword = Encode(Input.Password)
                    , EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
               
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //await SendSMSAsync(user.PhoneNumber, ConfirmationCode);

                    // await SendEmailAsync(user.Email, ConfirmationCode, Input.Password);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { fileNumber = user.FileNumber, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
            {

            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        private async Task SendEmailAsync(string Email,string confirmationCode, string Password)
        {
            //Send email***********************************************
            string subject = "نظام إدارة المراسلات";
            string body = "رمز التفعيل الخاص بك هو " + " : " + confirmationCode +" ," +"كلمة المرور هي " + " : " + Password;
            string path = "";
           
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("acs@liscomail.com", "نظام إدارة المراسلات")
            };
           
                mailMessage.To.Add(Email);
          
            mailMessage.Subject = subject;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.Body += body;
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("10.10.110.8");
            if (!string.IsNullOrEmpty(path))
            {
                Attachment attachment = new Attachment(path);
                mailMessage.Attachments.Add(attachment);
            }
            smtpClient.Send(mailMessage);

        }
        private async Task SendSMSAsync(string phoneNumber, string confirmationCode)
        {
           
            //============================ SMS code ===============

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("https://tools.icona.ly/api/auth/"),
                Method = HttpMethod.Post
            };

            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Thunder Client (https://www.thunderclient.io)");

            var content = new StringContent("{\n    \"username\": \"demo\",\n    \"password\": \"testing1234\"\n}", Encoding.UTF8, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(result);

            string token = result.Substring(10, 40);

            //string phoneNumber = "000";
            //var CurrentUser = await _userProvider.GetCurrentUserAsync();
            //phoneNumber = CurrentUser.PhoneNumber;

            if (phoneNumber.Substring(0, 6) == "002189") { phoneNumber = phoneNumber.Substring(2, 9); }
            else if (phoneNumber.Substring(0, 6) == "002180") { phoneNumber = "218" + phoneNumber.Substring(6, 9); }
            else if (phoneNumber.Substring(0, 1) == "0") { phoneNumber = "218" + phoneNumber.Substring(1, 9); }
            else if (phoneNumber.Substring(0, 1) == "9") { phoneNumber = "218" + phoneNumber.Substring(0, 9); }
            else if (phoneNumber.Substring(0, 4) == "2189") { phoneNumber = phoneNumber.ToString(); }
            else if (phoneNumber.Substring(0, 4) == "2180") { phoneNumber = "218" + phoneNumber.Substring(4, 9); }
            else
            {
                phoneNumber = "000";
            }

            string messageBudy = "رمز التفعيل الخاص بك هو " + "  " + confirmationCode;

            //The data that needs to be sent. Any object works.
            var messageObject = new
            {
                to = phoneNumber,
                message = messageBudy
            };

            //Converting the object to a json string. NOTE: Make sure the object doesn't contain circular references.
            string ObjectAsString = JsonConvert.SerializeObject(messageObject);
            ObjectAsString = "[ " + ObjectAsString + " ]";

            // Here is working code for sending SMS:
            var SentMissageclient = new HttpClient();
            var SentMissagerequest = new HttpRequestMessage
            {
                RequestUri = new Uri("https://tools.icona.ly/api/outbox/send/"),
                Method = HttpMethod.Get
            };

            SentMissagerequest.Headers.Add("Accept", "*/*");
            SentMissagerequest.Headers.Add("User-Agent", "Thunder Client (https://www.thunderclient.io)");
            SentMissagerequest.Headers.Add("Authorization", "Token " + token);

            var SentMissagecontent = new StringContent(ObjectAsString, Encoding.UTF8, "application/json");

            SentMissagerequest.Content = SentMissagecontent;

            var SentMissageresponse = await SentMissageclient.SendAsync(SentMissagerequest);
            var SentMissageresult = await SentMissageresponse.Content.ReadAsStringAsync();

            //========================================================
        }
        private static string RandomString(int number)
        { 
            return new string(Enumerable.Repeat("123456789", number)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }

        public static string Encode(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }

        }
    }
}
