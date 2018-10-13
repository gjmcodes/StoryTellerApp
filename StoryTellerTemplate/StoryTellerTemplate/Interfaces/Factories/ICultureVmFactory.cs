using StoryTeller.Core.GameCultures;
using StoryTellerTemplate.Models.GameCultures;
using System.Collections.Generic;

namespace StoryTellerTemplate.Interfaces.Factories
{
    public interface ICultureVmFactory : IBaseFactory
    {
        IEnumerable<CultureVm> MapCultureToVm(IEnumerable<Culture> cultures);
    }
}
