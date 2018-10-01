using StoryTeller.Core.CharacterData;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly
{
    public interface ICharacterDataLocalRepository : IBaseRepository
    {
        Task<Character> GetCharacterDataAsync();
    }
}
