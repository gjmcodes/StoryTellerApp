using StoryTeller.Core.CharactersData;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Models.CharacterCreation;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Factories
{
    public class CharacterCreationVmFactory : BaseFactory, ICharacterCreationVmFactory
    {
        public async Task<Character> MapVmToCharacter(CharacterCreationVm characterCreationVm)
        {
            return await Task.Run(() =>
            {
                var character = new Character(characterCreationVm.Name, characterCreationVm.Gender);

                return character;
            });
        }
    }
}
