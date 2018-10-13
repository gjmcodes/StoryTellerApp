using StoryTeller.Core.Interfaces.Repositories.Local.NameCalls;
using StoryTeller.Core.Models.NameCalls;
using StoryTeller.InternalData.DTOs.PersistentObjects.NameCalls;
using StoryTeller.InternalData.Interfaces.Factories.NameCalls;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Repositories.NameCalls
{
    public class PronoumRepository : BaseRepository, IPronoumLocalRepository
    {
        private readonly IPronoumLocalDataFactory _localDataPronoumFactory;

        public async Task<PronoumNameCall> GetPronoumByIdAsync(string pronoumId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> PersistNameCallsAsync(IEnumerable<PronoumNameCall> nameCalls)
        {
            var dtos = await _localDataPronoumFactory.MapPronoumNameCallToDtoAsync(nameCalls);

            return await base.AddAsync<PronoumNameCallDto>(dtos);
        }
    }
}
