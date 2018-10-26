using StoryTeller.Core.CharactersData;
using StoryTeller.InternalData.DTOs.PersistentObjects.CharactersData;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Models.CharacterCreation;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Factories
{
    public class CharacterCreationVmFactory : BaseFactory, ICharacterCreationVmFactory
    {
        public async Task<Character> MapVmToCharacterAsync(CharacterCreationVm characterCreationVm)
        {
            return await Task.Run(() =>
            {
                var character = new Character(characterCreationVm.Name, characterCreationVm.Gender);

                return character;
            });
        }

        public async Task<CharacterDto> MapVmToCharacterDtoAsync(CharacterCreationVm characterCreationVm)
        {
            return await Task.Run(() =>
            {
                var character = new CharacterDto()
                {
                    Name = characterCreationVm.Name,
                    Gender = characterCreationVm.Gender
                };

                return character;
            });
        }
    }
}
