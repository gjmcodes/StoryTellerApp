using StoryTeller.Core.CharactersData;
using StoryTeller.Xamarin.Domain.Entities.CharactersData;
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

        async Task<XamarinCharacter> GetXamarinCharacterAsync()
        {
            var data = await Conn.Table<XamarinCharacter>().FirstOrDefaultAsync();

            return data;
        }
        public async Task<bool> AddCharacterAsync(Character character)
        {
            var xamChar = await _xamarinCharacterFactory.MapCharacterToXamarinAsync(character);

            await Conn.InsertAsync(xamChar);

            return true;
        }

        public async Task<Character> GetCharacterDataAsync()
        {
            var data = await Conn.Table<XamarinCharacter>().FirstOrDefaultAsync();
            var character = await _xamarinCharacterFactory.MapXamarinToCharacterAsync(data);

            return character;
        }

        public async Task<string> GetCharacterDataByColumnAsync(string column)
        {
            var xamChar = await GetXamarinCharacterAsync();
            var query = $@"SELECT {column} FROM {TableName<XamarinCharacter>()} WHERE LocalPk = '{xamChar.LocalPk}'";
            var data = await Conn.ExecuteScalarAsync<string>(query);

            return data;
        }

        protected override void ReleaseResources()
        {
            _xamarinCharacterFactory.Dispose();
        }
    }
}
