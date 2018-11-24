using StoryTeller.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Interfaces.Services.LocalData
{
    public interface ILocalDataManagementService : IBaseService
    {
        Task CreateLocalTablesAsync();
        Task VerifyLocalTablesUpdateFromExternalDataAsync();
        Task ClearLocalDataForCulctureChangeAsync();
        Task<bool> HasLocalTablesAsync();
        Task<bool> HasCharactersCreatedAsync();
        Task<bool> HasCultureSelectedAsync();
    }
}
