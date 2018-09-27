using StoryTeller.Core.CharacterData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryTeller.Core.ContentTranslation.NameCalls
{
    public class NameCallContentFormatter : ContentFormatter
    {
        readonly Func<IEnumerable<CharacterNameCall>, bool, string, string> func;
        readonly IEnumerable<CharacterNameCall> collection;
        readonly bool isFemale;

        public NameCallContentFormatter(IEnumerable<CharacterNameCall> collection, bool isFemale)
        {
            this.func = new Func<IEnumerable<CharacterNameCall>, bool, string, string>((col, isFem, cId) =>
            {
                var pronoum = col.Where(x => x.characterId == cId.Replace("charId=", "") && x.isFemale == isFem)
               .Select(x => x.formalPronoum).First();

                return pronoum;
            });

            this.collection = collection;
            this.isFemale = isFemale;
        }

        public override string GetFormattedContent(string contentBetweenMarkers)
        {
            return func(collection, isFemale, contentBetweenMarkers);
        }
    }
}
