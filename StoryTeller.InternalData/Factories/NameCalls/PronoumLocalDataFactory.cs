using System.Collections.Generic;
using System.Threading.Tasks;
using StoryTeller.Core.Models.NameCalls;
using StoryTeller.InternalData.DTOs.PersistentObjects.NameCalls;
using StoryTeller.InternalData.Interfaces.Factories.NameCalls;

namespace StoryTeller.InternalData.Factories.NameCalls
{
    public class PronoumLocalDataFactory : BaseLocalDataFactory, IPronoumLocalDataFactory
    {
        public async Task<IEnumerable<PronoumNameCallDto>> MapPronoumNameCallToDtoAsync(IEnumerable<PronoumNameCall> models)
        {
            throw new System.NotImplementedException();
        }

        protected override void ReleaseResources()
        {
        }
    }
}
