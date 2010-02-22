using System;
using System.Text;
using System.Web.Mvc;

namespace ScheduMail.WebMvc2.HtmlHelpers
{
    /// <summary>
    /// Paging Helper.
    /// </summary>
    public static class PagingHelpers
    {
        /// <summary>
        /// Pages the links.
        /// </summary>
        /// <param name="html">The HTML heper name.</param>
        /// <param name="currentPage">The current page.</param>
        /// <param name="totalPages">The total pages.</param>
        /// <param name="pageUrl">The page URL.</param>
        /// <returns>Constructed anchor tag.</returns>
        public static string PageLinks(
                                        this HtmlHelper html, 
                                        int currentPage,
                                        int totalPages, 
                                        Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= totalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == currentPage)
                {
                    tag.AddCssClass("selected");
                }

                result.AppendLine(tag.ToString());
            }

            return result.ToString();
        }
    }
}