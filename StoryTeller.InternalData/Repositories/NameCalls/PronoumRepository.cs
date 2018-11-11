using StoryTeller.Core.Interfaces.Repositories.Local.NameCalls;
using StoryTeller.Core.Models.Pronoums;
using StoryTeller.InternalData.DTOs.PersistentObjects.NameCalls;
using StoryTeller.InternalData.Interfaces.Factories.NameCalls;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Repositories.NameCalls
{
    public class PronoumRepository : BaseRepository, IPronoumLocalRepository
    {
        private readonly IPronoumLocalDataFactory _localDataPronoumFactory;

        public PronoumRepository(IPronoumLocalDataFactory localDataPronoumFactory)
        {
            _localDataPronoumFactory = localDataPronoumFactory;
        }

        public async Task<Pronoum> GetPronoumByIdAsync(string pronoumId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> PersistNameCallsAsync(IEnumerable<Pronoum> nameCalls)
        {
            var dtos = await _localDataPronoumFactory.MapPronoumNameCallToDtoAsync(nameCalls);

            await base.Conn.DeleteAllAsync<PronoumNameCallDto>();

            return await base.AddAsync(dtos);
        }
    }
}
