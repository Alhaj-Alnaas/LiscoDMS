using ACS.Controllers;
using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.Core.Interfaces.Providers;
using ACS.Core.Interfaces.Services;
using ACS.Web.Providers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Syncfusion.Pdf;
using Syncfusion.HtmlConverter;
using System.IO;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Barcode;
using Syncfusion.Pdf.Parsing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ACS.Web.Controllers
{
    [Authorize]
    public class SubUsersController : BaseController<SubApplicationUser>
    {
        private static Random random = new Random();
        private readonly IDocServices<Doc> _DocServices;
        private readonly IMessagesServices<Message> _messageServices;
        private readonly ICategoryServices<Category> _categoryServices;
        private readonly IOrgnaizationServices<Organization> _organizationServices;
        protected readonly IUserProvider _userProvider;
        private readonly IPackageServices<Package> _packageServices;
        private readonly IWebHostEnvironment hostingEnv;

        public SubUsersController(
            UserManager<BaseUser> userManager
            , ICategoryServices<Category> categoryServices
            , IMessagesServices<Message> messageServices
            , IOrgnaizationServices<Organization> organizationServices
            , IUserProvider userProvider
            , IPackageServices<Package> packageServices
            , IDocServices<Doc> DocServices
            , IWebHostEnvironment env
            ) : base(userManager)
        {
            _categoryServices = categoryServices;
            _messageServices = messageServices;
            _organizationServices = organizationServices;
            _userProvider = userProvider;
            _packageServices = packageServices;
            _DocServices = DocServices;
            this.hostingEnv = env;
        }

        [Authorize(Roles = "FORWARD")]
        public async Task<IActionResult> ForwardMessageAsync(Guid Id, string respCode, string designationId)
        {
            await CheckAuthorization();

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
                        Id = TempUser.Id,
                        FullName = TempUser.FullName,
                        JobtypeName = org.Name,
                        ResponsibilityCode = org.ResponsibilityCode
                    };
                    users.Add(user);
                }
                foreach (var user in users)
                {
                    if (user.DesignationId != 0)
                    {
                        user.ResponsibilityCode = user.ResponsibilityCode + "." + user.DesignationId;
                    }
                    user.JobtypeName = user.FullName + " " + "-" + " " + user.JobtypeName;
                }
                ViewData["SenderDescription"] = _currentUser.JobtypeName;
                ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
                ViewData["Users"] = new SelectList(users, "ResponsibilityCode", "JobtypeName");
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

        [Authorize(Roles = "REPLY")]
        public async Task<IActionResult> ReplyMessageAsync(Guid Id)
        {
            await CheckAuthorization();
            //Log.Logger.Information($"Get into inbox: User {_userProvider.GetCurrentUserName()}.");
            var OriginalMessage = await _messageServices.GetMessageByIDWithDetails(Id);

            ViewBag.items = RichTextEditorToolsProvider.RichTextEditorToolBar;
            ViewData["OriginalMessageId"] = OriginalMessage.Id.ToString();
            ViewData["MessageTitle"] = " رد على: " + OriginalMessage.Title;

            if (OriginalMessage.SerialNumber != null)
            {
                var OrgnaizationsList = await _organizationServices.GetAllOrgnaizations();
                //var users = _userProvider.GetRelatedUsers(_currentUser.DesignationId, _currentUser.ResponsibilityCode);
                var users = _userProvider.GetAllUsers(_currentUser);

                foreach (var org in OrgnaizationsList)
                {
                    var TempUser = _userProvider.GetUserByFileNumber(org.DelegateNo);
                    ApplicationUser user = new ApplicationUser
                    {
                        Id = TempUser.Id,
                        FullName = TempUser.FullName,
                        JobtypeName = org.Name,
                        ResponsibilityCode = org.ResponsibilityCode
                    };
                    users.Add(user);
                }
                users.Remove(_currentUser);
                foreach (var user in users)
                {
                    if (user.DesignationId != 0)
                    {
                        user.ResponsibilityCode = user.ResponsibilityCode + "." + user.DesignationId;
                    }
                    user.JobtypeName = user.FullName + " " + "-" + " " + user.JobtypeName;
                }

                //ViewData["sn"] = await _messageServices.GetLastSerialNumber(_currentUser.ResponsibilityCode, _currentUser.DesignationId);
                ViewData["Users"] = new SelectList(users, "ResponsibilityCode", "JobtypeName");

                var RelatedSender = _userProvider.GetUserById((await _messageServices.GetMessageMovements(OriginalMessage.Id.ToString())).FirstOrDefault(u => u.Packages.Any(o => o.RecipintId == _currentUser.Id)).SenderId) as ApplicationUser;

                ViewData["SenderId"] = RelatedSender.ResponsibilityCode + "." + RelatedSender.DesignationId.ToString();
                ViewData["SenderName"] = RelatedSender.JobtypeName;

                ViewData["SenderDescription"] = _currentUser.JobtypeName;
                ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
            }
            else
            {
                ViewData["Users"] = new SelectList(_userProvider.GetAllUsers(_currentUser), "Id", "FullName");
                ViewData["SenderId"] = OriginalMessage.Sender.Id;
                ViewData["SenderName"] = OriginalMessage.Sender.FullName;
                ViewData["SenderDescription"] = _currentUser.FullName;
                //ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
            }
            return View();
        }





        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////
        /// </summary>



        [Authorize(Roles = "INBOX")]
        public async Task<IActionResult> Inbox(int pageindex = 1)
        {
            //Log.Logger.Information($"Get into inbox: User {_userProvider.GetCurrentUserName()}.");
            await CheckAuthorization();
            var applicationUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);

            var OrgnaizationsResponsibilityCodes = (await _organizationServices.GetOrgnaizationsByFileNumber(applicationUser.FileNumber)).Select(d => d.ResponsibilityCode).ToList();
            var messages = await _messageServices.GetInboxMessagesPagingAsync(applicationUser, OrgnaizationsResponsibilityCodes, pageindex);
            ViewData["CurrentUserId"] = applicationUser.Id;
            ViewData["CurrentUserResponsibilityCode"] = _currentUser.ResponsibilityCode;
            messages.Action = "Inbox";
            return View(messages);
        }

        public async Task<IActionResult> Drafts(int pageindex = 1)
        {
            await CheckAuthorization();
            //Log.Logger.Information($"Get into inbox: User {_userProvider.GetCurrentUserName()}.");
            var applicationUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);
            var messages = await _messageServices.GetDraftMessagesPagingAsync(applicationUser, pageindex);
            messages.Action = "Drafts";
            return View(messages);
        }

        [Authorize(Roles = "OUTBOX")]
        public async Task<IActionResult> Outbox(int pageindex = 1)
        {
            await CheckAuthorization();
            var applicationUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);
            var OrgnaizationsResponsibilityCodes = (await _organizationServices.GetOrgnaizationsByFileNumber(applicationUser.FileNumber)).Select(d => d.ResponsibilityCode).ToList();
            //Log.Logger.Information($"Get into inbox: User {_userProvider.GetCurrentUserName()}.");
            //return View((await _messageServices.GetOutboxMessages(_userProvider.GetCurrentUserId())).ToList());
            var messages = await _messageServices.GetOutboxMessagesPagingAsync(applicationUser, OrgnaizationsResponsibilityCodes, pageindex);
            messages.Action = "Outbox";
            return View(messages);
        }

        [Authorize(Roles = "SEARCH")]
        public async Task<IActionResult> Search(string KeyWords, bool MessageTypeOut, bool MessageTypeIn, string MessageYear = null, string MessageSerialNo = null, string MessageTitle = null, string MessageBody = null, string MessageOrgnization = null, List<string> MessageCategories = null, int pageindex = 1)
        {
            await CheckAuthorization();
            var applicationUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);

            ViewData["KeyWord"] = KeyWords;
            var messages = await _messageServices.SearchPagingAsync(KeyWords, applicationUser.Id, applicationUser.ResponsibilityCode, applicationUser.DesignationId, applicationUser.JobCatId.ToString(), MessageYear, MessageSerialNo, MessageTitle, MessageBody, MessageTypeOut, MessageTypeIn, MessageOrgnization, MessageCategories, pageindex);
            ViewData["Categories"] = new SelectList(await _categoryServices.GetAllCategories(), "Id", "Name");
            return View(messages);
        }

        public async Task<IActionResult> Message(Guid Id)
        {
            await CheckAuthorization();
            var applicationUser = _userProvider.GetUserBySubUserFileNumber(_currentUser.FileNumber);
            var message = await _messageServices.GetMessageByIDWithDetails(Id);
            var packages = message.Packages.Where(a => a.RecipintId == applicationUser.Id || (a.ResponsibilityCode == applicationUser.ResponsibilityCode && a.DesignationId == applicationUser.DesignationId)).ToList();
            if ((packages == null || packages.Count() == 0) && message.Sender.Id != applicationUser.Id)
                return RedirectToAction("Error403", "Home");

            if (!message.IsOrigin)
            {
                message = await _messageServices.GetMessageByIDWithDetails(Guid.Parse(message.OriginMessageId));
            }

            ViewData["CurrentUserId"] = _currentUser.Id;

            if (message.Body == "" || message.Body == null)
            {
                ViewData["Path"] = PDFMergeAndStamp(message.Documents.Where(d => d.IsTemp == false).OrderByDescending(y => y.CreatedOn).Select(r => r.Id.ToString()).ToList(), _currentUser.FileNumber, "");
            }
            else
            {
                var messageHeader = $"<br><br><br><br><br><br><p><span style=\"font-size: 18pt;\">&nbsp; &nbsp; &nbsp; {message.SendingDateTime:yyyy/MM/dd HH:mm}</span></p><p><span style=\"font-size: 18pt;\">&nbsp; &nbsp; &nbsp; {message.SerialNumber}</span></p><br><br><br><p style=\"text-align: center;\"><span style=\"font-size: 24pt;\"><strong>{message.Title}</strong></span></p>";

                ViewData["Path"] = PDFMergeAndStamp(message.Documents.Where(d => d.IsTemp == false).OrderByDescending(y => y.CreatedOn).Select(r => r.Id.ToString()).ToList(), _currentUser.FileNumber, messageHeader + "<div style=\"margin: 60px\">" + message.Body + "</div>");
            }

            ////////////////////////////////////////////////////////////
            string commentsHeader = $"<div style=\"margin: 60px\"><br><br><p style=\"text-align: right;\"><span style=\"font-size: 18pt;\"><strong>عنوان المراسلة: {message.Title}</strong></span></p><p style=\"text-align: right;\"><span style=\"font-size: 18pt;\"><strong>تاريخ المراسلة: {message.SendingDateTime:yyyy/MM/dd HH:mm}</strong></span></p><p style=\"text-align: right;\"><span style=\"font-size: 18pt;\"><strong>الرقم الإشاري: {message.SerialNumber}</strong></span></p><br><br><br><br><p style=\"text-align: center;\"><span style=\"font-size: 24pt;\"><strong>التعليقات على المراسلة</strong></span></p></div>";
            var allMovements = (await _messageServices.GetMessageMovements(message.Id.ToString())).ToList();
            var comments = allMovements.Where(x => x.IsOrigin == false).OrderBy(u => u.CreatedOn).ToList();
            if (comments.Count > 0)
            {
                string commentsList = "<div style=\"text-align:right;margin: 60px\"><table class=\"e-rte-table\" style=\"width:100%; min-width:0px; text-align:right; border: 1px solid black; border-collapse: collapse; font-size: 18pt;\"><tbody>";
                foreach (var comment in comments)
                {
                    if (comment.Packages.Any(x => x.Recipint.Id == _currentUser.Id || x.Message.Sender.Id == _currentUser.Id))
                    {
                        commentsList += $"<tr style=\"border: 1px solid black;\"><td style=\"width:50%;border: 1px solid black;\">{comment.OriginalBody}</td><td style=\"width: 13%;border: 1px solid black;\">{comment.SendingDateTime.Date:yyyy/MM/dd}</td><td style=\"width:37%;border: 1px solid black;\">{comment.SenderDiscription}</td></tr>";
                    }
                    else
                    {
                        commentsList += $"<tr style=\"border: 1px solid black;\"><td style=\"width:50%;border: 1px solid black;\"><p>$$$$$$$$$$$$$$$$$$$$$$$</p></td><td style=\"width: 13%;border: 1px solid black;\">{comment.SendingDateTime.Date:yyyy/MM/dd}</td><td style=\"width:37%;border: 1px solid black;\">{comment.SenderDiscription}</td></tr>";
                    }
                }
                commentsList += "</tbody></table><p><br></p></div>";
                ViewData["CommentsPath"] = PrintCommentsAsync(_currentUser.FileNumber, commentsHeader + commentsList);
            }
            else
            {
                ViewData["CommentsPath"] = "";
            }
            ///////////////////////////////////////////////////////////

            return View(allMovements);
        }

        public async Task<IActionResult> EditDraft(Guid Id)
        {
            await CheckAuthorization();

            var message = await _messageServices.GetMessageByIDWithDetails(Id);

            ViewBag.items = RichTextEditorToolsProvider.RichTextEditorToolBar;
            ViewData["MessageTitle"] = message.Title;
            ViewData["CurrentUserFileNumber"] = _currentUser.FileNumber;
            ViewData["JobCatId"] = _currentUser.JobCatId;
            ViewData["messageId"] = message.Id;
            return View(message);
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
                        byte[] fileBytes = System.IO.File.ReadAllBytes(file.FullName);
                        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, file.Name);
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
                Size = new SizeF(30, 30)
            };
            qrBarcode.Draw(page, new PointF(0, 0));
            qrBarcode.Draw(page, new PointF(page.Size.Width - 30, page.Size.Height - 30));

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
            var TempName = $@"\[{UserFileNumber}][{ RandomString(15) }]" + ".pdf";
            using (var fileStream = new FileStream(Path.Combine(hostingEnv.WebRootPath + PathsProvider.TempFilesPath) + TempName, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }
            return PathsProvider.TempFilesPath + TempName;
        }

        private string PDFMergeAndStamp(List<string> FilesNames, string UserFileNumber, string OrigenalMessageBody = "")
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

            //FilesGetting
            foreach (var fileName in FilesNames)
            {//hostingEnv.WebRootPath + 
                FileStream file = new FileStream(PathsProvider.FilesPath + $@"\{fileName}" + ".pdf", FileMode.Open, FileAccess.Read);
                PdfLoadedDocument doc = new PdfLoadedDocument(file);
                FinalDoc.ImportPageRange(doc, 0, doc.Pages.Count - 1);
            }

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
                Size = new SizeF(30, 30)
            };
            qrBarcode.Draw(page, new PointF(0, 0));
            qrBarcode.Draw(page, new PointF(page.Size.Width - 30, page.Size.Height - 30));

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
            var TempName = $@"\[{UserFileNumber}][{ RandomString(15) }]" + ".pdf";
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

        public async Task<IActionResult> CreateDraft()
        {
            await CheckAuthorization();
            //ViewData["SenderDescription"] = CurrentSubUser.Id;
            ViewData["SenderResponsibilityCode"] = _currentUser.ResponsibilityCode;
            ViewBag.items = RichTextEditorToolsProvider.RichTextEditorToolBar;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewDraftAsync([FromBody] Message message)
        {
            await CheckAuthorization();
            _messageServices.NewMessage(message);
            message.OriginMessageId ??= message.Id.ToString();
            message.IsOrigin = true;
            foreach (var doc in message.Documents)
            {
                doc.CreatedBy = _currentUser;
                doc.CreatedById = _currentUser.Id;
            }
            _messageServices.UpdateMessage(message);
            return RedirectToAction("CreateDraft", "SubUsers");
        }

        public async Task<IActionResult> DeleteDraft(Guid Id)
        {
            //await CheckAuthorization();
            var message = await _messageServices.GetMessageByIDWithDetails(Id);
            _messageServices.DeleteMessageFromDrafts(message);
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
    }
}
