using System.Collections.Generic;
using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.ViewModels;
using Xamarin.Forms;

namespace StoryTellerTemplate.Views
{
    public partial class CharacterCreationPage : ContentPage, IGameContentManager
    {
        private FormattedString fortText;

        public CharacterCreationPage()
        {
            InitializeComponent();

            fortText = new FormattedString();

            BindToViewModel();
        }

        public void BindContentText(IEnumerable<Span> textSpans)
        {
            fortText.Spans.Clear();

            foreach (var item in textSpans)
            {
                fortText.Spans.Add(item);
            }

            contentLbl.FormattedText = fortText;
        }

        public void BindToViewModel()
        {
            var vm = BindingContext as CharacterCreationPageViewModel;
            vm.BindCustomTextBindingPage(this);
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var vm = BindingContext as CharacterCreationPageViewModel;
            vm.CharacterCreation.Gender = !vm.CharacterCreation.Gender;
        }
    }
}
