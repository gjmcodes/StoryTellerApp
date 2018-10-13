using System.Threading.Tasks;
using StoryTeller.Core.CharactersData;
using StoryTeller.Core.Interfaces.Repositories.Local.CharactersData;

namespace StoryTeller.InternalData.Repositories.CharactersData
{
    public class CharacterDataRepository : BaseRepository, ICharacterDataLocalRepository
    {
        public Task<Character> GetCharacterDataAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetCharacterDataColumnValueAsync(string column)
        {
            throw new System.NotImplementedException();
        }
    }
}
