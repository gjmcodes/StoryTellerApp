using StoryTeller.Core.CharacterData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryTeller.Core.ContentTranslation
{

    public struct NameCallTranslator
    {
        const string formalCallRegexPattern = @"(<namecall_formal>[\s\S]+?<\/namecall_formal>)";
        const string formalCallStart = "<namecall_formal>";
        const string formalCallEnd = "</namecall_formal>";

        public IEnumerable<CharacterNameCall> charactersNameCalls;

        Func<IEnumerable<CharacterNameCall>, bool, string, string> NameCallFilterFunc;

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
                    characterId ="0002",
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
                    var hasAttribute = (item.Contains(attributeMarkStart) && item.Contains(attributeMarkEnd));
                    var formattedItem = item.Replace(attributeMarkStart, string.Empty).Replace(attributeMarkEnd, string.Empty);

                    if (hasAttribute)
                    {
                        var pronoum = NameCallFilterFunc(charactersNameCalls, isFemale, formattedItem.Trim());
                        formattedItem = pronoum;
                    }

                    var dto = new ContentTranslationDto() { content = formattedItem };

                    newContents.Add(dto);
                }
            }

            return newContents;
        }

        IList<ContentTranslationDto> BreakFormalNameCalls(IEnumerable<ContentTranslationDto> paragraphedContents)
        {
            NameCallFilterFunc = new Func<IEnumerable<CharacterNameCall>, bool, string, string>((collection, isFemale, charId) =>
            {
                var pronoum = collection.Where(x => x.characterId == charId && x.isFemale == isFemale)
                .Select(x => x.formalPronoum).First();

                return pronoum;
            });

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
