using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACS.Web.Providers
{
    public static class PathsProvider
    {
        public static string FilesPath = @"D:\AttachDoc";
        public static string TempAttachPath = @"D:\TempAttach";
        public static string TempFilesPath = @"\TempDoc";
        public static string PdfConverterFilesPath = @"\PdfConverterFiles";
        public static Uri CERPS_API_URL = new Uri($"http://10.10.102.16:8080/api/Employee/"); 
    }
}
