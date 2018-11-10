using StoryTeller.Core.Models.NameCalls;
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

        public async Task<bool> AddPronoumsAsync(IEnumerable<PronoumNameCall> pronoums)
        {
            var xamPronoums = await _xamarinPronoumFactory.MapPronoumToXamarin(pronoums);

            await Conn.InsertAllAsync(xamPronoums);

            return true;
        }
    }
}
