using StoryTellerTemplate.Models.CharacterCreation;
using StoryTellerTemplate.Models.MainPage;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Interfaces.Services.CharacterCreation
{
    public interface ICharacterCreationAppService : IBaseAppService
    {
        Task<PageVm> GetCharacterCreationPageAsync();
        Task<bool> CreateCharacterAsync(CharacterCreationVm characterCreationVm);
    }
}
