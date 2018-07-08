namespace WebApp.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices.ComTypes;

    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using WebApp.Models;

    public static class CommentListHelper
    {
        public static HtmlString CreateList(this IHtmlHelper html, string[] items)
        {
            string result = "<ul>";
            foreach (string item in items)
            {
                result += $"<li>{item}</li>";
            }
            result += "</ul>";
            return new HtmlString(result);
        }

        public static HtmlString CreateCommentsList(this IHtmlHelper<List<Tuple<Entities.Post, int>>> html, List<CommentModel> items)
        {
            string result = "<tbody>";
            foreach (CommentModel item in items)
            {
                result += "tr";
                result += $"<td>{html.DisplayFor(m => item.Id)}</td>";
                result += "tr";
            }
            result += "</tbody>";
            return new HtmlString(result);
        }
    }
}
