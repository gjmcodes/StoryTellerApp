using StoryTeller.Core.CharacterData;
using StoryTeller.Core.ContentTranslation.NameCalls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryTeller.Core.ContentTranslation
{

    public class NameCallTranslator
    {
        readonly ContentBuilder _contentBuilder;

        const string formalCallRegexPattern = @"(<namecall_formal>[\s\S]+?<\/namecall_formal>)";
        const string formalCallStart = "<namecall_formal>";
        const string formalCallEnd = "</namecall_formal>";


        public IEnumerable<CharacterNameCall> charactersNameCalls;
        NameCallContentFormatter _nameCallContentFormatter;

        public NameCallTranslator()
        {
            _contentBuilder = new ContentBuilder();
        }

        IList<ContentTranslationDto> BreakIntoData(IEnumerable<ContentTranslationDto> paragraphedContents,
       string regexPattern, string attributeMarkStart, string attributeMarkEnd, bool isFemale)
        {
            charactersNameCalls = new List<CharacterNameCall>()
            {
                new CharacterNameCall(){
                    characterId ="0001",
                    formalPronoum = "Ma'am",
                    isFemale = true 
                },
                new CharacterNameCall(){
                    characterId ="0001",
                    formalPronoum = "Sir",
                    isFemale = false
                },
            };

            _nameCallContentFormatter = new NameCallContentFormatter(charactersNameCalls, false);

            var contents = _contentBuilder.TranslateContentWithDataToFill(paragraphedContents, attributeMarkStart, attributeMarkEnd,
                regexPattern, _nameCallContentFormatter);

            return contents.ToList();
        }

        IList<ContentTranslationDto> BreakFormalNameCalls(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            bool _isFemale = false;

            var contents = BreakIntoData(paragraphedContents, formalCallRegexPattern, formalCallStart, formalCallEnd, _isFemale);

            return contents;
        }

        public IEnumerable<ContentTranslationDto> BreakNameCalls(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            var contents = BreakFormalNameCalls(paragraphedContents);

            return contents;
        }
    }
}
