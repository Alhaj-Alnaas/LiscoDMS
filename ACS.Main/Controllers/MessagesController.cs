using ACS.Controllers;
using ACS.Core.DTOs;
using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.Core.Interfaces.Providers;
using ACS.Core.Interfaces.Services;
using ACS.Web.Exceptions;
using ACS.Web.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.OfficeChart;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ACS.Web.Controllers
{
    [Authorize]
    public class MessagesController : BaseController<BaseUser>
    {
        private static Random random = new Random();

        private readonly ICategoryServices<Category> _categoryServices;
        private readonly IDocServices<Doc> _DocServices;
        private readonly IMessagesServices<Message> _messageServices;
        private readonly IPackageServices<Package> _packageServices;
        private readonly IOrgnaizationServices<Organization> _organizationServices;
        private readonly IExtendedUserInfoServices<ExtendedUserInfo> _extendedUserInfoServices;
        private readonly IConfiguration _configuration;
        //private readonly IHubContext<NotificationHub> _notificationHubContext;
        protected readonly IUserProvider _userProvider;
        private readonly IWebHostEnvironment hostingEnv;

        public MessagesController(
            UserManager<BaseUser> userManager
            , ICategoryServices<Category> categoryServices
            , IMessagesServices<Message> messageServices
            , IUserProvider userProvider
            , IOrgnaizationServices<Organization> organizationServices
            , IExtendedUserInfoServices<ExtendedUserInfo> extendedUserInfoServices
            , IPackageServices<Package> packageServices
            , IDocServices<Doc> DocServices
            , IWebHostEnvironment env
            , IConfiguration configuration
            ) : base(userManager)
        //, IHubContext<NotificationHub> notificationHubContext
        {
            _categoryServices = categoryServices;
            _messageServices = messageServices;
            _userProvider = userProvider;
            _packageServices = packageServices;
            _organizationServices = organizationServices;
            _extendedUserInfoServices = extendedUserInfoServices;
            _DocServices = DocServices;
            //_notificationHubContext = notificationHubContext;
            this.hostingEnv = env;
            _configuration = configuration;
        }

        public async Task<bool> CheckSerialNumber(string serialNumber)
        {
            return await _messageServices.CheckSerialNumber(serialNumber);
        }
        public async Task<IActionResult> Scan()
        {
            await CheckAuthorization();
            return View();
        }

        public async Task<IActionResult> CreateDraft()
        {
            await CheckAuthorization();

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);

            ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
            ViewBag.items = RichTextEditorToolsProvider.RichTextEditorToolBar;
            return View();
        }

        public async Task<ActionResult> NewMessagesCountPartialAsync()
        {
            await CheckAuthorization();

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);

            //var DraftsCount = await _messageServices.GetDraftMessageCount(_currentUser);
            var OrganizationsList = await _organizationServices.GetOrgnaizationsByFileNumber(_currentUser.FileNumber);
            var NewMessagesCount = await _messageServices.GetNewMessageCount(_currentUser, OrganizationsList.Select(d => d.ResponsibilityCode).ToList());
            if (NewMessagesCount > 0)
                ViewData["NewMessagesCount"] = NewMessagesCount;
            return PartialView("_NewMessagesCountPartial");
        }

        public async Task<IActionResult> EditDraft(Guid Id, string messageType = "0")
        {
            await CheckAuthorization();

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);

            var message = await _messageServices.GetMessageByIDWithDetails(Id);
            List<BaseUser> users;
            IEnumerable<Organization> OrgnaizationsList;
            switch (messageType)
            {
                //UnFormal
                case "0":
                    ViewData["Users"] = new SelectList(_userProvider.GetAllUsers(_currentUser), "Id", "FullName");
                    ViewData["SenderDescription"] = _currentUser.FullName;
                    //ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
                    //ViewData["sn"] = "بلا";
                    break;

                //Formal
                case "1":
                    //users = _userProvider.GetRelatedUsers(_currentUser.DesignationId, _currentUser.ResponsibilityCode);
                    users = _userProvider.GetAllLeaders(_currentUser);
                    OrgnaizationsList = await _organizationServices.GetAllOrgnaizations();
                    foreach (var org in OrgnaizationsList)
                    {
                        var TempUser = _userProvider.GetUserByFileNumber(org.DelegateNo);
                        ApplicationUser user = new ApplicationUser
                        {
                            //Id = TempUser.Id,
                            Id = org.Id.ToString(),
                            FullName = TempUser.FullName,
                            JobtypeName = org.Name,
                            ResponsibilityCode = org.ResponsibilityCode
                        };
                        users.Add(user);
                    }
                    users.Remove(_currentUser);
                    foreach (var user in users)
                    {
                        //if (user.DesignationId != 0)
                        //{
                        //    user.ResponsibilityCode = user.ResponsibilityCode + "." + user.DesignationId;
                        //}
                        user.JobtypeName = user.FullName + " " + "-" + " " + user.JobtypeName;
                    }
                    //ViewData["sn"] = await _messageServices.GetLastSerialNumber(_currentUser.ResponsibilityCode, _currentUser.DesignationId);
                    ViewData["sn"] = _messageServices.GetSerialNumber(_currentUser.ResponsibilityCode);

                    int MaxSN = await _messageServices.GetLastSerialNumber(_currentUser.ResponsibilityCode, _currentUser.DesignationId);
                    ViewData["lsn"] = MaxSN.ToString("0000");

                    ViewData["Categories"] = new SelectList(await _categoryServices.GetAllCategories(), "Id", "Name");
                    ViewData["Users"] = new SelectList(users, "Id", "JobtypeName");
                    ViewData["CCusers"] = new SelectList(users, "Id", "JobtypeName");
                    ViewData["SenderDescription"] = _currentUser.JobtypeName;
                    ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
                    break;

                //LowLevel
                case "2":
                    ViewData["LowLevel"] = true;
                    ViewData["Categories"] = new SelectList(await _categoryServices.GetAllCategories(), "Id", "Name");
                    ViewData["SenderDescription"] = _currentUser.JobtypeName;
                    //ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
                    //ViewData["sn"] = await _messageServices.GetLastSerialNumber(_currentUser.ResponsibilityCode);
                    break;

                //General
                case "3":
                    ViewData["LowLevel"] = false;
                    ViewData["Categories"] = new SelectList(await _categoryServices.GetAllCategories(), "Id", "Name");
                    ViewData["SenderDescription"] = _currentUser.JobtypeName;
                    //ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
                    //ViewData["sn"] = await _messageServices.GetLastSerialNumber(_currentUser.ResponsibilityCode);
                    break;

                //Committee
                default:
                    if (Int32.Parse(messageType.Split(".").LastOrDefault()) == 0)
                    {
                        users = _userProvider.GetAllLeaders(_currentUser);
                    }
                    else
                    {
                        //users = _userProvider.GetRelatedUsers(Int32.Parse(messageType.Split(".").LastOrDefault()), messageType.Split(".").FirstOrDefault());
                        users = _userProvider.GetAllUsers(_currentUser);
                    }

                    OrgnaizationsList = await _organizationServices.GetAllOrgnaizations();
                    foreach (var org in OrgnaizationsList)
                    {
                        var TempUser = _userProvider.GetUserByFileNumber(org.DelegateNo);
                        ApplicationUser user = new ApplicationUser
                        {
                            //Id = TempUser.Id,
                            Id = org.Id.ToString(),
                            FullName = TempUser.FullName,
                            JobtypeName = org.Name,
                            ResponsibilityCode = org.ResponsibilityCode
                        };
                        users.Add(user);
                    }
                    users.Remove(_currentUser);
                    foreach (var user in users)
                    {
                        //if (user.DesignationId != 0)
                        //{
                        //    user.ResponsibilityCode = user.ResponsibilityCode + "." + user.DesignationId;
                        //}
                        user.JobtypeName = user.FullName + " " + "-" + " " + user.JobtypeName;
                    }

                    var senderOrgnaization = await _organizationServices.GetOrgnaizationByResponsibilityCode(messageType.Split(".").FirstOrDefault(), Int32.Parse(messageType.Split(".").LastOrDefault()));
                    ViewData["Categories"] = new SelectList(await _categoryServices.GetAllCategories(), "Id", "Name");
                    ViewData["Users"] = new SelectList(users, "Id", "JobtypeName");
                    ViewData["CCusers"] = new SelectList(users, "Id", "JobtypeName");
                    ViewData["SenderDescription"] = senderOrgnaization.Description;
                    ViewData["SenderResponsibilityCode"] = messageType.Split(".").FirstOrDefault();
                    ViewData["SenderDesignationId"] = messageType.Split(".").LastOrDefault();
                    //ViewData["sn"] = await _messageServices.GetLastSerialNumber(messageType.Split(".").FirstOrDefault(), Int32.Parse(messageType.Split(".").LastOrDefault()));
                    ViewData["sn"] = _messageServices.GetSerialNumber(messageType.Split(".").FirstOrDefault());
                    break;
            }
            //var messageHeader = $"<br><br><br><br><br><br><p><span style=\"font-size: 18pt;\">&nbsp; &nbsp; &nbsp; {message.SendingDateTime:yyyy/MM/dd HH:mm}</span></p><p><span style=\"font-size: 18pt;\">&nbsp; &nbsp; &nbsp; {message.SerialNumber}</span></p><br><br><br><p style=\"text-align: center;\"><span style=\"font-size: 24pt;\"><strong>{message.Title}</strong></span></p>";
            //ViewData["Path"] = PDFMergeAndStamp(message.Documents.OrderByDescending(y => y.CreatedOn).Select(r => r.Id.ToString()).ToList(), _currentUser.FileNumber, messageHeader + "<div style=\"margin: 60px\">" + message.Body + "</div>", true);
            ViewBag.items = RichTextEditorToolsProvider.RichTextEditorToolBar;
            ViewData["MessageTitle"] = message.Title;
            ViewData["CurrentUserFileNumber"] = _currentUser.FileNumber;
            ViewData["JobCatId"] = _currentUser.JobCatId;
            ViewData["messageId"] = message.Id;
            ViewData["messageType"] = messageType.Split(".").FirstOrDefault();
            return View(message);
        }

        public async Task<IActionResult> NewFormalMessageAsync()
        {
            await CheckAuthorization();

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);

            if (_currentUser.JobCatId != 1)
                throw new UnAuthorizedException("غير مصرح");
            var OrgnaizationsList = await _organizationServices.GetAllOrgnaizations();
            //var users = _userProvider.GetRelatedUsers(_currentUser.DesignationId, _currentUser.ResponsibilityCode);
            var users = _userProvider.GetAllUsers(_currentUser);

            foreach (var org in OrgnaizationsList)
            {
                var TempUser = _userProvider.GetUserByFileNumber(org.DelegateNo);
                ApplicationUser user = new ApplicationUser
                {
                    //Id = TempUser.Id,
                    Id = org.Id.ToString(),
                    FullName = TempUser.FullName,
                    JobtypeName = org.Name,
                    ResponsibilityCode = org.ResponsibilityCode
                };
                users.Add(user);
            }
            users.Remove(_currentUser);
            foreach (var user in users)
            {
                //if (user.DesignationId != 0)
                //{
                //    user.ResponsibilityCode = user.ResponsibilityCode + "." + user.DesignationId;
                //}
                user.JobtypeName = user.FullName + " " + "-" + " " + user.JobtypeName;
            }
            ViewBag.items = RichTextEditorToolsProvider.RichTextEditorToolBar;
            ViewData["Categories"] = new SelectList(await _categoryServices.GetAllCategories(), "Id", "Name");

            int MaxSN = await _messageServices.GetLastSerialNumber(_currentUser.ResponsibilityCode, _currentUser.DesignationId);
            ViewData["lsn"] = MaxSN.ToString("0000");

            ViewData["sn"] = _messageServices.GetSerialNumber(_currentUser.ResponsibilityCode);
            ViewData["Users"] = new SelectList(users, "Id", "JobtypeName");
            ViewData["CCusers"] = new SelectList(users, "Id", "JobtypeName");
            ViewData["SenderDescription"] = _currentUser.JobtypeName;
            ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
            return View();
        }

        public async Task<IActionResult> NewUnFormalMessageAsync()
        {
            await CheckAuthorization();
            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);

            ViewData["SenderDescription"] = _currentUser.FullName;
            ViewData["Users"] = new SelectList(_userProvider.GetAllUsers(_currentUser), "Id", "FullName");
            ViewBag.items = RichTextEditorToolsProvider.RichTextEditorToolBar;
            return View();
        }

        public async Task<IActionResult> NewCommitteeMessageAsync(string ResponsibilityCode, string Description = "")
        {
            await CheckAuthorization();

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);

            var UserOrgnaizationsList = (await _organizationServices.GetOrgnaizationsByFileNumber(_currentUser.FileNumber)).Select(o => o.ResponsibilityCode).ToList();
            if (ResponsibilityCode == "" || ResponsibilityCode == null || !UserOrgnaizationsList.Contains(ResponsibilityCode.Split(".").FirstOrDefault()))
                throw new UnAuthorizedException("Unauthorized User");
            var AllOrgnaizationsList = await _organizationServices.GetAllOrgnaizations();
            List<BaseUser> users;
            if (Int32.Parse(ResponsibilityCode.Split(".").LastOrDefault()) == 0)
            {
                users = _userProvider.GetAllLeaders(_currentUser);
            }
            else
            {
                //users = _userProvider.GetRelatedUsers(Int32.Parse(ResponsibilityCode.Split(".").LastOrDefault()), ResponsibilityCode.Split(".").FirstOrDefault());
                users = _userProvider.GetAllUsers(_currentUser);
            }
            foreach (var org in AllOrgnaizationsList)
            {
                var TempUser = _userProvider.GetUserByFileNumber(org.DelegateNo);
                ApplicationUser user = new ApplicationUser
                {
                    //Id = TempUser.Id,
                    Id = org.Id.ToString(),
                    FullName = TempUser.FullName,
                    JobtypeName = org.Name,
                    ResponsibilityCode = org.ResponsibilityCode
                };
                users.Add(user);
            }
            users.Remove(_currentUser);
            foreach (var user in users)
            {
                //if (user.DesignationId != 0)
                //{
                //    user.ResponsibilityCode = user.ResponsibilityCode + "." + user.DesignationId;
                //}
                user.JobtypeName = user.FullName + " " + "-" + " " + user.JobtypeName;
            }
            //ViewData["sn"] = await _messageServices.GetLastSerialNumber(ResponsibilityCode.Split(".").FirstOrDefault(), Int32.Parse(ResponsibilityCode.Split(".").LastOrDefault()));
            ViewData["sn"] = _messageServices.GetSerialNumber(ResponsibilityCode.Split(".").FirstOrDefault());
            ViewData["SenderResponsibilityCode"] = ResponsibilityCode.Split(".").FirstOrDefault();
            ViewData["SenderDesignationId"] = ResponsibilityCode.Split(".").LastOrDefault();
            ViewData["SenderDescription"] = Description;
            ViewData["Users"] = new SelectList(users, "Id", "JobtypeName");
            ViewData["CCusers"] = new SelectList(users, "Id", "JobtypeName");
            ViewData["Categories"] = new SelectList(await _categoryServices.GetAllCategories(), "Id", "Name");
            ViewBag.items = RichTextEditorToolsProvider.RichTextEditorToolBar;
            return View();
        }

        public async Task<IActionResult> NewGeneralMessageAsync(bool LowLevel = false)
        {
            await CheckAuthorization();

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);

            if (_currentUser.JobCatId != 1)
                throw new UnAuthorizedException("Unauthorized User");
            //ViewData["sn"] = await _messageServices.GetLastSerialNumber(_currentUser.ResponsibilityCode);
            //ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
            ViewData["SenderDescription"] = _currentUser.JobtypeName;
            ViewData["LowLevel"] = LowLevel;
            ViewData["Categories"] = new SelectList(await _categoryServices.GetAllCategories(), "Id", "Name");
            ViewBag.items = RichTextEditorToolsProvider.RichTextEditorToolBar;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendUnFormalMessageAsync([FromBody] Message message)
        {
            await CheckAuthorization();

            foreach (var package in message.Packages)
            {
                var user = _userProvider.GetUserById(package.RecipintId);
                package.Recipint = user as ApplicationUser;
                package.RecipintId = user.Id;
                package.RecipintDiscription = user.FullName;
                package.DesignationId = user.DesignationId;
                package.CreatedBy = _currentUser;
            }
            message.IsOrigin = message.OriginMessageId == null ? true : false;
            _messageServices.NewMessage(message);
            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);
            _messageServices.SendMessage(message, _currentUser);
            return RedirectToAction("Inbox");
        }

        [HttpPost]
        public async Task<IActionResult> SendFormalMessageAsync([FromBody] Message message)
        {
            await CheckAuthorization();

            foreach (var package in message.Packages)
            {
                //var recipint = _userProvider.GetUserByResponsibilityCode(package.ResponsibilityCode.Split(".").FirstOrDefault(), Int32.Parse(package.ResponsibilityCode.Split(".").LastOrDefault())) as ApplicationUser;
                var recipint = _userProvider.GetUserById(package.RecipintId) as ApplicationUser;
                ApplicationUser Ouser = new ApplicationUser();

                if (recipint == null)
                {
                    //var orgnaization = await _organizationServices.GetOrgnaizationByResponsibilityCode(package.ResponsibilityCode.Split(".").FirstOrDefault(), Int32.Parse(package.ResponsibilityCode.Split(".").LastOrDefault()));

                    var orgnaization = await _organizationServices.GetOrgnaizationById(package.RecipintId.ToString());
                    Ouser = _userProvider.GetUserByFileNumber(orgnaization.DelegateNo) as ApplicationUser;
                    package.RecipintDiscription = orgnaization.Description;
                    package.ResponsibilityCode = orgnaization.ResponsibilityCode;
                    package.DesignationId = orgnaization.DesignationId;
                    package.Recipint = Ouser;
                    package.RecipintId = Ouser.Id;

                    if (package.RecipintId == _currentUser.Id)
                        package.IsReaded = true;
                }
                else
                {
                    if (recipint.JobCatId == 1)
                        package.RecipintDiscription = recipint.JobtypeName;
                    else
                        package.RecipintDiscription = recipint.FullName;

                    package.ResponsibilityCode = recipint.ResponsibilityCode;
                    package.DesignationId = recipint.DesignationId;
                    package.Recipint = recipint;
                    package.RecipintId = recipint.Id;

                    if (package.RecipintId == _currentUser.Id)
                        package.IsReaded = true;
                }
                package.CreatedBy = _currentUser;
            }

            if (message.OriginMessageId != null && message.Id.ToString() != message.OriginMessageId)
            {
                message.SerialNumber = message.SerialNumber + "." + (await _messageServices.GetCommentLastSerialNumber(Guid.Parse(message.OriginMessageId))).ToString();
            }

            _messageServices.NewMessage(message);
            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);
            _messageServices.SendMessage(message, _currentUser);
            return RedirectToAction("Inbox");
        }

        [HttpPost]
        public async Task<IActionResult> SendGeneralMessageAsync([FromBody] Message message)
        {
            await CheckAuthorization();

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);

            var users = _userProvider.GetAllUsers(_currentUser);
            List<Package> packages = new List<Package>();
            foreach (var user in users)
            {
                Package package = new Package
                {
                    Recipint = user as ApplicationUser,
                    RecipintId = user.Id,
                    //ResponsibilityCode = user.ResponsibilityCode,
                    RecipintDiscription = user.FullName,
                    DesignationId = user.DesignationId,
                    CreatedBy = _currentUser
                };
                packages.Add(package);
            }
            message.Packages = packages;
            _messageServices.NewMessage(message);
            _messageServices.SendMessage(message, _currentUser);

            return RedirectToAction("Inbox");
        }

        [HttpPost]
        public async Task<IActionResult> SendGeneralDraft([FromBody] Message newMessage)
        {
            await CheckAuthorization();

            var users = _userProvider.GetAllUsers(_currentUser);
            var message = await _messageServices.GetMessageByIDWithDetails(newMessage.Id);
            List<Package> packages = new List<Package>();
            foreach (var user in users)
            {
                Package package = new Package
                {
                    Recipint = user as ApplicationUser,
                    RecipintId = user.Id,
                    //ResponsibilityCode = user.ResponsibilityCode,
                    RecipintDiscription = user.FullName,
                    DesignationId = user.DesignationId,
                    CreatedBy = _currentUser
                };
                packages.Add(package);
            }
            newMessage.Packages = packages;

            message = _messageServices.CloneTwoMessages(message, newMessage);

            message.Sent = true;
            message.SendingDateTime = DateTime.Now;
            message.Sender = _currentUser;
            message.DesignationId = _currentUser.DesignationId;
            _messageServices.UpdateMessage(message);

            return RedirectToAction("Inbox");
        }

        [HttpPost]
        public async Task<IActionResult> SendGeneralDraftForLowLevel([FromBody] Message newMessage)
        {
            await CheckAuthorization();

            var users = _userProvider.GetLowLevelUsers(_currentUser.DesignationId, _currentUser.ResponsibilityCode);
            var message = await _messageServices.GetMessageByIDWithDetails(newMessage.Id);
            users.Remove(_currentUser);
            List<Package> packages = new List<Package>();
            foreach (var user in users)
            {
                Package package = new Package
                {
                    Recipint = user as ApplicationUser,
                    RecipintId = user.Id,
                    //ResponsibilityCode = user.ResponsibilityCode,
                    RecipintDiscription = user.JobtypeName,
                    DesignationId = user.DesignationId,
                    CreatedBy = _currentUser
                };
                packages.Add(package);
            }
            newMessage.Packages = packages;
            message = _messageServices.CloneTwoMessages(message, newMessage);

            message.Sent = true;
            message.SendingDateTime = DateTime.Now;
            message.Sender = _currentUser;
            message.DesignationId = _currentUser.DesignationId;
            _messageServices.UpdateMessage(message);

            return RedirectToAction("Inbox");
        }

        [HttpPost]
        public async Task<IActionResult> SendGeneralMessageForLowLevelAsync([FromBody] Message message)
        {
            await CheckAuthorization();

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);

            var users = _userProvider.GetLowLevelUsers(_currentUser.DesignationId, _currentUser.ResponsibilityCode);
            users.Remove(_currentUser);
            if (users.Count() > 0)
            {
                List<Package> packages = new List<Package>();
                foreach (var user in users)
                {
                    Package package = new Package
                    {
                        Recipint = user as ApplicationUser,
                        RecipintId = user.Id,
                        //ResponsibilityCode = user.ResponsibilityCode,
                        RecipintDiscription = user.JobtypeName,
                        DesignationId = user.DesignationId,
                        CreatedBy = _currentUser
                    };
                    packages.Add(package);
                }
                message.Packages = packages;
                _messageServices.NewMessage(message);
                _messageServices.SendMessage(message, _currentUser);
            }
            return RedirectToAction("Inbox");
        }

        public async Task<IActionResult> ShowMessageAllRecipints(Guid Id, bool CC)
        {
            return PartialView("MessageAllRecipints", (await _messageServices.GetMessageByIDWithDetails(Id)).Packages.Where(l => l.IsCC == CC).ToList());
        }

        [HttpPost]
        public IActionResult NewDraft([FromBody] Message message)
        {
            _messageServices.NewMessage(message);
            message.OriginMessageId ??= message.Id.ToString();
            message.IsOrigin = true;
            _messageServices.UpdateMessage(message);
            return RedirectToAction("Inbox");
        }

        [HttpPost]
        public async Task<IActionResult> SaveDraft([FromBody] Message newMessage)
        {
            await CheckAuthorization();

            var message = await _messageServices.GetMessageByIDWithDetails(newMessage.Id);

            message = _messageServices.CloneTwoDrafts(message, newMessage);
            _messageServices.UpdateMessage(message);
            _DocServices.AddNewDocs(message, newMessage.Documents.ToList());
            return RedirectToAction("Inbox");
        }

        [HttpPost]
        public async Task<IActionResult> SendDraft([FromBody] Message newMessage)
        {
            await CheckAuthorization();

            var message = await _messageServices.GetMessageByIDWithDetails(newMessage.Id);

            message = _messageServices.CloneTwoMessages(message, newMessage);

            if (message.SerialNumber == null || message.SerialNumber == "بلا")
            {
                foreach (var package in message.Packages)
                {
                    var user = _userProvider.GetUserById(package.RecipintId) as ApplicationUser;
                    package.Recipint = user;
                    package.RecipintId = user.Id;
                    package.RecipintDiscription = user.FullName;
                    package.DesignationId = user.DesignationId;
                    package.CreatedBy = _currentUser;
                }
                message.SerialNumber = null;
            }
            else
            {
                foreach (var package in message.Packages)
                {
                    //var recipint = _userProvider.GetUserByResponsibilityCode(package.ResponsibilityCode.Split(".").FirstOrDefault(), Int32.Parse(package.ResponsibilityCode.Split(".").LastOrDefault())) as ApplicationUser;
                    var recipint = _userProvider.GetUserById(package.RecipintId) as ApplicationUser;
                    ApplicationUser Ouser = new ApplicationUser();

                    if (recipint == null)
                    {
                        //var orgnaization = await _organizationServices.GetOrgnaizationByResponsibilityCode(package.ResponsibilityCode, package.DesignationId);
                        //recipint = _userProvider.GetUserByFileNumber(orgnaization.DelegateNo) as ApplicationUser;
                        //package.RecipintDiscription = orgnaization.Description;

                        var orgnaization = await _organizationServices.GetOrgnaizationById(package.RecipintId.ToString());
                        Ouser = _userProvider.GetUserByFileNumber(orgnaization.DelegateNo) as ApplicationUser;
                        package.RecipintDiscription = orgnaization.Description;
                        package.ResponsibilityCode = orgnaization.ResponsibilityCode;
                        package.DesignationId = orgnaization.DesignationId;
                        package.Recipint = Ouser;
                        package.RecipintId = Ouser.Id;

                        if (package.RecipintId == _currentUser.Id)
                            package.IsReaded = true;
                    }
                    else
                    {
                        package.RecipintDiscription = recipint.JobtypeName;
                        if (recipint.JobCatId == 1)
                            package.RecipintDiscription = recipint.JobtypeName;
                        else
                            package.RecipintDiscription = recipint.FullName;

                        package.ResponsibilityCode = recipint.ResponsibilityCode;
                        package.DesignationId = recipint.DesignationId;
                        package.Recipint = recipint;
                        package.RecipintId = recipint.Id;

                        if (package.RecipintId == _currentUser.Id)
                            package.IsReaded = true;
                    }
                    package.CreatedBy = _currentUser;
                }
            }

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);

            message.Sent = true;
            message.SendingDateTime = DateTime.Now;
            message.Sender = _currentUser;
            if (message.DesignationId == 0)
                message.DesignationId = _currentUser.DesignationId;

            _messageServices.UpdateMessage(message);
            _DocServices.AddNewDocs(message, newMessage.Documents.ToList());

            return RedirectToAction("Inbox");
        }


        //public async Task<IActionResult> Inbox(int pageindex = 1)
        //{
        //    await CheckAuthorization();
        //    //Log.Logger.Information($"Get into inbox: User {_currentUser.FileNumber}.");
        //    //List<string> OrgnaizationsResponsibilityCodes = null;
        //    var Orgnaizations = await _organizationServices.GetOrgnaizationsByFileNumber(_currentUser.FileNumber);
        //    var OrgnaizationsResponsibilityCodes = Orgnaizations.Select(d => d.ResponsibilityCode).ToList();
        //    var messages = await _messageServices.GetInboxMessagesPagingAsync(_currentUser, OrgnaizationsResponsibilityCodes, pageindex);

        //    //ViewData["ResponsibilityCodes"] = new SelectList(Orgnaizations.ToList(), "ResponsibilityCode", "Name");
        //    ViewData["CurrentUserId"] = _currentUser.Id;
        //    ViewData["CurrentUserResponsibilityCode"] = _currentUser.ResponsibilityCode;
        //    messages.Action = "Inbox";
        //    return View(messages);
        //}

        public async Task<IActionResult> Inbox()
        {
            await CheckAuthorization();

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);

            //var OrgnaizationsResponsibilityCodes = (await _organizationServices.GetOrgnaizationsByFileNumber(_currentUser.FileNumber)).Select(d => d.ResponsibilityCode).ToList();
            //ViewBag.datasource = (await _messageServices.GetInboxMessages(_currentUser, OrgnaizationsResponsibilityCodes)).ToList();

            SqlConnection cnn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            List<CollectingMessage> InboxMessages = new List<CollectingMessage>();
            SqlCommand com = new SqlCommand("sp_show_inbox", cnn);
            com.Parameters.Add(new SqlParameter("@UserRespCode", _currentUser.ResponsibilityCode));
            com.Parameters.Add(new SqlParameter("@UserFileNumber", _currentUser.FileNumber));
            com.Parameters.Add(new SqlParameter("@UserId", _currentUser.Id));
            com.Parameters.Add(new SqlParameter("@JobCatId", _currentUser.JobCatId));
            com.Parameters.Add(new SqlParameter("@DesignationId", _currentUser.DesignationId));
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                InboxMessages.Add(new CollectingMessage
                {
                    Id = Guid.Parse(dr["ID"].ToString()),
                    SerialNumber = Convert.ToString(dr["SerialNumber"]),
                    SenderId = Convert.ToString(dr["SenderId"]),
                    SenderDiscription = Convert.ToString(dr["SenderDiscription"]),
                    MessageFrom = Convert.ToString(dr["MessageFrom"]),
                    IsDeleted = Convert.ToBoolean(dr["IsDeleted"]),
                    passedBy = Convert.ToString(dr["passedBy"]),
                    RecipintDiscription = Convert.ToString(dr["RecipintDiscription"]),
                    IsReaded = Convert.ToBoolean(dr["IsReaded"]),
                    IsReplyed = Convert.ToBoolean(dr["IsReplyed"]),
                    Title = Convert.ToString(dr["Title"]),
                    Body = Convert.ToString(dr["Body"]),
                    OriginalBody = Convert.ToString(dr["OriginalBody"]),
                    OriginMessageId = Convert.ToString(dr["OriginMessageId"]),
                    IsOrigin = Convert.ToBoolean(dr["IsOrigin"]),
                    SendingDateTime = Convert.ToDateTime(dr["SendingDateTime"])
                });
            }

            ViewBag.datasource = InboxMessages;
            return View();
        }

        //        await CheckAuthorization();
        //        //Log.Logger.Information($"Get into inbox: User {_userProvider.GetCurrentUserName()}.");
        //        var OriginalMessage = await _messageServices.GetMessageByIDWithDetails(Id);
        //        
        //            /////////////////////////////////////////////
        //            if (OriginalMessage.ResponsibilityCode != null)
        //            {
        //                var users = _userProvider.GetRelatedUsers(_currentUser.DesignationId, _currentUser.ResponsibilityCode);
        //        var OrgnaizationsList = await _organizationServices.GetAllOrgnaizations(_currentUser.FileNumber);
        //                foreach (var org in OrgnaizationsList)
        //                {
        //                    var TempUser = _userProvider.GetUserByFileNumber(org.DelegateNo);
        //        ApplicationUser user = new ApplicationUser
        //        {
        //            Id = TempUser.Id,
        //            FullName = TempUser.FullName,
        //            JobtypeName = org.Name,
        //            ResponsibilityCode = org.ResponsibilityCode
        //        };
        //        users.Add(user);
        //                }
        //    users.Remove(_currentUser);
        //                foreach (var user in users)
        //                {
        //                    user.JobtypeName = user.FullName + " " + "-" + " " + user.JobtypeName;
        //                }
        //ViewData["sn"] = await _messageServices.GetLastSerialNumber(_currentUser.ResponsibilityCode);
        //ViewData["SenderDescription"] = _currentUser.JobtypeName;
        //ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
        //ViewData["Users"] = new SelectList(users, "ResponsibilityCode", "JobtypeName");
        //            }
        //            else
        //{
        //    ViewData["Users"] = new SelectList(_userProvider.GetAllUsers(_currentUser), "Id", "FullName");
        //    ViewData["SenderDescription"] = _currentUser.FullName;
        //    ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
        //}
        ////////////////////////////////////////////
        //ViewBag.items = RichTextEditorToolsProvider.RichTextEditorToolBar;
        //ViewData["OriginalMessageId"] = OriginalMessage.Id.ToString();
        //ViewData["MessageTitle"] = " رد على: " + OriginalMessage.Title;
        //return View();

        //public async Task<IActionResult> ReplyMessageAsync(Guid Id)
        //{
        //    await CheckAuthorization();
        //    //Log.Logger.Information($"Get into inbox: User {_userProvider.GetCurrentUserName()}.");
        //    var OriginalMessage = await _messageServices.GetMessageByIDWithDetails(Id);

        //    ViewBag.items = RichTextEditorToolsProvider.RichTextEditorToolBar;
        //    ViewData["OriginalMessageId"] = OriginalMessage.Id.ToString();
        //    ViewData["MessageTitle"] = " رد على: " + OriginalMessage.Title;

        //    if (OriginalMessage.SerialNumber != null)
        //    {
        //        var OrgnaizationsList = await _organizationServices.GetAllOrgnaizations();
        //        //var users = _userProvider.GetRelatedUsers(_currentUser.DesignationId, _currentUser.ResponsibilityCode);
        //        var users = _userProvider.GetAllUsers(_currentUser);

        //        foreach (var org in OrgnaizationsList)
        //        {
        //            var TempUser = _userProvider.GetUserByFileNumber(org.DelegateNo);
        //            ApplicationUser user = new ApplicationUser
        //            {
        //                Id = TempUser.Id,
        //                FullName = TempUser.FullName,
        //                JobtypeName = org.Name,
        //                ResponsibilityCode = org.ResponsibilityCode
        //            };
        //            users.Add(user);
        //        }
        //        users.Remove(_currentUser);
        //        foreach (var user in users)
        //        {
        //            if (user.DesignationId != 0)
        //            {
        //                user.ResponsibilityCode = user.ResponsibilityCode + "." + user.DesignationId;
        //            }
        //            user.JobtypeName = user.FullName + " " + "-" + " " + user.JobtypeName;
        //        }

        //        //ViewData["sn"] = await _messageServices.GetLastSerialNumber(_currentUser.ResponsibilityCode, _currentUser.DesignationId);
        //        ViewData["sn"] = _messageServices.GetSerialNumber(_currentUser.ResponsibilityCode);
        //        ViewData["Users"] = new SelectList(users, "ResponsibilityCode", "JobtypeName");

        //        var RelatedSender = _userProvider.GetUserById((await _messageServices.GetMessageMovements(OriginalMessage.Id.ToString())).FirstOrDefault(u => u.Packages.Any(o => o.RecipintId == _currentUser.Id)).SenderId) as ApplicationUser;

        //        ViewData["SenderId"] = RelatedSender.ResponsibilityCode + "." + RelatedSender.DesignationId.ToString();
        //        ViewData["SenderName"] = RelatedSender.JobtypeName;

        //        ViewData["SenderDescription"] = _currentUser.JobtypeName;
        //        ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
        //    }
        //    else
        //    {
        //        ViewData["Users"] = new SelectList(_userProvider.GetAllUsers(_currentUser), "Id", "FullName");
        //        ViewData["SenderId"] = OriginalMessage.Sender.Id;
        //        ViewData["SenderName"] = OriginalMessage.Sender.FullName;
        //        ViewData["SenderDescription"] = _currentUser.FullName;
        //        //ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
        //    }
        //    return View();
        //}

        public async Task<IActionResult> Outbox()
        {
            await CheckAuthorization();

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);
            //Log.Logger.Information($"Get into inbox: User {_userProvider.GetCurrentUserName()}.");
            //var OrgnaizationsResponsibilityCodes = (await _organizationServices.GetOrgnaizationsByFileNumber(_currentUser.FileNumber)).Select(d => d.ResponsibilityCode).ToList();
            //ViewBag.datasource = (await _messageServices.GetOutboxMessages(_currentUser, OrgnaizationsResponsibilityCodes)).ToList();

            SqlConnection cnn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            List<CollectingMessage> InboxMessages = new List<CollectingMessage>();
            SqlCommand com = new SqlCommand("sp_show_outbox", cnn);
            com.Parameters.Add(new SqlParameter("@UserRespCode", _currentUser.ResponsibilityCode));
            com.Parameters.Add(new SqlParameter("@UserFileNumber", _currentUser.FileNumber));
            com.Parameters.Add(new SqlParameter("@UserId", _currentUser.Id));
            com.Parameters.Add(new SqlParameter("@JobCatId", _currentUser.JobCatId));
            com.Parameters.Add(new SqlParameter("@DesignationId", _currentUser.DesignationId));
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                InboxMessages.Add(new CollectingMessage
                {
                    Id = Guid.Parse(dr["ID"].ToString()),
                    SerialNumber = Convert.ToString(dr["SerialNumber"]),
                    SenderId = Convert.ToString(dr["SenderId"]),
                    SenderDiscription = Convert.ToString(dr["SenderDiscription"]),
                    MessageFrom = Convert.ToString(dr["MessageFrom"]),
                    IsDeleted = Convert.ToBoolean(dr["IsDeleted"]),
                    passedBy = Convert.ToString(dr["passedBy"]),
                    RecipintDiscription = Convert.ToString(dr["RecipintDiscription"]),
                    IsReaded = Convert.ToBoolean(dr["IsReaded"]),
                    IsReplyed = Convert.ToBoolean(dr["IsReplyed"]),
                    Title = Convert.ToString(dr["Title"]),
                    Body = Convert.ToString(dr["Body"]),
                    OriginalBody = Convert.ToString(dr["OriginalBody"]),
                    OriginMessageId = Convert.ToString(dr["OriginMessageId"]),
                    IsOrigin = Convert.ToBoolean(dr["IsOrigin"]),
                    SendingDateTime = Convert.ToDateTime(dr["SendingDateTime"])
                });
            }

            ViewBag.datasource = InboxMessages;

            return View();
        }

        public async Task<IActionResult> Drafts()
        {
            await CheckAuthorization();

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);
            //Log.Logger.Information($"Get into inbox: User {_userProvider.GetCurrentUserName()}.");
            ViewBag.datasource = (await _messageServices.GetDraftMessages(_currentUser)).ToList();
            return View();
        }

        public async Task<IActionResult> Deleted()
        {
            await CheckAuthorization();

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);
            //Log.Logger.Information($"Get into inbox: User {_userProvider.GetCurrentUserName()}.");
            //var OrgnaizationsResponsibilityCodes = (await _organizationServices.GetOrgnaizationsByFileNumber(_currentUser.FileNumber)).Select(d => d.ResponsibilityCode).ToList();
            //ViewBag.datasource = (await _messageServices.GetDeletedMessages(_currentUser, OrgnaizationsResponsibilityCodes)).ToList();

            SqlConnection cnn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            List<CollectingMessage> InboxMessages = new List<CollectingMessage>();
            SqlCommand com = new SqlCommand("sp_show_deleted_messages", cnn);
            com.Parameters.Add(new SqlParameter("@UserId", _currentUser.Id));
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                InboxMessages.Add(new CollectingMessage
                {
                    Id = Guid.Parse(dr["ID"].ToString()),
                    SerialNumber = Convert.ToString(dr["SerialNumber"]),
                    SenderId = Convert.ToString(dr["SenderId"]),
                    SenderDiscription = Convert.ToString(dr["SenderDiscription"]),
                    MessageFrom = Convert.ToString(dr["MessageFrom"]),
                    IsDeleted = Convert.ToBoolean(dr["IsDeleted"]),
                    passedBy = Convert.ToString(dr["passedBy"]),
                    RecipintDiscription = Convert.ToString(dr["RecipintDiscription"]),
                    IsReaded = Convert.ToBoolean(dr["IsReaded"]),
                    IsReplyed = Convert.ToBoolean(dr["IsReplyed"]),
                    Title = Convert.ToString(dr["Title"]),
                    Body = Convert.ToString(dr["Body"]),
                    OriginalBody = Convert.ToString(dr["OriginalBody"]),
                    OriginMessageId = Convert.ToString(dr["OriginMessageId"]),
                    IsOrigin = Convert.ToBoolean(dr["IsOrigin"]),
                    SendingDateTime = Convert.ToDateTime(dr["SendingDateTime"])
                });
            }

            ViewBag.datasource = InboxMessages;

            return View();
        }

        public async Task<IActionResult> Favorites()
        {
            await CheckAuthorization();
            //Log.Logger.Information($"Get into inbox: User {_userProvider.GetCurrentUserName()}.");
            return View();
        }

        public async Task<IActionResult> DeletedMessage(Guid Id)
        {
            await CheckAuthorization();

            BaseUser _currentSubUser = null;
            List<string> subUserRoles = null;
            if (_currentUser is SubApplicationUser)
            {
                _currentSubUser = _currentUser;
                subUserRoles = await _userProvider.GetUserRolesAsync(_currentSubUser);
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);
            }

            var OrgnaizationsResponsibilityCodes = (await _organizationServices.GetOrgnaizationsByFileNumber(_currentUser.FileNumber)).Select(d => d.ResponsibilityCode).ToList();

            var pac = await _packageServices.GetPackegeById(Id);

            var message = await _messageServices.GetMessageByIDWithDetails(pac.MessageId);
            var packages = message.Packages.Where(a => a.RecipintId == _currentUser.Id || (a.ResponsibilityCode == _currentUser.ResponsibilityCode && a.DesignationId == _currentUser.DesignationId) || OrgnaizationsResponsibilityCodes.Contains(a.ResponsibilityCode)).ToList();

            if ((packages == null || packages.Count() == 0) && message.Sender.Id != _currentUser.Id && !OrgnaizationsResponsibilityCodes.Contains(message.ResponsibilityCode)
                && message.ResponsibilityCode != _currentUser.ResponsibilityCode && message.DesignationId != _currentUser.DesignationId)
            {
                return RedirectToAction("Error403", "Home");
            }

            if (!message.IsOrigin)
            {
                message = await _messageServices.GetMessageByIDWithDetails(Guid.Parse(message.OriginMessageId));
            }

            ViewData["CurrentUserDesignationId"] = _currentUser.DesignationId;
            ViewData["CurrentUserResponsibilityCode"] = _currentUser.ResponsibilityCode;
            ViewData["CurrentUserJobtypeName"] = _currentUser.JobtypeName;
            ViewData["CurrentUserFileNumber"] = _currentUser.FileNumber;

            var allMovements = (await _messageServices.GetMessageMovements(message.Id.ToString())).ToList();
            var comments = allMovements.Where(x => x.IsOrigin == false).OrderBy(u => u.CreatedOn).ToList();


            ////////////////////////////////////////////////////////////
            var commentsFilePath = "";
            string commentsHeader = $"<div style=\"margin: 60px\"><br><br><p style=\"text-align: right;\"><span style=\"font-size: 18pt;\"><strong>عنوان المراسلة: {message.Title}</strong></span></p><p style=\"text-align: right;\"><span style=\"font-size: 18pt;\"><strong>تاريخ المراسلة: {message.SendingDateTime:yyyy/MM/dd HH:mm}</strong></span></p><p style=\"text-align: right;\"><span style=\"font-size: 18pt;\"><strong>الرقم الإشاري: {message.SerialNumber}</strong></span></p><br><br><br><br><p style=\"text-align: center;\"><span style=\"font-size: 24pt;\"><strong>التعليقات على المراسلة</strong></span></p></div>";


            if (comments.Where(d => d.Body != "" && d.Body != null).ToList().Count > 0)
            {
                string commentsList = "<div style=\"text-align:right;margin: 60px\"><table class=\"e-rte-table\" style=\"width:100%; min-width:0px; text-align:right; border: 1px solid black; border-collapse: collapse; font-size: 18pt;\">" +
                    "<tbody>";
                foreach (var comment in comments.Where(d => d.Body != "" && d.Body != null))
                {
                    //if (comment.Packages.Any(x => x.Recipint.Id == _currentUser.Id || x.Message.Sender.Id == _currentUser.Id))
                    //{
                    commentsList += $"<tr style=\"border: 1px solid black;\"><td style=\"width:50%;border: 1px solid black;\">{comment.OriginalBody}</td><td style=\"width: 13%;border: 1px solid black;\">{comment.SendingDateTime.Date:yyyy/MM/dd}</td><td style=\"width:37%;border: 1px solid black;\">{comment.SenderDiscription}</td></tr>";
                    //}
                    //else
                    //{
                    //    commentsList += $"<tr style=\"border: 1px solid black;\"><td style=\"width:50%;border: 1px solid black;\"><p>$$$$$$$$$$$$$$$$$$$$$$$</p></td><td style=\"width: 13%;border: 1px solid black;\">{comment.SendingDateTime.Date:yyyy/MM/dd}</td><td style=\"width:37%;border: 1px solid black;\">{comment.SenderDiscription}</td></tr>";
                    //}
                }
                commentsList += "</tbody></table><p><br></p></div>";
                //ViewData["Path"] = PrintCommentsAsync(_currentUser.FileNumber, commentsHeader + commentsList);
                commentsFilePath = PrintCommentsAsync(_currentUser.FileNumber, commentsHeader + commentsList);
            }
            else
            {
                commentsFilePath = "";
            }
            ///////////////////////////////////////////////////////////


            if (message.Body == "" || message.Body == null)
            {
                ViewData["Path"] = PDFMergeAndStamp(message.Documents.Where(d => d.IsTemp == false).OrderByDescending(y => y.CreatedOn).Select(r => r.Id.ToString()).ToList(), _currentSubUser is null ? _currentUser.FileNumber : _currentSubUser.FileNumber, comments, "");
            }
            else
            {
                var messageHeader = $"<br><br><br><br><br><br><p><span style=\"font-size: 18pt;\">&nbsp; &nbsp; &nbsp; {message.SendingDateTime:yyyy/MM/dd HH:mm}</span></p><p><span style=\"font-size: 18pt;\">&nbsp; &nbsp; &nbsp; {message.SerialNumber}</span></p><br><br><br><p style=\"text-align: center;\"><span style=\"font-size: 24pt;\"><strong>{message.Title}</strong></span></p>";

                ViewData["Path"] = PDFMergeAndStamp(message.Documents.Where(d => d.IsTemp == false).OrderByDescending(y => y.CreatedOn).Select(r => r.Id.ToString()).ToList(), _currentSubUser is null ? _currentUser.FileNumber : _currentSubUser.FileNumber, comments, messageHeader + "<div style=\"margin: 60px\">" + message.Body + "</div>");
            }

            return View(allMovements);
        }

        public async Task<IActionResult> Message(Guid Id)
        {
            await CheckAuthorization();

            BaseUser _currentSubUser = null;
            List<string> subUserRoles = null;
            if (_currentUser is SubApplicationUser)
            {
                _currentSubUser = _currentUser;
                subUserRoles = await _userProvider.GetUserRolesAsync(_currentSubUser);
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);
            }

            var OrgnaizationsResponsibilityCodes = (await _organizationServices.GetOrgnaizationsByFileNumber(_currentUser.FileNumber)).Select(d => d.ResponsibilityCode).ToList();
            var message = await _messageServices.GetMessageByIDWithDetails(Id);
            var packages = message.Packages.Where(a => a.RecipintId == _currentUser.Id || (a.ResponsibilityCode == _currentUser.ResponsibilityCode && a.DesignationId == _currentUser.DesignationId) || OrgnaizationsResponsibilityCodes.Contains(a.ResponsibilityCode)).ToList();

            if ((packages == null || packages.Count() == 0) && message.Sender.Id != _currentUser.Id && !OrgnaizationsResponsibilityCodes.Contains(message.ResponsibilityCode)
                && message.ResponsibilityCode != _currentUser.ResponsibilityCode && message.DesignationId != _currentUser.DesignationId)
            {
                return RedirectToAction("Error403", "Home");
            }
            else if (packages.Count() > 0 && message.Sender.Id != _currentUser.Id)
            {
                var package = packages.OrderByDescending(k => k.CreatedOn).FirstOrDefault();
                if (package.IsCC == false)
                {
                    if (_currentSubUser == null || (_currentSubUser != null && subUserRoles.Contains("FORWARD")))
                        ViewData["IsCommentable"] = true;
                    else
                        ViewData["IsCommentable"] = false;

                    //if (_currentSubUser == null || (_currentSubUser != null && subUserRoles.Contains("REPLY")))
                    //    ViewData["IsReplyable"] = true;
                    //else
                    //    ViewData["IsReplyable"] = false;
                }
                else
                {
                    //ViewData["IsReplyable"] = false;
                    if (_currentSubUser == null || (_currentSubUser != null && subUserRoles.Contains("FORWARD")))
                        ViewData["IsCommentable"] = true;
                    else
                        ViewData["IsCommentable"] = false;
                }
                foreach (var item in packages.Where(x => !x.IsReaded))
                    _packageServices.MarkMessageAsReadedOrUnreaded(item);
                ViewData["IsDeletable"] = true;
            }
            else if (message.Sender.Id == _currentUser.Id || OrgnaizationsResponsibilityCodes.Contains(message.ResponsibilityCode))
            {
                //ViewData["IsReplyable"] = false;
                if (_currentSubUser == null || (_currentSubUser != null && subUserRoles.Contains("FORWARD")))
                    ViewData["IsCommentable"] = true;
                else
                    ViewData["IsCommentable"] = false;
                ViewData["IsDeletable"] = false;
                //foreach (var item in packages.Where(x => !x.IsReaded))
                //    _packageServices.MarkMessageAsReadedOrUnreaded(item.Id.ToString()); 
            }
            //throw new UnAuthorizedException("UnAuthorized User");
            //return await RedirectByUserType();

            if (!message.IsOrigin)
            {
                message = await _messageServices.GetMessageByIDWithDetails(Guid.Parse(message.OriginMessageId));
            }

            ViewData["CurrentUserDesignationId"] = _currentUser.DesignationId;
            ViewData["CurrentUserResponsibilityCode"] = _currentUser.ResponsibilityCode;
            ViewData["CurrentUserJobtypeName"] = _currentUser.JobtypeName;
            ViewData["CurrentUserFileNumber"] = _currentUser.FileNumber;
            //ViewData["CurrentUserId"] = _currentUser.Id;
            //ViewData["IsReplyable"] = message.Sender.Id != _currentUser.Id;

            var allMovements = (await _messageServices.GetMessageMovements(message.Id.ToString())).ToList();
            var comments = allMovements.Where(x => x.IsOrigin == false).OrderBy(u => u.CreatedOn).ToList();


            ////////////////////////////////////////////////////////////
            var commentsFilePath = "";
            string commentsHeader = $"<div style=\"margin: 60px\"><br><br><p style=\"text-align: right;\"><span style=\"font-size: 18pt;\"><strong>عنوان المراسلة: {message.Title}</strong></span></p><p style=\"text-align: right;\"><span style=\"font-size: 18pt;\"><strong>تاريخ المراسلة: {message.SendingDateTime:yyyy/MM/dd HH:mm}</strong></span></p><p style=\"text-align: right;\"><span style=\"font-size: 18pt;\"><strong>الرقم الإشاري: {message.SerialNumber}</strong></span></p><br><br><br><br><p style=\"text-align: center;\"><span style=\"font-size: 24pt;\"><strong>التعليقات على المراسلة</strong></span></p></div>";


            if (comments.Where(d => d.Body != "" && d.Body != null).ToList().Count > 0)
            {
                string commentsList = "<div style=\"text-align:right;margin: 60px\"><table class=\"e-rte-table\" style=\"width:100%; min-width:0px; text-align:right; border: 1px solid black; border-collapse: collapse; font-size: 18pt;\">" +
                    "<tbody>";
                foreach (var comment in comments.Where(d => d.Body != "" && d.Body != null))
                {
                    //if (comment.Packages.Any(x => x.Recipint.Id == _currentUser.Id || x.Message.Sender.Id == _currentUser.Id))
                    //{
                    commentsList += $"<tr style=\"border: 1px solid black;\"><td style=\"width:50%;border: 1px solid black;\">{comment.OriginalBody}</td><td style=\"width: 13%;border: 1px solid black;\">{comment.SendingDateTime.Date:yyyy/MM/dd}</td><td style=\"width:37%;border: 1px solid black;\">{comment.SenderDiscription}</td></tr>";
                    //}
                    //else
                    //{
                    //    commentsList += $"<tr style=\"border: 1px solid black;\"><td style=\"width:50%;border: 1px solid black;\"><p>$$$$$$$$$$$$$$$$$$$$$$$</p></td><td style=\"width: 13%;border: 1px solid black;\">{comment.SendingDateTime.Date:yyyy/MM/dd}</td><td style=\"width:37%;border: 1px solid black;\">{comment.SenderDiscription}</td></tr>";
                    //}
                }
                commentsList += "</tbody></table><p><br></p></div>";
                //ViewData["Path"] = PrintCommentsAsync(_currentUser.FileNumber, commentsHeader + commentsList);
                commentsFilePath = PrintCommentsAsync(_currentUser.FileNumber, commentsHeader + commentsList);
            }
            else
            {
                commentsFilePath = "";
            }
            ///////////////////////////////////////////////////////////



            if (message.Body == "" || message.Body == null)
            {
                ViewData["Path"] = PDFMergeAndStamp(message.Documents.Where(d => d.IsTemp == false).OrderByDescending(y => y.CreatedOn).Select(r => r.Id.ToString()).ToList(), _currentSubUser is null ? _currentUser.FileNumber : _currentSubUser.FileNumber, comments, "", commentsFilePath);
            }
            else
            {
                var messageHeader = $"<br><br><br><br><br><br><p><span style=\"font-size: 18pt;\">&nbsp; &nbsp; &nbsp; {message.SendingDateTime:yyyy/MM/dd HH:mm}</span></p><p><span style=\"font-size: 18pt;\">&nbsp; &nbsp; &nbsp; {message.SerialNumber}</span></p><br><br><br><p style=\"text-align: center;\"><span style=\"font-size: 24pt;\"><strong>{message.Title}</strong></span></p>";

                ViewData["Path"] = PDFMergeAndStamp(message.Documents.Where(d => d.IsTemp == false).OrderByDescending(y => y.CreatedOn).Select(r => r.Id.ToString()).ToList(), _currentSubUser is null ? _currentUser.FileNumber : _currentSubUser.FileNumber, comments, messageHeader + "<div style=\"margin: 60px\">" + message.Body + "</div>", commentsFilePath);
            }


            return View(allMovements);
        }

        private string PrintCommentsAsync(string UserFileNumber, string body = "")
        {
            //Converting
            if (body == "" && body == null)
            {
                return "";
            }
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);
            WebKitConverterSettings settings = new WebKitConverterSettings
            {
                WebKitPath = Path.Combine(hostingEnv.WebRootPath + @"\QtBinariesDotNetCore\")
                ,
                Margin = new PdfMargins { All = 0 }
            };
            htmlConverter.ConverterSettings = settings;
            PdfDocument FinalDoc = htmlConverter.Convert(body, @"C:/");

            //QRcode
            PdfPage page = FinalDoc.Pages[0];
            PdfQRBarcode qrBarcode = new PdfQRBarcode
            {
                InputMode = InputMode.NumericMode
               ,
                Version = QRCodeVersion.Auto
               ,
                ErrorCorrectionLevel = PdfErrorCorrectionLevel.High
               ,
                XDimension = 2
               ,
                Text = UserFileNumber
               ,
                Size = new Syncfusion.Drawing.SizeF(30, 30)
            };
            qrBarcode.Draw(page, new Syncfusion.Drawing.PointF(0, 0));
            qrBarcode.Draw(page, new Syncfusion.Drawing.PointF(page.Size.Width - 30, page.Size.Height - 30));

            //Stamping
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 42f);
            PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 180f);
            foreach (PdfPageBase lPage in FinalDoc.Pages)
            {
                PdfGraphics graphics = lPage.Graphics;
                PdfGraphicsState state = graphics.Save();
                graphics.SetTransparency(0.25f);
                graphics.RotateTransform(-40);
                graphics.DrawString(UserFileNumber, font, PdfBrushes.Red, -50, 100);
                //graphics.DrawString(UserFileNumber, font, PdfBrushes.Red, 110, 250);
                graphics.SetTransparency(0.15f);
                graphics.DrawString(UserFileNumber, font2, PdfBrushes.Blue, -250, 390);
                graphics.Restore(state);
            }

            //Saving
            MemoryStream stream = new MemoryStream();
            FinalDoc.Save(stream);
            stream.Position = 0;
            FinalDoc.Close(true);
            var TempName = $@"\[{UserFileNumber}][{RandomString(15)}]" + ".pdf";
            using (var fileStream = new FileStream(Path.Combine(hostingEnv.WebRootPath + PathsProvider.TempFilesPath) + TempName, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }
            return PathsProvider.TempFilesPath + TempName;
        }

        public async Task<IActionResult> DeleteDraft(Guid Id)
        {
            //await CheckAuthorization();
            var message = await _messageServices.GetMessageByIDWithDetails(Id);
            _messageServices.DeleteMessageFromDrafts(message);
            return RedirectToAction("Inbox");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMessagesFromInbox(List<string> MessagesIds)
        {
            await CheckAuthorization();
            var OrgnaizationsResponsibilityCodes = (await _organizationServices.GetOrgnaizationsByFileNumber(_currentUser.FileNumber)).Select(d => d.ResponsibilityCode).ToList();
            foreach (var MessageId in MessagesIds)
            {
                var packagesIds = (await _messageServices.GetMessageByIDWithDetails(Guid.Parse(MessageId)))
                    .Packages.Where(d =>
                d.RecipintId == _currentUser.Id ||
                (d.ResponsibilityCode == _currentUser.ResponsibilityCode && d.DesignationId == _currentUser.DesignationId) ||
                OrgnaizationsResponsibilityCodes.Contains(d.ResponsibilityCode)
                ).Select(f => f.Id.ToString()).ToList();

                await _packageServices.DeleteMessagesFromInboxAsync(packagesIds);
            }
            return RedirectToAction("Inbox");
        }


        public async Task<IActionResult> DeleteMessage(string MessageId)
        {
            await CheckAuthorization();

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);
            var OrgnaizationsResponsibilityCodes = (await _organizationServices.GetOrgnaizationsByFileNumber(_currentUser.FileNumber)).Select(d => d.ResponsibilityCode).ToList();
            //foreach (var MessageId in MessagesIds)
            //{
            var packagesIds = (await _messageServices.GetMessageByIDWithDetails(Guid.Parse(MessageId)))
                .Packages.Where(d =>
            d.RecipintId == _currentUser.Id ||
            (d.ResponsibilityCode == _currentUser.ResponsibilityCode && d.DesignationId == _currentUser.DesignationId) ||
            OrgnaizationsResponsibilityCodes.Contains(d.ResponsibilityCode)
            ).Select(f => f.Id.ToString()).ToList();

            await _packageServices.DeleteMessagesFromInboxAsync(packagesIds);
            //}
            return RedirectToAction("Inbox");
        }

        public async Task<IActionResult> ForwardMessageAsync(Guid Id, string respCode, string designationId)
        {
            await CheckAuthorization();

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);

            var message = await _messageServices.GetMessageByIDWithDetails(Id);
            if (!message.IsOrigin)
            {
                message = await _messageServices.GetMessageByIDWithDetails(Guid.Parse(message.OriginMessageId));
            }

            if (message.SerialNumber != null)
            {
                var OrgnaizationsList = await _organizationServices.GetAllOrgnaizations();
                var result = OrgnaizationsList.FirstOrDefault(o => o.ResponsibilityCode == respCode && o.DesignationId.ToString() == designationId);
                List<BaseUser> users;
                if ((result == null) || (result != null && result.DesignationId != 0))
                {
                    //users = _userProvider.GetRelatedUsers(Int32.Parse(designationId), respCode);
                    users = _userProvider.GetAllUsers(_currentUser);
                    users.Remove(_currentUser);
                }
                else
                    users = _userProvider.GetAllLeaders(_currentUser);

                foreach (var org in OrgnaizationsList)
                {
                    var TempUser = _userProvider.GetUserByFileNumber(org.DelegateNo);
                    var user = new ApplicationUser
                    {
                        //Id = TempUser.Id,
                        Id = org.Id.ToString(),
                        FullName = TempUser.FullName,
                        JobtypeName = org.Name,
                        ResponsibilityCode = org.ResponsibilityCode
                    };
                    users.Add(user);
                }
                foreach (var user in users)
                {
                    //if (user.DesignationId != 0)
                    //{
                    //    user.ResponsibilityCode = user.ResponsibilityCode + "." + user.DesignationId;
                    //}
                    user.JobtypeName = user.FullName + " " + "-" + " " + user.JobtypeName;
                }
                ViewData["SenderDescription"] = _currentUser.JobtypeName;
                ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
                ViewData["Users"] = new SelectList(users, "Id", "JobtypeName");
            }
            else
            {
                ViewData["Users"] = new SelectList(_userProvider.GetAllUsers(_currentUser), "Id", "FullName");
                ViewData["SenderDescription"] = _currentUser.FullName;
            }
            ViewData["Title"] = message.Title;
            ViewData["OriginalMessageId"] = message.Id;
            return PartialView();
        }

        public IActionResult DownloadAttach(string fileName)
        {
            if (!String.IsNullOrEmpty(fileName))
            {
                DirectoryInfo dir = new DirectoryInfo(PathsProvider.TempAttachPath);
                var file = dir.GetFiles("*.*", SearchOption.AllDirectories).FirstOrDefault(j => j.Name.StartsWith(fileName));
                if (file == null)
                {
                    dir = new DirectoryInfo(PathsProvider.FilesPath);
                    file = dir.GetFiles("*.*", SearchOption.AllDirectories).FirstOrDefault(j => j.Name.StartsWith(fileName));
                }
                if (file == null)
                {
                    return NoContent();
                }
                else
                {
                    if (System.IO.File.Exists(file.FullName))
                    {
                        string originalName = _DocServices.GetOriginalDocName(file.Name.Split(".").FirstOrDefault());
                        byte[] fileBytes = System.IO.File.ReadAllBytes(file.FullName);
                        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, originalName);
                    }
                    else
                    {
                        return NoContent();
                    }
                }
            }
            else
            {
                return NoContent();
            }
        }


        public async Task<IActionResult> DeleteAttachAsync(string fileName)
        {
            if (!String.IsNullOrEmpty(fileName))
            {
                var doc = await _DocServices.GetDocByID(Guid.Parse(fileName));
                _DocServices.DeleteDoc(doc);

                DirectoryInfo dir = new DirectoryInfo(PathsProvider.TempAttachPath);
                var file = dir.GetFiles("*.*", SearchOption.AllDirectories).FirstOrDefault(j => j.Name.StartsWith(fileName));
                if (file == null)
                {
                    dir = new DirectoryInfo(PathsProvider.FilesPath);
                    file = dir.GetFiles("*.*", SearchOption.AllDirectories).FirstOrDefault(j => j.Name.StartsWith(fileName));
                }
                if (System.IO.File.Exists(file.FullName))
                {
                    file.Delete();
                    return NoContent();
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return NoContent();
            }
        }

        private string PDFMergeAndStamp(List<string> FilesNames, string UserFileNumber, List<MessageDTO> comments, string OrigenalMessageBody = "", string commentsFilePath = "")
        {
            PdfDocument FinalDoc = new PdfDocument();

            //Converting
            if (OrigenalMessageBody != "" && OrigenalMessageBody != null)
            {
                HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);
                WebKitConverterSettings settings = new WebKitConverterSettings
                {
                    WebKitPath = Path.Combine(hostingEnv.WebRootPath + @"\QtBinariesDotNetCore\")
                    ,
                    Margin = new PdfMargins { All = 0 }
                };
                htmlConverter.ConverterSettings = settings;
                FinalDoc = htmlConverter.Convert(OrigenalMessageBody, @"C:/");
            }

            //AddTemplate
            //Header
            //FileStream docStream = new FileStream(hostingEnv.WebRootPath + $@"\header.jpg", FileMode.Open, FileAccess.Read);
            //RectangleF bounds = new RectangleF(0, 0, FinalDoc.Pages[0].GetClientSize().Width, 350);
            //PdfPageTemplateElement header = new PdfPageTemplateElement(bounds);
            //PdfImage image = new PdfBitmap(docStream);
            //header.Graphics.DrawImage(image, new PointF(0, 0), new SizeF(FinalDoc.Pages[0].Size.Width, FinalDoc.Pages[0].Size.Height / 5));
            //FinalDoc.Template.Top = header;

            //Footer
            //bounds = new RectangleF(0, FinalDoc.Pages[0].Size.Height - 750, FinalDoc.Pages[0].GetClientSize().Width, 130);
            //docStream = new FileStream(hostingEnv.WebRootPath + $@"\footer.jpg", FileMode.Open, FileAccess.Read);
            //PdfPageTemplateElement footer = new PdfPageTemplateElement(bounds);
            //image = new PdfBitmap(docStream);
            //footer.Graphics.DrawImage(image, new PointF(0, FinalDoc.Pages[0].Size.Height - 750), new SizeF(FinalDoc.Pages[0].Size.Width, 40));
            //FinalDoc.Template.Bottom = footer;

            /////////////////////////////////////////
            //PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
            //PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;
            //PdfTemplate template = loadedPage.CreateTemplate();
            //FinalDoc.PageSettings.SetMargins(2);
            //PdfGraphics graphic = page.Graphics;
            //graphic.DrawPdfTemplate(template, PointF.Empty, new SizeF(page.Size.Width, page.Size.Height));
            //loadedDocument.Close(true);
            //////////////////////////////////////////

            //FilesGetting
            //List<object> dobj = new List<object>();
            foreach (var fileName in FilesNames)
            {//hostingEnv.WebRootPath + 
                FileStream file = new FileStream(PathsProvider.FilesPath + $@"\{fileName}" + ".PDF", FileMode.Open, FileAccess.Read);
                PdfLoadedDocument doc = new PdfLoadedDocument(file);
                FinalDoc.ImportPageRange(doc, 0, doc.Pages.Count - 1);
                //dobj.Add(doc);
                //doc.Close();
            }

            foreach (var comment in comments.Where(d => d.Body == "" || d.Body == null))
            {
                PdfLoadedDocument doc = new PdfLoadedDocument(new FileStream(PathsProvider.FilesPath + $@"\{comment.Documents.FirstOrDefault().Id}" + ".pdf", FileMode.Open, FileAccess.Read));
                FinalDoc.ImportPageRange(doc, 0, doc.Pages.Count - 1);
            }

            if (commentsFilePath != "")
            {
                FileStream commentsFile = new FileStream(Path.Combine(hostingEnv.WebRootPath + commentsFilePath), FileMode.Open, FileAccess.Read);
                PdfLoadedDocument doc = new PdfLoadedDocument(commentsFile);
                FinalDoc.ImportPage(doc, doc.Pages.Count - 1);
            }

            //Comments
            //foreach (var comment in comments)
            //{
            //    if (comment.Body != "" && comment.Body != null)
            //    {
            //string recipints = "<div style=\"position:relative; font-size:22px; text-align:center;\">";
            //foreach (var recipint in comment.Packages)
            //{
            //    recipints += $"السيد: {recipint.RecipintDiscription}<br>";
            //}
            //recipints += "</div>";
            //string commentString = $"<div style=\"position:absolute; bottom:30px; color:blue; font-size:22px; text-align:center; width:40%;border:1px solid green; margin-left:20px;\">{recipints}<p dir=\"rtl\" style=\"color:black;\"><i>{comment.Body}</i></p><p>{comment.SendingDateTime.Date:yyyy/MM/dd}<br>{comment.SenderDiscription}</p></div>";

            //HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);
            //htmlConverter.ConverterSettings = new WebKitConverterSettings
            //{
            //    WebKitPath = Path.Combine(hostingEnv.WebRootPath + @"\QtBinariesDotNetCore\")
            //    ,
            //    Margin = new PdfMargins { All = 0 }
            //};
            //var newPage = htmlConverter.Convert(commentString, @"C:/");

            //MemoryStream pdfGenerated = new MemoryStream();
            //FinalDoc.Save(pdfGenerated);
            //PdfTemplate backgroundTemplate = (new PdfLoadedDocument(pdfGenerated).Pages[0] as PdfLoadedPage).CreateTemplate();

            //pdfGenerated = new MemoryStream();
            //newPage.Save(pdfGenerated);
            //newPage.Close(true);
            //PdfLoadedDocument ldDoc = new PdfLoadedDocument(pdfGenerated);

            //foreach (PdfPageBase p in ldDoc.Pages)
            //{
            //    PdfGraphics graphics = p.Graphics;
            //    graphics.SetTransparency(0.25f);
            //    p.Graphics.DrawPdfTemplate(backgroundTemplate, new Syncfusion.Drawing.PointF(0, 0), p.Size);
            //    graphics.Restore();
            //}
            //FinalDoc.ImportPage(ldDoc, 0);
            //    }
            //    else
            //    {
            //        PdfLoadedDocument doc = new PdfLoadedDocument(new FileStream(PathsProvider.FilesPath + $@"\{comment.Documents.FirstOrDefault().Id}" + ".pdf", FileMode.Open, FileAccess.Read));
            //        FinalDoc.ImportPageRange(doc, 0, doc.Pages.Count - 1);
            //    }
            //}

            //QRcode
            PdfPage page = FinalDoc.Pages[0];
            PdfQRBarcode qrBarcode = new PdfQRBarcode
            {
                InputMode = InputMode.NumericMode
               ,
                Version = QRCodeVersion.Auto
               ,
                ErrorCorrectionLevel = PdfErrorCorrectionLevel.High
               ,
                XDimension = 2
               ,
                Text = UserFileNumber
               ,
                Size = new Syncfusion.Drawing.SizeF(30, 30)
            };
            qrBarcode.Draw(page, new Syncfusion.Drawing.PointF(0, 0));
            qrBarcode.Draw(page, new Syncfusion.Drawing.PointF(page.Size.Width - 30, page.Size.Height - 30));

            //Mergeing
            //if (dobj.Count > 0)
            //{
            //    PdfMergeOptions mergeOption = new PdfMergeOptions
            //    {
            //        OptimizeResources = true
            //    };
            //    PdfDocumentBase.Merge(FinalDoc, mergeOption, dobj.ToArray());
            //}

            //Stamping
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 42f);
            PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 180f);
            foreach (PdfPageBase lPage in FinalDoc.Pages)
            {
                PdfGraphics graphics = lPage.Graphics;
                PdfGraphicsState state = graphics.Save();
                graphics.SetTransparency(0.25f);
                graphics.RotateTransform(-40);
                graphics.DrawString(UserFileNumber, font, PdfBrushes.Red, -50, 100);
                //graphics.DrawString(UserFileNumber, font, PdfBrushes.Red, 110, 250);
                graphics.SetTransparency(0.15f);
                graphics.DrawString(UserFileNumber, font2, PdfBrushes.Blue, -250, 390);
                graphics.Restore(state);
            }
            //}
            //else if (IsDraft == true)
            //{
            //    foreach (var fileName in FilesNames)
            //    {//hostingEnv.WebRootPath + 
            //        FileStream file = new FileStream(PathsProvider.FilesPath + $@"\{fileName}" + ".pdf", FileMode.Open, FileAccess.Read);
            //        PdfLoadedDocument doc = new PdfLoadedDocument(file);
            //        FinalDoc.ImportPageRange(doc, 0, doc.Pages.Count - 1);
            //        //dobj.Add(doc);
            //        //doc.Close();
            //    }
            //}

            //Saving
            MemoryStream stream = new MemoryStream();
            FinalDoc.Save(stream);
            stream.Position = 0;
            FinalDoc.Close(true);
            var TempName = $@"\[{UserFileNumber}][{RandomString(15)}]" + ".pdf";
            using (var fileStream = new FileStream(Path.Combine(hostingEnv.WebRootPath + PathsProvider.TempFilesPath) + TempName, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }
            return PathsProvider.TempFilesPath + TempName;
        }

        private static string RandomString(int number)
        {
            return new string(Enumerable.Repeat("123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", number)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }

        public async Task<IActionResult> Search(string KeyWords, bool MessageTypeOut, bool MessageTypeIn, string MessageYear = null, string MessageSerialNo = null, string MessageTitle = null, string MessageBody = null, string MessageOrgnization = null, List<string> MessageCategories = null, int pageindex = 1)
        {
            await CheckAuthorization();

            if (_currentUser is SubApplicationUser)
                _currentUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);

            ViewData["KeyWord"] = KeyWords;
            var messages = await _messageServices.SearchPagingAsync(KeyWords, _currentUser.Id, _currentUser.ResponsibilityCode, _currentUser.DesignationId, _currentUser.JobCatId.ToString(), MessageYear, MessageSerialNo, MessageTitle, MessageBody, MessageTypeOut, MessageTypeIn, MessageOrgnization, MessageCategories, pageindex);
            ViewData["Categories"] = new SelectList(await _categoryServices.GetAllCategories(), "Id", "Name");
            return View(messages);
        }

        //---------------------------------------------------------------------------------
        [AcceptVerbs("Post")]
        public IActionResult SaveTempFile(IList<IFormFile> UploadTempFiles)
        {
            //try
            //{
            if (UploadTempFiles != null)
            {
                foreach (var file in UploadTempFiles)
                {
                    var extension = Path.GetExtension(file.FileName).ToLower();

                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    filename = PathsProvider.TempAttachPath + $@"\{filename}";
                    using (FileStream fs = System.IO.File.Create(filename))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }
            }
            return Content("");
        }

        [AcceptVerbs("Post")]
        public IActionResult SaveFile(IList<IFormFile> UploadFiles)
        {
            //try
            //{
            if (UploadFiles != null)
            {
                foreach (var file in UploadFiles)
                {
                    var extension = Path.GetExtension(file.FileName).ToLower();
                    if (extension.ToLower() == ".docx" || extension.ToLower() == ".doc")
                    {
                        //Open the file as Stream
                        FileStream docStream = System.IO.File.Create(hostingEnv.WebRootPath + PathsProvider.TempFilesPath + @"\" + file.FileName);
                        file.CopyTo(docStream);
                        //Loads file stream into Word document
                        WordDocument wordDocument = new WordDocument(docStream, FormatType.Automatic);
                        //Instantiation of DocIORenderer for Word to PDF conversion
                        DocIORenderer render = new DocIORenderer();
                        //Sets Chart rendering Options.
                        render.Settings.ChartRenderingOptions.ImageFormat = ExportImageFormat.Jpeg;
                        //Converts Word document into PDF document
                        PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);
                        //Releases all resources used by the Word document and DocIO Renderer objects
                        string tempFilePath = docStream.Name;
                        render.Dispose();
                        wordDocument.Dispose();

                        //Saves the PDF file

                        //hostingEnv.WebRootPath + 
                        var path = (PathsProvider.FilesPath + $@"\{ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"').Split(".").FirstOrDefault()}" + ".pdf");

                        FileStream outputStream = System.IO.File.Create(path);
                        pdfDocument.Save(outputStream);
                        //Closes the instance of PDF document object
                        pdfDocument.Close(); pdfDocument.Dispose();
                        outputStream.Close(); outputStream.Dispose(); //outputStream.Flush();
                        docStream.Close(); docStream.Dispose(); //docStream.Flush();
                        System.IO.File.Delete(tempFilePath);
                    }
                    else if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
                    {
                        FileStream docStream = System.IO.File.Create(hostingEnv.WebRootPath + PathsProvider.TempFilesPath + @"\" + file.FileName);
                        file.CopyTo(docStream);

                        var fileName = (PathsProvider.FilesPath + $@"\{ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"').Split(".").FirstOrDefault()}" + ".pdf");
                        string imageName = docStream.Name;
                        docStream.Close(); docStream.Dispose();
                        PdfHelper.Instance.SaveImageAsPdf($"{imageName}", $"{fileName}", 600, true);

                    }
                    else
                    {//hostingEnv.WebRootPath + 
                        var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        filename = PathsProvider.FilesPath + $@"\{filename}";
                        using (FileStream fs = System.IO.File.Create(filename))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }
                }
            }
            //}
            //catch (Exception e)
            //{
            //    Response.Clear();
            //    Response.ContentType = "application/json; charset=utf-8";
            //    Response.StatusCode = 204;
            //    Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "No Content";
            //    Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            //}
            return Content("");
        }

        //[AcceptVerbs("Post")]
        //public IActionResult RemoveFile(IList<IFormFile> UploadFiles)
        //{
        //    try
        //    {
        //        foreach (var file in UploadFiles)
        //        {//hostingEnv.WebRootPath + 
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var filePath = Path.Combine(PathsProvider.FilesPath);
        //            var fileSavePath = filePath + "\\" + fileName;
        //            if (System.IO.File.Exists(fileSavePath))
        //            {
        //                System.IO.File.Delete(fileSavePath);
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Response.Clear();
        //        Response.StatusCode = 200;
        //        Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File removed successfully";
        //        Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
        //    }
        //    return Content("");
        //}

        public IActionResult DefaultFunctionalities()
        {
            return View();
        }

        //=======================================================================
        public async Task<IActionResult> InboxClassification(string ResponsibilityCodes = "46120")
        {
            await CheckAuthorization();

            var messages = await _messageServices.GetInboxMessagesClassificationAsync(_currentUser, ResponsibilityCodes, 1);
            //ViewData["CurrentUserId"] = _currentUser.Id;
            //ViewData["CurrentUserResponsibilityCode"] = _currentUser.ResponsibilityCode;
            messages.Action = "InboxClassification";
            return View(messages);
        }

        public async Task<IActionResult> OutboxClassification(string ResponsibilityCodes = "46120")
        {
            await CheckAuthorization();
            var messages = await _messageServices.GetOutboxMessagesClassificationAsync(_currentUser, ResponsibilityCodes, 1);
            //ViewData["CurrentUserId"] = _currentUser.Id;
            //ViewData["CurrentUserResponsibilityCode"] = _currentUser.ResponsibilityCode;
            messages.Action = "OutboxClassification";
            return View(messages);
        }

    }
}
