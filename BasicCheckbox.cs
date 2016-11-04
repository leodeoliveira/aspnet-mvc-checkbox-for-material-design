using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace B3Granel.MVC.Helpers
{
    public static class BasicCheckbox
    {
        public static MvcHtmlString BasicCheckBoxFor<T>(this HtmlHelper<T> html,
                                             Expression<Func<T, bool>> expression, string labelText,
                                             object htmlAttributes = null)
        {
            string code = "<div class=\"checkbox m-b-15\"><label>{0}<i class=\"input-helper\"></i>{1}{2}</label></div>";
            string check = html.CheckBoxFor(expression, htmlAttributes).ToString();
            int index = check.IndexOf('>');
            string checkBox = check.Substring(0, index + 1);
            string rest = check.Substring(index + 1, check.Length - index - 1);
            string result = string.Format(code, checkBox, rest, labelText);
            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString BasicCheckBox<T>(this HtmlHelper<T> html,
                                                string name,
                                                string labelText,
                                                bool @checked = true,
                                                object htmlAttributes = null)
        {
            string check = html.CheckBox(name, @checked, htmlAttributes).ToString();
            string code = "<div class=\"checkbox m-b-15\"><label>{0}<i class=\"input-helper\"></i>{1}{2}</label></div>";
            int index = check.IndexOf('>');
            string checkBox = check.Substring(0, index + 1);
            string rest = check.Substring(index + 1, check.Length - index - 1);
            string result = string.Format(code, checkBox, rest, labelText);
            return MvcHtmlString.Create(result);
        }
    }
}