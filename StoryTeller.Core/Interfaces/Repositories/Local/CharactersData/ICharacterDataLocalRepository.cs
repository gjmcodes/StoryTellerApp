using StoryTeller.Core.CharactersData;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.CharactersData
{
    public interface ICharacterDataLocalRepository : IBaseRepository
    {
        Task<string> GetCharacterDataColumnValueAsync(string column);
        Task<Character> GetCharacterDataAsync();
    }
}
