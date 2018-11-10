using StoryTeller.Core.Interfaces.Repositories;
using StoryTeller.Core.Models.NameCalls;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.Pronoums.Repositories
{
    public interface IPronoumLocalRepository : IBaseRepository
    {
        Task<bool> AddPronoumsAsync(IEnumerable<PronoumNameCall> pronoums);
    }
}
