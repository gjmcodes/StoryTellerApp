using StoryTeller.Core.Models.Pronoums;
using StoryTeller.Xamarin.Domain.Entities.Pronoums;
using StoryTeller.Xamarin.Domain.Entities.Pronoums.Interfaces;
using StoryTeller.Xamarin.Domain.Entities.Pronoums.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.LocalData.Repositories.Pronoums
{
    public class PronoumLocalRepository : BaseRepository, IPronoumLocalRepository
    {
        private readonly IXamarinPronoumFactory _xamarinPronoumFactory;

        public PronoumLocalRepository(IXamarinPronoumFactory xamarinPronoumFactory)
        {
            _xamarinPronoumFactory = xamarinPronoumFactory;
        }

        public async Task<bool> AddPronoumsAsync(IEnumerable<Pronoum> pronoums)
        {
            var xamPronoums = await _xamarinPronoumFactory.MapPronoumToXamarin(pronoums);

            await Conn.InsertAllAsync(xamPronoums);

            return true;
        }

        public async Task<Pronoum> GetPronoumByIdAsync(string pronoumId)
        {
            var xamPronoum = await Conn.Table<XamarinPronoum>().FirstAsync(x => x.PronoumId == pronoumId);
            var pronoum = new Pronoum();

            pronoum.forFemale = xamPronoum.ForFemale;
            pronoum.forMale = xamPronoum.ForMale;
            pronoum.pronoumId = xamPronoum.PronoumId;

            return pronoum;
        }
    }
}
