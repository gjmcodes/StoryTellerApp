using StoryTeller.Core.GameCultures;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Models.GameCultures;
using System.Collections.Generic;

namespace StoryTellerTemplate.Factories
{
    public class CultureVmFactory : BaseFactory, ICultureVmFactory
    {
        public IEnumerable<CultureVm> MapCultureToVm(IEnumerable<Culture> cultures)
        {
            var cultureVms = new List<CultureVm>();

            foreach (var item in cultures)
            {
                var vm = new CultureVm();
                vm.CultureCode = item.cultureCode;
                vm.ImagePath = item.imagePath;

                cultureVms.Add(vm);
            }

            return cultureVms;
        }
    }
}
