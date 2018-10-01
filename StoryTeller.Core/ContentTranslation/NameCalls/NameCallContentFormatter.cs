using StoryTeller.Core.CharacterData;
using StoryTeller.Core.NameCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation.NameCalls
{
    public class NameCallContentFormatter : ContentFormatter
    {
        readonly Func<IEnumerable<PronoumNameCall>, bool, string, string> func;

        // ToDo: Injetar repository de pronoums
        readonly IEnumerable<PronoumNameCall> collection;

        //ToDo: Injetar repository de dados do personagem
        readonly bool isFemale;

        public NameCallContentFormatter(IEnumerable<PronoumNameCall> collection, bool isFemale)
        {
            this.func = new Func<IEnumerable<PronoumNameCall>, bool, string, string>((col, isFem, pronoumId) =>
            {
                var pronoum = col.Where(x => x.pronoumId == pronoumId.Trim()).First();

                if (isFem)
                    return pronoum.forFemale;

                return pronoum.forMale;
            });

            this.collection = collection;
            this.isFemale = isFemale;
        }


        public override async Task<string> GetFormattedContentAsync(string contentBetweenMarkers)
        {
            return await Task.Run(() => func(collection, isFemale, contentBetweenMarkers));
        }
    }
}
