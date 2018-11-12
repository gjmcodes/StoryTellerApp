using StoryTeller.Core.CharactersData;
using StoryTeller.Xamarin.Domain.Entities.CharactersData;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Models.CharacterCreation;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Factories
{
    public class CharacterCreationVmFactory : BaseFactory, ICharacterCreationVmFactory
    {
        public async Task<XamarinCharacter> MapVmToCharacterAsync(CharacterCreationVm characterCreationVm)
        {
            return await Task.Run(() =>
            {
                var character = new XamarinCharacter(characterCreationVm.Name, characterCreationVm.Gender);

                return character;
            });
        }

    }
}
