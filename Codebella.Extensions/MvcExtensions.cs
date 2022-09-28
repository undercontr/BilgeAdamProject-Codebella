using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Codebella.Extensions
{
    public static class MvcExtensions
    {
        public static void FlashSuccess(this Controller ctn, string content)
        {
            ctn.TempData["success"] = content;
        }
        public static void FlashWarning(this Controller ctn, string content)
        {
            ctn.TempData["warning"] = content;
        }
        public static void FlashError(this Controller ctn, string content)
        {
            ctn.TempData["danger"] = content;
        }

        public static IHtmlContent Flash(this IHtmlHelper html)
        {
            var message = "";
            var className = "";
            if (html.ViewContext.TempData["success"] != null)
            {
                message = html.ViewContext.TempData["success"].ToString();
                className = "success";
            }
            else if (html.ViewContext.TempData["warning"] != null)
            {
                message = html.ViewContext.TempData["warning"].ToString();
                className = "warning";
            }
            else if (html.ViewContext.TempData["danger"] != null)
            {
                message = html.ViewContext.TempData["danger"].ToString();
                className = "danger";
            }

            var htmlBuilder = new HtmlContentBuilder();
            if (!String.IsNullOrEmpty(message))
            {
                htmlBuilder.AppendFormat("<div class='alert alert-{0} alert-dismissible' role='alert'>", className);
                htmlBuilder.AppendHtml("<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>");
                htmlBuilder.AppendHtml(message);
                htmlBuilder.AppendHtml("</div>");
            }
            return htmlBuilder;
        }
    }
}
