using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Tuskr.Web.Helpers
{
    public static class IncludeScriptExtensions
    {
        private const string SCRIPT_TAG_TEMPLATE = "<script src=\"{0}\" type=\"text/javascript\"></script>\n";
        private const string HTTP_CONTEXT_KEY_FOR_SCRIPTS = "RequiredScripts";

        public static string RequireScript(this HtmlHelper html, string path, int priority = 1)
        {
            var requiredScripts = HttpContext.Current.Items[HTTP_CONTEXT_KEY_FOR_SCRIPTS] as List<ResourceInclude>;
            if (requiredScripts == null) HttpContext.Current.Items[HTTP_CONTEXT_KEY_FOR_SCRIPTS] = requiredScripts = new List<ResourceInclude>();
            if (requiredScripts.All(i => i.Path != path)) requiredScripts.Add(new ResourceInclude { Path = path, Priority = priority });
            return null;
        }

        public static HtmlString EmitRequiredScripts(this HtmlHelper html)
        {
            var requiredScripts = HttpContext.Current.Items[HTTP_CONTEXT_KEY_FOR_SCRIPTS] as List<ResourceInclude>;
            if (requiredScripts == null) return null;
            var sb = new StringBuilder();
            foreach (var scriptInfo in requiredScripts.OrderByDescending(i => i.Priority))
            {
                sb.AppendFormat(SCRIPT_TAG_TEMPLATE, scriptInfo.Path);
            }
            return new HtmlString(sb.ToString());
        }

        public class ResourceInclude
        {
            public string Path { get; set; }
            public int Priority { get; set; }
        } 
    }
}