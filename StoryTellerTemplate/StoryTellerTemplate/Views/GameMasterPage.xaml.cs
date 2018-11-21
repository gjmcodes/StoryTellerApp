using StoryTeller.Xamarin.Domain.Entities.App;
using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.ViewModels;
using Xamarin.Forms;

namespace StoryTellerTemplate.Views
{
    public partial class GameMasterPage : MasterDetailPage, IAppDictionaryConsumer
    {
        public GameMasterPage()
        {
            InitializeComponent();
            BindAppDictionaryConsumerToViewModel();
        }

        public void BindAppDictionaryConsumerToViewModel()
        {
            var vm = BindingContext as GameMasterPageViewModel;
            vm.BindDictionaryConsumer(this);
        }

        public void BindDictionaryData(XamarinAppDictionary appDictionary)
        {
            btnLanguage.Text = appDictionary.Languages;
            btnExit.Text = appDictionary.Exit;
        }
    }
}