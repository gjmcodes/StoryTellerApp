using StoryTeller.Core.Interfaces.Repositories.GameCultures;
using StoryTellerTemplate.Interfaces.Services.CultureSelection;
using StoryTellerTemplate.Models.GameCultures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Services.CultureSelection
{
    public class CultureSelectionAppService : BaseAppService, ICultureSelectionAppService
    {
        private readonly IGameCultureRepository _gameCultureRepository;

        public CultureSelectionAppService(IGameCultureRepository gameCultureRepository)
        {
            _gameCultureRepository = gameCultureRepository;
        }

        public async Task<IEnumerable<CultureVm>> GetCulturesAsync()
        {
            var cultures = await _gameCultureRepository.GetGameCulturesAsync();
            var culturesVm = new List<CultureVm>();

            // ToDo Transformar em factory
            foreach (var item in cultures)
            {
                var vm = new CultureVm()
                {
                    CultureCode = item.cultureCode,
                    ImagePath = item.imagePath
                };

                culturesVm.Add(vm);
            }

            return culturesVm;
        }
    }
}
