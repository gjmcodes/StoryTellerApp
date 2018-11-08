using System.Collections.Generic;
using StoryTeller.Core.Models.App;
using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.ViewModels;
using Xamarin.Forms;

namespace StoryTellerTemplate.Views
{
    public partial class CharacterCreationPage : ContentPage, IGameContentManager, IAppDictionaryConsumer
    {
        private FormattedString fortText;

        public CharacterCreationPage()
        {
            InitializeComponent();

            fortText = new FormattedString();

            BindContentManagerToViewModel();
            BindAppDictionaryConsumerToViewModel();
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

        public void BindDictionaryData(AppDictionary appDictionary)
        {
            lblMale.Text = appDictionary.male;
            lblFemale.Text = appDictionary.female;
            plcName.Placeholder = appDictionary.namePlaceholder;
        }

        public void BindContentManagerToViewModel()
        {
            var vm = BindingContext as CharacterCreationPageViewModel;
            vm.BindCustomTextBindingPage(this);
        }

        public void BindAppDictionaryConsumerToViewModel()
        {
            var vm = BindingContext as CharacterCreationPageViewModel;
            vm.BindDictionaryConsumer(this);
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var vm = BindingContext as CharacterCreationPageViewModel;
            vm.CharacterCreation.Gender = !vm.CharacterCreation.Gender;
        }
    }
}
