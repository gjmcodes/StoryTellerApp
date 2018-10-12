using System.Threading.Tasks;
using StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly.GameSettings;

namespace StoryTeller.InternalData.Repositories.GameSettings
{
    public class GameSettingsReadOnlyRepository : IGameSettingsLocalReadOnlyRepository
    {
        public Task<string> GetSelectedCultureAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
