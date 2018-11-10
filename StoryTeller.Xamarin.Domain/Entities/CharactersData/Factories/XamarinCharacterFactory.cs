using StoryTeller.Core.CharactersData;
using StoryTeller.Xamarin.Domain.Entities.CharactersData.Factories.Interfaces;
using StoryTeller.Xamarin.Domain.Factories;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.CharactersData.Factories
{
    public class XamarinCharacterFactory : BaseFactory, IXamarinCharacterFactory
    {
        public async Task<XamarinCharacter> MapCharacterToXamarinAsync(Character character)
        {
            return await Task.Run(() =>
            {
                var xamChar = new XamarinCharacter(character.Name, character.Gender);

                return xamChar;
            });
        }
    }
}
