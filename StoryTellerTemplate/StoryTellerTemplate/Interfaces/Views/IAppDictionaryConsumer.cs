using StoryTeller.Core.Models.App;

namespace StoryTellerTemplate.Interfaces.Views
{
    public interface IAppDictionaryConsumer
    {
        void BindAppDictionaryConsumerToViewModel();
        void BindDictionaryData(AppDictionary appDictionary);
    }
}
