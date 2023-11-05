using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace TDT.Core.Extensions
{
    public static class HtmlHelperExtension
    {
        private static string BASE_URL = "https://localhost:44300/";
        public static IHtmlContent AddSharedScript(this IHtmlHelper html, string path)
        {
            if (html == null || path == null)
            {
                return new HtmlString("");
            }
            return new HtmlString($"<script src=\"{BASE_URL + path}\"></script>");
        }
        public static IHtmlContent AddSharedCSS(this IHtmlHelper html, string path)
        {
            if (html == null || path == null)
            {
                return new HtmlString("");
            }
            return new HtmlString($"<link rel=\"stylesheet\" href=\"{BASE_URL + path}\" asp-append-version=\"true\" />");
        }
        public static string GetString(IHtmlContent content)
        {
            using (var writer = new StringWriter())
            {
                content.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }
    }
}
