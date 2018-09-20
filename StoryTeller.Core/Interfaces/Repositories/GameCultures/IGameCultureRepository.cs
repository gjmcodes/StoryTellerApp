using StoryTeller.Core.GameCultures;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.GameCultures
{
    public interface IGameCultureRepository
    {
        Task<Cultures> GetGameCulturesAsync();
    }
}
