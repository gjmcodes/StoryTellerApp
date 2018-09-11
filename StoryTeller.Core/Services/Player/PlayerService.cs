using StoryTeller.Core.Interfaces.Services.Player;
using StoryTeller.Core.Player;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.Player
{
    public class PlayerService : BaseService, IPlayerService
    {
        public async Task<PlayerStatusInventoryAggregate> GetPlayerStatusInventoryAsync()
        {
            return new PlayerStatusInventoryAggregate();
        }
    }
}
