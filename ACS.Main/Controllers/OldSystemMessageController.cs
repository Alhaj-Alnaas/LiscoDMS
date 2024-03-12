using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SearchInOldSystem.Services;
using ACS.Core.Interfaces.Providers;
using Microsoft.AspNetCore.Authorization;
using SearchInOldSystem.DatabaseEntity;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using ACS.Web.Providers;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using System.Threading.Tasks;
using ACS.Core.Entities;
using System;

namespace ACS.Web.Controllers
{
    [Authorize]
    public class OldSystemMessageController : Controller
    {
        private static Random random = new Random();
        protected readonly IOldSystemMessages _messageServices;
        protected readonly IUserProvider _userProvider;
        private IWebHostEnvironment hostingEnv;
        public OldSystemMessageController(IOldSystemMessages messageServices, IUserProvider userProvider, IWebHostEnvironment env)
        {
            _messageServices = messageServices;
            _userProvider = userProvider;
            this.hostingEnv = env;
        }
        
        [HttpGet]
        public async Task<PartialViewResult> OldMessagesPartialAsync(bool MessageTypeOut, bool MessageTypeIn, DateTime StartDate, DateTime EndDate, string LtrYear = "2021", string LtrNo = null, string LtrTitle = null, string MessageOrgnaization = null)
        {
            var User = await _userProvider.GetCurrentUserAsync();
            ViewData["ResponsibilityCode"] = User.ResponsibilityCode;
            if ((User is ApplicationUser && User.JobCatId == 1) || User is SubApplicationUser)
            {
                var v = _messageServices.GetOldMessages(User.ResponsibilityCode, LtrYear, LtrNo, LtrTitle, MessageTypeOut, MessageTypeIn, MessageOrgnaization, StartDate, EndDate);
                return PartialView("_OldMessagesPartial", _messageServices.GetOldMessages(User.ResponsibilityCode, LtrYear, LtrNo, LtrTitle, MessageTypeOut, MessageTypeIn,  MessageOrgnaization, StartDate, EndDate));
            }
            else
            {
                return PartialView("_OldMessagesPartial", new List<PostSendr>());
            }
        }
        public IActionResult ShowOldMessages()
        {
            return View();
        }


        public IActionResult ShowMessageDetails(string id, int LtrYear = 2021)
        {
            List<object> dobj = new List<object>();
            var UserFileNumber = _userProvider.GetCurrentUserAsync().Result.FileNumber;

            List<Employees> MessageDocs = _messageServices.GetOldMessageDoc(id, LtrYear);
            foreach (var doc in MessageDocs)
            {
                PdfDocument document = new PdfDocument();
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                MemoryStream Stream = new MemoryStream(doc.Photo);
                PdfBitmap image = new PdfBitmap(Stream);
                graphics.DrawImage(image, new Syncfusion.Drawing.PointF(0,0), new Syncfusion.Drawing.SizeF(page.Size.Width, page.Size.Height));
                MemoryStream Stream2 = new MemoryStream();
                document.Save(Stream2);
                Stream2.Position = 0;
                document.Close(true);
                PdfLoadedDocument PdfDoc = new PdfLoadedDocument(Stream2);

                dobj.Add(PdfDoc);

            }

            PdfDocument FinalDoc = new PdfDocument();
            PdfMergeOptions mergeOption = new PdfMergeOptions
            {
                OptimizeResources = true
            };
            PdfDocumentBase.Merge(FinalDoc, mergeOption, dobj.ToArray());

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 42f);
            foreach (PdfPageBase lPage in FinalDoc.Pages)
            {
                PdfGraphics graphics = lPage.Graphics;
                PdfGraphicsState state = graphics.Save();
                graphics.SetTransparency(0.25f);
                graphics.RotateTransform(-40);
                graphics.DrawString(UserFileNumber, font, PdfBrushes.Red, -150, 450);
                graphics.Restore(state);
            }

            MemoryStream stream = new MemoryStream();
            FinalDoc.Save(stream);
            stream.Position = 0;
            FinalDoc.Close(true);
            
            var TempName = $@"\[{UserFileNumber}][{ RandomString(15) }]" + ".pdf";
            ViewData["Path"] = PathsProvider.TempFilesPath + TempName;
            using (var fileStream = new FileStream(Path.Combine(hostingEnv.WebRootPath + PathsProvider.TempFilesPath) + TempName, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }

            return View("ShowMessageDetails", _messageServices.GetOldMessageDoc(id, LtrYear));
        }

        private static string RandomString(int number)
        {
            return new string(Enumerable.Repeat("123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", number)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }
    }
}

