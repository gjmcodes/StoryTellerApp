using System.Collections.Generic;
using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.Models.GameContent;
using StoryTellerTemplate.ViewModels;
using Xamarin.Forms;

namespace StoryTellerTemplate.Views
{
    public partial class MainPage : ContentPage, IGameContentManager
    {
        private FormattedString fortText;
        public MainPage()
        {
            InitializeComponent();

            fortText = new FormattedString();

            BindContentManagerToViewModel();
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

        public void BindContentManagerToViewModel()
        {
            var vm = BindingContext as MainPageViewModel;
            vm.BindCustomTextBindingPage(this);
        }

        public void BindTitle(string title)
        {
            throw new System.NotImplementedException();
        }

        public void BindImage(string image)
        {
            throw new System.NotImplementedException();
        }
    }
}