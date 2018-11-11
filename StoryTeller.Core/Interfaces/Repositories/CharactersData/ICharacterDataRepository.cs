using StoryTeller.Core.CharactersData;
using StoryTeller.Core.Disposing;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.CharactersData
{
    public interface ICharacterDataRepository : IDisposableObject
    {
        Task<Character> GetCharacterDataAsync();
        Task<string> GetCharacterDataByColumnAsync(string column);
    }
}
