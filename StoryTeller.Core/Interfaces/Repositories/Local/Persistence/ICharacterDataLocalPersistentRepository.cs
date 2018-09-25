using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.Persistence
{
    public interface ICharacterDataLocalPersistentRepository : IBaseRepository
    {
        Task<bool> PersistCharacterData(CharacterData.Character character);
    }
}
