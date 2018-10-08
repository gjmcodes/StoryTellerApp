using StoryTeller.Core.Models.NameCalls;
using StoryTeller.InternalData.DTOs.PersistentObjects.NameCalls;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Interfaces.Factories.NameCalls
{
    public interface ILocalDataPronoumFactory : IBaseLocalDataFactory
    {
        Task<IEnumerable<PronoumNameCallDto>> MapPronoumNameCallToDtoAsync(IEnumerable<PronoumNameCall> models);
    }
}
