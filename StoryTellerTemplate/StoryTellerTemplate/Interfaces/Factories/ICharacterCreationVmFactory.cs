using StoryTeller.Core.CharactersData;
using StoryTellerTemplate.Models.CharacterCreation;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface ICharacterCreationVmFactory : IBaseFactory
    {
        Task<Character> MapVmToCharacter(CharacterCreationVm characterCreationVm);
    }
}
