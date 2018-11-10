using StoryTeller.Core.Models.App;
using StoryTeller.Xamarin.Domain.Entities.App.Factories.Interfaces;
using StoryTeller.Xamarin.Domain.Factories;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.App.Factories
{
    public class XamarinAppDictionaryFactory : BaseFactory, IXamarinAppDictionaryFactory
    {
        public async Task<XamarinAppDictionary> MapAppDictionaryToXamarin(AppDictionary appDictionary)
        {
            return await Task.Run(() =>
            {
                var xamAppDic = new XamarinAppDictionary(
                    appDictionary.exit,
                    appDictionary.male,
                    appDictionary.female,
                    appDictionary.languages,
                    appDictionary.namePlaceholder,
                    appDictionary.version);

                return xamAppDic;
            });
        }
    }
}
