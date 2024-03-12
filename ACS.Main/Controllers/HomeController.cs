
using ACS.Controllers;
using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.Core.Interfaces.Providers;
using ACS.Core.Interfaces.Services;
using ACS.DataAccess;
using ACS.Services;
using ACS.Web.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
//using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ACS.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController<BaseUser>
    {
        private static Random random = new Random();
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<BaseUser> _userManager;
        private readonly IFeedbackServices<Feedback> _feedbackServices;
        private readonly IWebHostEnvironment hostingEnv;
        private readonly IDocServices<Doc> _docServices; 
        private readonly IMessagesServices<Message> _messageServices;
        private readonly IPackageServices<Package> _packageServices;
        private readonly IOrgnaizationServices<Organization> _organizationServices;
        private readonly IExtendedUserInfoServices<ExtendedUserInfo> _extendedUserInfoServices;
        //private readonly IHubContext<NotificationHub> _notificationHubContext;
        protected readonly IUserProvider _userProvider;

        protected readonly DataContext _dataContext;

        public HomeController(
            UserManager<BaseUser> userManager
            , ILogger<HomeController> logger
            , IFeedbackServices<Feedback> feedbackServices
            , IWebHostEnvironment env
            , IDocServices<Doc> docServices
              , IMessagesServices<Message> messageServices
            , IUserProvider userProvider
            , IOrgnaizationServices<Organization> organizationServices
            , IExtendedUserInfoServices<ExtendedUserInfo> extendedUserInfoServices
            , IPackageServices<Package> packageServices
            ) : base(userManager)
        {
            _logger = logger;
            _userManager = userManager;
            _feedbackServices = feedbackServices;
            this.hostingEnv = env;
            _docServices = docServices;
            _messageServices = messageServices;
            _userProvider = userProvider;
            _packageServices = packageServices;
            _organizationServices = organizationServices;
            _extendedUserInfoServices = extendedUserInfoServices;

        }

        public async Task<IActionResult> Index()
        {
            await CheckAuthorization();
            DeletePreviousTempFiles();
            if (_currentUser is ApplicationUser)
            {
                return RedirectToAction("Inbox", "Messages");
            }
            else if (_currentUser is SubApplicationUser)
            {
                return RedirectToAction("Inbox", "Messages");
            }
            else return NoContent();
        }

        private void DeletePreviousTempFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(hostingEnv.WebRootPath + PathsProvider.TempFilesPath));
            if (!dir.Exists)
            {
                Directory.CreateDirectory(hostingEnv.WebRootPath + PathsProvider.TempFilesPath);
            }
            else
            {
                IEnumerable<FileInfo> fileList = dir.GetFiles("*.*", SearchOption.AllDirectories);
                IEnumerable<FileInfo> fileQuery =
                    from file in fileList
                    where file.CreationTime.Date < DateTime.Today.AddDays(-1)
                    select file;
                foreach (FileInfo fi in fileQuery)
                {
                    fi.Delete();
                }
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> Test()
        {
            await CheckAuthorization();

            //Send email***********************************************
            //string subject = "Hello world"; string body = "تجربة إرسال بريد من خلال النظام"; List<string> to = new List<string>(); string path = "";
            //string x = "alhaj_alnaas@liscomail.com";
            //string y = "a.alshftree@liscomail.com";
            //string z = "adwebi.emad@liscomail.com";
            //to.Add(x); to.Add(y); to.Add(z);
            //MailMessage mailMessage = new MailMessage
            //{
            //    From = new MailAddress("acs@liscomail.com", "نظام إدارة المراسلات")
            //};
            //foreach (string item in to)
            //{
            //    mailMessage.To.Add(item);
            //}
            //mailMessage.Subject = subject;
            //mailMessage.BodyEncoding = Encoding.UTF8;
            //mailMessage.Body += body;
            //mailMessage.IsBodyHtml = true;
            //SmtpClient smtpClient = new SmtpClient("10.10.102.5");
            //if (!string.IsNullOrEmpty(path))
            //{
            //    Attachment attachment = new Attachment(path);
            //    mailMessage.Attachments.Add(attachment);
            //}
            //smtpClient.Send(mailMessage);

            //Send SMS *******************************************************************
            string message = "";
            var users = _userManager.Users.ToList()
            .Where(v =>
           // v.JobCatId == 1
            //&& v is ApplicationUser
            //&& v.PhoneNumber != String.Empty
            //&& v.PhoneNumber != "0"
            //&& v.PhoneNumber.Length >= 9
            // v.PhoneNumber != null
            //&& v.PhoneConfirmationCode == null
            //&& 
            v.FileNumber == "97435"
            ).ToList();

            foreach (var user in users)
            {
                var newPassword = "9743597435";

                user.ArchiveUserPassword = Encode(newPassword);

                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, newPassword);
               
                //_dataContext.Update(user);
                //_dataContext.SaveChangesAsync();


                //message = $"اسم الدخول الخاص بك للدخول إلى نظام إدارة المراسلات هو رقم ملفك، وكلمة المرور هي {newPassword}";
                //await SendSMSAsync(user.PhoneNumber, message);
            }


            //await SendSMSAsync("0926124250", $"اسم الدخول الخاص بك لتجربة نظام إدارة المراسلات هو رقم ملفك، وكلمة المرور هي 559222");

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> DocsWithProblem()
        {
            List<string> namesWithProblem = new List<string>(); ;
            var fileNames = await _docServices.GetAllDocsNames();
            IEnumerable<FileInfo> fileList = new DirectoryInfo(Path.Combine(PathsProvider.FilesPath)).GetFiles("*.*", SearchOption.AllDirectories);
            foreach (var name in fileNames)
            {
                FileInfo file = fileList.FirstOrDefault(f => f.Name == name + ".pdf");
                if (file == null)
                {
                    namesWithProblem.Add(name);
                }
            }
            return View(namesWithProblem);
        }

        private static string RandomString()
        {
            return new string(Enumerable.Repeat("123456789", 6)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }

        private async Task SendSMSAsync(string phoneNumber, string confirmationCode)
        {
            //============================ SMS code ===================

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

            string messageBudy = confirmationCode;

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
            var SentMissagerequest = new HttpRequestMessage();
            SentMissagerequest.RequestUri = new Uri("https://tools.icona.ly/api/outbox/send/");
            SentMissagerequest.Method = HttpMethod.Get;

            SentMissagerequest.Headers.Add("Accept", "*/*");
            SentMissagerequest.Headers.Add("User-Agent", "Thunder Client (https://www.thunderclient.io)");
            SentMissagerequest.Headers.Add("Authorization", "Token " + token);

            var SentMissagecontent = new StringContent(ObjectAsString, Encoding.UTF8, "application/json");

            SentMissagerequest.Content = SentMissagecontent;

            var SentMissageresponse = await SentMissageclient.SendAsync(SentMissagerequest);

            //===========================================
        }
        public async Task<IActionResult> DashboardAsync()
        {
            await CheckAuthorization();
            //==================== عدد الرسائل الصادرة التي لم يتم الرد عليها ========
            var UnreplayedOutboxMessagesCount = await _messageServices.GetUnreplayOutboxMessagesCount(_currentUser);
            ViewData["UnreplayedOutbox"] = UnreplayedOutboxMessagesCount.ToString();
            //==================== عدد الرسائل الواردة التي لم يتم الرد عليها =======
            var OrgnaizationsResponsibilityCodes = (await _organizationServices.GetOrgnaizationsByFileNumber(_currentUser.FileNumber)).Select(d => d.ResponsibilityCode).ToList();
            var UnreplayedInboxmessagesCount = await _messageServices.GetUnreplayInboxMessagesCount(_currentUser, OrgnaizationsResponsibilityCodes);
            ViewData["UnreplayedInbox"] = UnreplayedInboxmessagesCount.ToString();

            //==================== تفاصيل الرسائل الصادرة التي لم يتم الرد عليها =================================
            //var UnreplayedOutboxMessages = await _messageServices.GetUnreplayOutboxMessagesPagingAsync(_currentUser);

            //==================== تفاصيل الرسائل الواردة التي لم يتم الرد عليها ================================
            //var OrgResponsibilityCodes = (await _organizationServices.GetOrgnaizationsByFileNumber(_currentUser.FileNumber)).Select(d => d.ResponsibilityCode).ToList();

            //var UnreplayedInboxMessages = await _messageServices.GetUnreplayInboxMessagesPagingAsync(_currentUser, OrgResponsibilityCodes);

            //==================== تجاهل التنبيه للرد على الرسائل الواردة   =============================================
            //var package = await _packageServices.GetPackegeById(Guid.Parse("857CAD18-095E-46CF-45CF-08D9E4899B08"));
            //_packageServices.MarkMessageAsIgnored(package, true);

            //==================================== تذكير للرد على رسالة ====================================================
            //var OrgenalMessage = await _messageServices.GetMessageByIDWithDetails(Guid.Parse("857CAD18-095E-46CF-45CF-08D9E4899B08"));

            //var message = new Message();
            //{
            //    message.Title = "تذكير";
            //    message.Body = "نأمل الرد على الرسالة ذات الرقم : " + " " + OrgenalMessage.SerialNumber;
            //    message.SenderDiscription = OrgenalMessage.SenderDiscription;
            //    message.ResponsibilityCode = OrgenalMessage.ResponsibilityCode;
            //    message.CreatedBy = _currentUser;
            //    message.CreatedById = _currentUser.Id;
            //    message.LastUpdatedBy = _currentUser;
            //    message.LastUpdatedById = _currentUser.Id;
            //    message.Sender = _currentUser;
            //    message.IsArchived = true;
            //    message.IsDeleted = false;
            //    message.Sent = true;
            //    message.IsOrigin = true;
            //    message.SendingDateTime = DateTime.Now;

            //    message.Packages = OrgenalMessage.Packages.Where(p => p.Id == Guid.Parse("857CAD18-095E-46CF-45CF-08D9E4899B08")).ToList();

            //}

            //_messageServices.NewMessage(message);
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult ReleaseNotes()
        {
            return View();
        }

        public IActionResult Phones()
        {
            return View();
        }

        public IActionResult Error403()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendFeedback(string feedbackText)
        {
            await CheckAuthorization();
            _feedbackServices.SendFeedback(feedbackText, _currentUser as ApplicationUser);
            ViewData["Message"] = "شكرا على اهتمامك";
            return NoContent();
            //return View("Index", "Home");
        }

        public IActionResult ar_Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            List<object> mainMenuItems = new List<object>();
            mainMenuItems.Add(new
            {
                text = "Overview",
                iconCss = "icon-user icon",
                items = new List<object>()
                    {
                        new { text = "All Data" },
                        new { text = "Category2" },
                        new { text = "Category3" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Notification",
                iconCss = "icon-bell-alt icon",
                items = new List<object>()
                    {
                        new { text = "Change Profile" },
                        new { text = "Add Name" },
                        new { text = "Add Details" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Info",
                iconCss = "icon-tag icon",
                items = new List<object>()
                    {
                        new { text = "Message" },
                        new { text = "Facebook" },
                        new { text = "Twitter" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Comments",
                iconCss = "icon-comment-inv-alt2 icon",
                items = new List<object>()
                    {
                        new { text = "Category1 " },
                        new { text = "Category2" },
                        new { text = "Category3" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Bookmarks",
                iconCss = "icon-bookmark icon",
                items = new List<object>()
                    {
                        new { text = "All Comments" },
                        new { text = "Add Comments" },
                        new { text = "Delete Comments" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Images",
                iconCss = "icon-picture icon",
                items = new List<object>()
                    {
                        new { text = "Add Name" },
                        new { text = "Add Mobile Number" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Users",
                iconCss = "icon-user icon",
                items = new List<object>()
                    {
                        new { text = "Mobile User" },
                        new { text = "Laptop User" },
                        new { text = "Desktop User" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Settings",
                iconCss = "icon-eye icon",
                items = new List<object>()
                    {
                        new { text = "Change Profile" },
                        new { text = "Add Name" },
                        new { text = "Add Details" }
                    }
            });
            mainMenuItems.Add(new
            {
                text = "Info",
                iconCss = "icon-tag icon",
                items = new List<object>()
                    {
                        new { text = "Facebook" },
                        new { text = "Mobile" }
                    }
            });
            ViewBag.mainMenuItems = mainMenuItems;

            List<object> AccountMenuItems = new List<object>();
            AccountMenuItems.Add(new
            {
                text = "Account",
                items = new List<object>()
                    {
                        new { text = "Profile" },
                        new { text = "Sign out" }
                    }
            });
            ViewBag.AccountMenuItems = AccountMenuItems;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
