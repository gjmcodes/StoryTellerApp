using StoryTeller.Core.Interfaces.Repositories;
using StoryTeller.Core.Interfaces.Repositories.Pronoums;
using StoryTeller.Core.Models.Pronoums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.Pronoums.Repositories
{
    public interface IPronoumLocalRepository : IBaseRepository, IPronoumRepository
    {
        Task<bool> AddPronoumsAsync(PronoumRoot pronoums);
    }
}
