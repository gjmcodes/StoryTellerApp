using StoryTeller.Core.CharactersData;
using StoryTeller.InternalData.DTOs.PersistentObjects.CharactersData;
using StoryTellerTemplate.Models.CharacterCreation;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface ICharacterCreationVmFactory : IBaseFactory
    {
        Task<Character> MapVmToCharacterAsync(CharacterCreationVm characterCreationVm);
        Task<CharacterDto> MapVmToCharacterDtoAsync(CharacterCreationVm characterCreationVm);
    }
}
