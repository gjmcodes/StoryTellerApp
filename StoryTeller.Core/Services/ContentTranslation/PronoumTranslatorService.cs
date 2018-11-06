using StoryTeller.Core.ContentTranslation;
using StoryTeller.Core.ContentTranslation.NameCalls;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using StoryTeller.Core.Models.NameCalls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.ContentTranslation
{

    public class PronoumTranslatorService : BaseService, IPronoumTranslatorService
    {

        const string pronoumRegexPattern = @"(<pronoum>[\s\S]+?<\/pronoum>)";
        const string pronoumStart = "<pronoum>";
        const string pronoumEnd = "</pronoum>";

        public IEnumerable<PronoumNameCall> pronoums;
        NameCallContentFormatter _nameCallContentFormatter;

        public PronoumTranslatorService(NameCallContentFormatter nameCallContentFormatter)
        {
            _nameCallContentFormatter = nameCallContentFormatter;
        }

        async Task<IList<ContentTranslationDto>> BreakIntoDataAsync(IEnumerable<ContentTranslationDto> paragraphedContents,
       string regexPattern, string attributeMarkStart, string attributeMarkEnd)
        {

            var contentBuilder = new ContentBuilder(_nameCallContentFormatter);
            var contents = await contentBuilder.TranslateContentAsync(paragraphedContents, attributeMarkStart, attributeMarkEnd, regexPattern);

            return contents.ToList();
        }

        async Task<IList<ContentTranslationDto>> BreakPronoumsAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = await BreakIntoDataAsync(paragraphedContents, pronoumRegexPattern, pronoumStart, pronoumEnd);

            return contents;
        }

        public async Task<IEnumerable<ContentTranslationDto>> BreakNameCallsAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = await BreakPronoumsAsync(paragraphedContents);

            return contents;
        }

        public async Task<string> TranslatePronoumAsync(string content)
        {
            var contents = RegexSplitter.Split(content, pronoumRegexPattern);

            var sb = new StringBuilder();

            foreach (var item in contents)
            {
                var translanted = await _nameCallContentFormatter.GetFormattedContentAsync(item);

                sb.Append(translanted);
            }

            return sb.ToString();

        }

        public bool HasPronoumMarkers(string content)
        {
            return content.Contains(pronoumStart);
        }
    }
}
