using StoryTellerTemplate.Models.GameCultures;
using StoryTellerTemplate.ViewModels;
using Xamarin.Forms;

namespace StoryTellerTemplate.Views
{
    public partial class CultureSelectionPage : ContentPage
    {
        public CultureSelectionPage()
        {

            InitializeComponent();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vm = (CultureSelectionPageViewModel)BindingContext;

            await vm.SelectCultureAsync((CultureVm)e.Item);
        }
    }
}
