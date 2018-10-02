using StoryTeller.Core.ContentTranslation;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.ContentTranslation
{
    public class ParagraphTranslatorService : BaseService, IParagraphTranslatorService
    {

        public const string paragraphStart = "<p>";
        public const string paragraphEnd = "</p>";
        public const string paragraphEndRegexEscape = @"<\/p>";


        public IEnumerable<ContentTranslationDto> BreakIntoParagraphs(string content)
        {

            var contents = Regex.Split(content.Replace(Environment.NewLine, string.Empty), $@"(<p>[\s\S]+?<\/p>)").ToList();
            var formattedContents = new List<string>();
            var dtos = new List<ContentTranslationDto>();

            foreach (var item in contents)
            {
                var dto = new ContentTranslationDto();

                var formattedItem = item.Replace(paragraphStart, string.Empty).Replace(paragraphEnd, string.Empty).Trim();
                if (string.IsNullOrEmpty(formattedItem))
                {
                    dto.lineBreak = true;
                    dto.amountLineBreaks = 2;
                    dto.content = string.Empty;
                }
                else
                {
                    dto.content = formattedItem;
                }

                dtos.Add(dto);
            }

            return dtos;
        }
    }
}
