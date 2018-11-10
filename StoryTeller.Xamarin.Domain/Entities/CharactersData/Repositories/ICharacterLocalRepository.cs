using StoryTeller.Core.CharactersData;
using StoryTeller.Core.Interfaces.Repositories;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.CharactersData.Repositories
{
    public interface ICharacterLocalRepository : IBaseRepository
    {
        Task<bool> AddCharacterAsync(Character character);
    }
}
