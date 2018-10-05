using StoryTeller.Core.CharactersData;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly
{
    public interface ICharacterDataLocalRepository : IBaseRepository
    {
        Task<Character> GetCharacterDataAsync();
        Task<string> GetCharacterDataColumnValueAsync(string columnName);
    }
}
