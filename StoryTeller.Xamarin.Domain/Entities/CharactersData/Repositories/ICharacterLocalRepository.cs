using StoryTeller.Core.CharactersData;
using StoryTeller.Core.Interfaces.Repositories;
using StoryTeller.Core.Interfaces.Repositories.CharactersData;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.CharactersData.Repositories
{
    public interface ICharacterLocalRepository : IBaseRepository, ICharacterDataRepository
    {
        Task<bool> AddCharacterAsync(Character character);
    }
}
