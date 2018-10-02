using StoryTeller.Core.ContentTranslation;
using StoryTeller.Core.ContentTranslation.NameCalls;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using StoryTeller.Core.NameCalls;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.ContentTranslation
{

    public class NameCallTranslatorService : BaseService, INameCallTranslatorService
    {

        const string pronoumRegexPattern = @"(<pronoum>[\s\S]+?<\/pronoum>)";
        const string pronoumStart = "<pronoum>";
        const string pronoumEnd = "</pronoum>";


        public IEnumerable<PronoumNameCall> pronoums;
        NameCallContentFormatter _nameCallContentFormatter;


        async Task<IList<ContentTranslationDto>> BreakIntoDataAsync(IEnumerable<ContentTranslationDto> paragraphedContents,
       string regexPattern, string attributeMarkStart, string attributeMarkEnd, bool isFemale)
        {

            _nameCallContentFormatter = new NameCallContentFormatter(pronoums, false);
            var contentBuilder = new ContentBuilder(_nameCallContentFormatter);
            var contents = await contentBuilder.TranslateContentAsync(paragraphedContents, attributeMarkStart, attributeMarkEnd, regexPattern);

            return contents.ToList();
        }

        async Task<IList<ContentTranslationDto>> BreakPronoumsAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            bool _isFemale = false;

            var contents = await BreakIntoDataAsync(paragraphedContents, pronoumRegexPattern, pronoumStart, pronoumEnd, _isFemale);

            return contents;
        }

        public async Task<IEnumerable<ContentTranslationDto>> BreakNameCallsAsync(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = await BreakPronoumsAsync(paragraphedContents);

            return contents;
        }

        
    }
}
