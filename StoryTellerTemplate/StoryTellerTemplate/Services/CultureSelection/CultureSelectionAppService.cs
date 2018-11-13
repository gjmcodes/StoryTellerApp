using StoryTeller.Core.Interfaces.Repositories.GameCultures;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Core.Interfaces.Repositories.Users;
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
        private readonly IUserLocalRepository _userLocalRepository;

        public CultureSelectionAppService(IGameCultureRepository gameCultureRepository,
            ICultureVmFactory cultureVmFactory,
            IUserLocalRepository userLocalRepository)
        {
            _gameCultureRepository = gameCultureRepository;
            _cultureVmFactory = cultureVmFactory;
            _userLocalRepository = userLocalRepository;
        }

        public async Task<IEnumerable<CultureVm>> GetCulturesAsync()
        {
            var cultures = await _gameCultureRepository.GetGameCulturesAsync();
            var culturesVm = _cultureVmFactory.MapCultureToVm(cultures);

            return culturesVm;
        }

        public async Task<bool> SetSelectedCultureAsync(string selectedCulture)
        {
            return await _userLocalRepository.SetSelectedCultureAsync(selectedCulture);
        }
    }
}
