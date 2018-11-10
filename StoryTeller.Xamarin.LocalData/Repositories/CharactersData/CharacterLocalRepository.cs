using StoryTeller.Core.CharactersData;
using StoryTeller.Xamarin.Domain.Entities.CharactersData.Factories.Interfaces;
using StoryTeller.Xamarin.Domain.Entities.CharactersData.Repositories;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.LocalData.Repositories.CharactersData
{
    public class CharacterLocalRepository : BaseRepository, ICharacterLocalRepository
    {
        private readonly IXamarinCharacterFactory _xamarinCharacterFactory;

        public CharacterLocalRepository(IXamarinCharacterFactory xamarinCharacterFactory)
        {
            _xamarinCharacterFactory = xamarinCharacterFactory;
        }

        public async Task<bool> AddCharacterAsync(Character character)
        {
            var xamChar = await _xamarinCharacterFactory.MapCharacterToXamarinAsync(character);

            await Conn.InsertAsync(xamChar);

            return true;
        }

        protected override void ReleaseResources()
        {
            _xamarinCharacterFactory.Dispose();
        }
    }
}
