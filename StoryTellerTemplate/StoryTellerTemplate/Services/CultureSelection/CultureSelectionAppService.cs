using StoryTellerTemplate.Interfaces.Services.CultureSelection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Services.CultureSelection
{
    public class CultureSelectionAppService : BaseAppService, ICultureSelectionAppService
    {
        public async Task<IEnumerable<string>> GetCulturesAsync()
        {
            return new List<string>()
            {
                "EN",
                "PT"
            };
        }
    }
}
