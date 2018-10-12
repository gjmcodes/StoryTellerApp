using StoryTellerTemplate.Models.GameCultures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Interfaces.Services.CultureSelection
{
    public interface ICultureSelectionAppService : IBaseAppService
    {
        Task<IEnumerable<CultureVm>> GetCulturesAsync();
    }
}
