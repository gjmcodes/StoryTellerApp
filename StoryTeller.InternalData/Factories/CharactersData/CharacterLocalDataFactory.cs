using StoryTeller.Core.CharactersData;
using StoryTeller.InternalData.DTOs.PersistentObjects.CharactersData;
using StoryTeller.InternalData.Interfaces.Factories.CharactersData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Factories.CharactersData
{
    public class CharacterLocalDataFactory : BaseLocalDataFactory, ICharacterLocalDataFactory
    {

        public async Task<CharacterDto> MapCharacterToDtoAsync(Character model)
        {
            var dto = new CharacterDto(model.Name, model.Gender);

                return dto;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
