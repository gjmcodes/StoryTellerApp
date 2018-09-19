using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StoryCreator.Web.Models.Contents
{
    public class ContentMarkupTranslator
    {
        public const string paragraphStart = "<p>";
        public const string paragraphEnd = "</p>";

        public static IEnumerable<ContentViewModel> Translate(string content)
        {
            var contents = BreakIntoParagraphs(content);
            var contentVms = new List<ContentViewModel>();

            foreach (var item in contents)
            {
                contentVms.Add(new ContentViewModel() { Content = item });
            }

            return contentVms;
        }

        static IEnumerable<string> BreakIntoParagraphs(string content)
        {

            Regex removeNewLinePattern = new Regex($"[;,\t\r ]|[\n]{{*}}");
            removeNewLinePattern.Replace(content, string.Empty);

            var contents = Regex.Split(content, @"(<p>[\s\S]+?<\/p>)").Where(l => l != string.Empty).ToList();

            contents.RemoveAll(x => x == Environment.NewLine);

            return contents;
        }
    }
}
