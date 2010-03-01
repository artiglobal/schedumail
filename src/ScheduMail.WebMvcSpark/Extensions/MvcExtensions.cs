using System.Collections.Generic;
using System.Web.Mvc;
using System;
using System.Text;
using System.Web.Routing;

namespace ScheduMail.WebMvcSpark.Extensions
{
    /// <summary>
    /// General Extensions helpers
    /// </summary>
    public static class MyExtensions
    {
        /// <summary>
        /// Copies the state of to model.
        /// </summary>
        /// <param name="ruleException">The rule exception.</param>
        /// <param name="modelState">State of the model.</param>
        /// <param name="prefix">The prefix.</param>
        public static void CopyToModelState(this RuleException ruleException, ModelStateDictionary modelState, string prefix)
        {
            foreach (string key in ruleException.Errors)
            {
                foreach (string value in ruleException.Errors.GetValues(key))
                {
                    if (string.IsNullOrEmpty(prefix))
                    {
                        modelState.AddModelError(key, value);
                    }
                    else
                    {
                        modelState.AddModelError(prefix + "." + key, value);
                    }
                }
            }
        }

        /// <summary>
        /// Copies the state of to model.
        /// </summary>
        /// <param name="ruleException">The rule exception.</param>
        /// <param name="modelState">State of the model.</param>
        public static void CopyToModelState(this RuleException ruleException, ModelStateDictionary modelState)
        {
            foreach (string key in ruleException.Errors)
            {
                foreach (string value in ruleException.Errors.GetValues(key))
                {
                    modelState.AddModelError(key, value);
                }
            }
        }

        /// <summary>
        /// Checks the box list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="listInfo">The list info.</param>
        /// <returns></returns>
        public static string CheckBoxList(this HtmlHelper htmlHelper, string name, List<CheckBoxListInfo> listInfo)
        {
            return htmlHelper.CheckBoxList(name, listInfo, ((IDictionary<string, object>)null));
        }

        /// <summary>
        /// Checks the box list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="listInfo">The list info.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static string CheckBoxList(this HtmlHelper htmlHelper, string name, List<CheckBoxListInfo> listInfo,
            object htmlAttributes)
        {
            return htmlHelper.CheckBoxList(name, listInfo,
                ((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes)));
        }

        /// <summary>
        /// Checks the box list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="listInfo">The list info.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static string CheckBoxList(this HtmlHelper htmlHelper, string name, List<CheckBoxListInfo> listInfo,

            IDictionary<string, object> htmlAttributes)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("The argument must have a value", "name");
            if (listInfo == null)
                throw new ArgumentNullException("listInfo");
            if (listInfo.Count < 1)
                throw new ArgumentException("The list must contain at least one value", "listInfo");
            StringBuilder sb = new StringBuilder();
            foreach (CheckBoxListInfo info in listInfo)
            {
                TagBuilder builder = new TagBuilder("input");
                if (info.IsChecked) builder.MergeAttribute("checked", "checked");
                builder.MergeAttributes<string, object>(htmlAttributes);
                builder.MergeAttribute("type", "checkbox");
                builder.MergeAttribute("value", info.Value);
                builder.MergeAttribute("name", name);
                builder.InnerHtml = info.DisplayText;
                sb.Append(builder.ToString(TagRenderMode.Normal));
                sb.Append("<br />");
            }

            return sb.ToString();
        }       
    }

    /// <summary>
    /// Check box list information.
    /// </summary>
    public class CheckBoxListInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBoxListInfo"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="displayText">The display text.</param>
        /// <param name="isChecked">if set to <c>true</c> [is checked].</param>
        public CheckBoxListInfo(string value, string displayText, bool isChecked)
        {
            this.Value = value;
            this.DisplayText = displayText;
            this.IsChecked = isChecked;
        }
        public string Value { get; private set; }
        public string DisplayText { get; private set; }
        public bool IsChecked { get; private set; }
    }
}

