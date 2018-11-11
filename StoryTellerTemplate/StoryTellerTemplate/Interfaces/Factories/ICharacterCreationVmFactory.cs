using StoryTeller.Core.CharactersData;
using StoryTeller.Xamarin.Domain.Entities.CharactersData;
using StoryTellerTemplate.Models.CharacterCreation;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface ICharacterCreationVmFactory : IBaseFactory
    {
        Task<Character> MapVmToCharacterAsync(CharacterCreationVm characterCreationVm);
        Task<XamarinCharacter> MapVmToCharacterAsync(CharacterCreationVm characterCreationVm);
    }
}
