using StoryTeller.Core.Models.App;
using StoryTeller.Xamarin.Domain.Entities.App;

namespace StoryTellerTemplate.Interfaces.Views
{
    public interface IAppDictionaryConsumer
    {
        void BindAppDictionaryConsumerToViewModel();
        void BindDictionaryData(XamarinAppDictionary appDictionary);
    }
}
