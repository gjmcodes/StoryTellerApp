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
        readonly NameCallContentFormatter _nameCallContentFormatter;

        const string formalCallRegexPattern = @"(<namecall_formal>[\s\S]+?<\/namecall_formal>)";
        const string formalCallStart = "<namecall_formal>";
        const string formalCallEnd = "</namecall_formal>";


        public IEnumerable<CharacterNameCall> charactersNameCalls;

        //Func<IEnumerable<CharacterNameCall>, bool, string, string> NameCallFilterFunc;

        public NameCallTranslator()
        {
            _contentBuilder = new ContentBuilder();
            _nameCallContentFormatter = new NameCallContentFormatter(charactersNameCalls, false);
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

            var regexSplitter = new RegexSplitter();

            var newContents = new List<ContentTranslationDto>();

            foreach (var content in paragraphedContents)
            {
                var contents = regexSplitter.Split(content.content, regexPattern);

                if (content.lineBreak)
                    newContents.Add(content);

                foreach (var item in contents)
                {
                    var dto = _contentBuilder.TranslateContentWithDataToFill(
                        content, 
                        attributeMarkStart, 
                        attributeMarkEnd, 
                        item,
                        _nameCallContentFormatter);

                    newContents.Add(dto);
                }
            }

            return newContents;
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
