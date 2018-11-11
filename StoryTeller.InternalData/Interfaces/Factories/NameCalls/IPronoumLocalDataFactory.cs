using StoryTeller.Core.Models.Pronoums;
using StoryTeller.InternalData.DTOs.PersistentObjects.NameCalls;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Interfaces.Factories.NameCalls
{
    public interface IPronoumLocalDataFactory : IBaseLocalDataFactory
    {
        Task<IEnumerable<PronoumNameCallDto>> MapPronoumNameCallToDtoAsync(IEnumerable<Pronoum> models);
    }
}
