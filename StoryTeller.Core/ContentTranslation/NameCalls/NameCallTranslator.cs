using StoryTeller.Core.CharacterData;
using StoryTeller.Core.ContentTranslation.NameCalls;
using StoryTeller.Core.NameCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation
{

    public class NameCallTranslator
    {

        const string pronoumRegexPattern = @"(<pronoum>[\s\S]+?<\/pronoum>)";
        const string pronoumStart = "<pronoum>";
        const string pronoumEnd = "</pronoum>";


        public IEnumerable<PronoumNameCall> pronoums;
        NameCallContentFormatter _nameCallContentFormatter;


        async Task<IList<ContentTranslationDto>> BreakIntoDataAsync(IEnumerable<ContentTranslationDto> paragraphedContents,
       string regexPattern, string attributeMarkStart, string attributeMarkEnd, bool isFemale)
        {
            pronoums = new List<PronoumNameCall>()
            {
                new PronoumNameCall(){
                    pronoumId = "0001",
                    forMale = "He",
                    forFemale = "She"
                },
                new PronoumNameCall(){
                    pronoumId = "0002",
                    forMale = "Mister",
                    forFemale = "Miss"
                },
            };


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
