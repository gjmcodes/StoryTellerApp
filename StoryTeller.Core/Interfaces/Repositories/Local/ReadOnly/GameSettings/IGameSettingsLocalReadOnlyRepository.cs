using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly.GameSettings
{
    public interface IGameSettingsLocalReadOnlyRepository
    {
        Task<string> GetSelectedCultureAsync();
    }
}
