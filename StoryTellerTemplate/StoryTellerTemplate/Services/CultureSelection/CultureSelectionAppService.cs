using StoryTeller.Core.Interfaces.Repositories.GameCultures;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Interfaces.Services.CultureSelection;
using StoryTellerTemplate.Models.GameCultures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Services.CultureSelection
{
    public class CultureSelectionAppService : BaseAppService, ICultureSelectionAppService
    {
        private readonly IGameCultureRepository _gameCultureRepository;
        private readonly ICultureVmFactory _cultureVmFactory;


        public CultureSelectionAppService(IGameCultureRepository gameCultureRepository,
            ICultureVmFactory cultureVmFactory)
        {
            _gameCultureRepository = gameCultureRepository;
            _cultureVmFactory = cultureVmFactory;
        }

        public async Task<IEnumerable<CultureVm>> GetCulturesAsync()
        {
            var cultures = await _gameCultureRepository.GetGameCulturesAsync();
            var culturesVm = _cultureVmFactory.MapCultureToVm(cultures);

            return culturesVm;
        }
    }
}
