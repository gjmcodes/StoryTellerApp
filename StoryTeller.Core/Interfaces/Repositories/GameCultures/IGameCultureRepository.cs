using StoryTeller.Core.GameCultures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.GameCultures
{
    public interface IGameCultureRepository
    {
        Task<IEnumerable<Culture>> GetGameCulturesAsync();
    }
}
