using System.Collections.Generic;
using StoryTellerTemplate.Interfaces.Views;
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
            var vm = BindingContext as MainPageViewModel;
            vm.BindCustomTextBindingPage(this);
        }
    }
}