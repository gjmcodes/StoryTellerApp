using StoryTeller.Core.CharactersData;
using StoryTeller.Core.Disposing;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.CharactersData.Factories.Interfaces
{
    public interface IXamarinCharacterFactory : IDisposableObject
    {
        Task<XamarinCharacter> MapCharacterToXamarinAsync(Character character);
    }
}
