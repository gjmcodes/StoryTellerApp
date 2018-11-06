using StoryTeller.Core.CharactersData;
using StoryTeller.InternalData.DTOs.PersistentObjects.CharactersData;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Interfaces.Factories.CharactersData
{
    public interface ICharacterLocalDataFactory : IBaseLocalDataFactory
    {
        Task<CharacterDto> MapCharacterToDtoAsync(Character model);
    }
}
