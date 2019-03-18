using System.Text.RegularExpressions;

namespace DotNetSurfer.DAL.HtmlHandlers
{
    public static class HtmlHandler
    {
        public static string GetTrimmedPlainTextFromHtml(string html, int length)
        {
            if (string.IsNullOrEmpty(html))
            {
                return html;
            }

            string plainText = ConvertHtmlToPlainText(html);
            string trimmedText = plainText.SubstringByLength(length);

            return trimmedText;
        }

        private static string ConvertHtmlToPlainText(string html)
        {
            return Regex.Replace(html, "<[^>]*>", "");
        }

        private static string SubstringByLength(this string text, int length)
        {
            int lengthToCut = text.Length > length ? length : text.Length;

            return text.Substring(0, lengthToCut);
        }
    }
}
