using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACS.Web.Providers
{
    public static class RichTextEditorToolsProvider
    {
        public static string[] RichTextEditorToolBar = new[] {
        "Bold", "Italic", "Underline", "StrikeThrough",
        "FontName", "FontSize", "FontColor", "BackgroundColor", "|",
        "Formats", "Alignments", "OrderedList", "UnorderedList",
        "Outdent", "Indent", "|",
        "CreateLink", "CreateTable", "|", "ClearFormat", "Print",
        "SourceCode", "FullScreen", "|", "Undo", "Redo"
            };
}
}
