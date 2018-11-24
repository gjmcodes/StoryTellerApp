using StoryTeller.Core.Models.Pronoums;
using StoryTeller.Xamarin.Domain.Entities.Pronoums.Interfaces;
using StoryTeller.Xamarin.Domain.Factories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.Pronoums.Factories
{
    public class XamarinPronoumFactory : BaseFactory, IXamarinPronoumFactory
    {
        public async Task<XamarinPronoum> MapPronoumToXamarin(Pronoum pronoum, int version)
        {
            return await Task.Run(() =>
            {
                var xamPronoum = new XamarinPronoum(pronoum.pronoumId, pronoum.forMale, pronoum.forFemale, version);

                return xamPronoum;
            });
        }

        public async Task<IEnumerable<XamarinPronoum>> MapPronoumToXamarin(IEnumerable<Pronoum> pronoums, int pronoumVersion)
        {
            return await Task.Run(async () =>
            {
                var xamPronoums = new List<XamarinPronoum>();

                foreach (var item in pronoums)
                {
                    var xamPr = await MapPronoumToXamarin(item, pronoumVersion);
                    xamPronoums.Add(xamPr);
                }

                return xamPronoums;
            });
        }
    }
}
