using StoryTellerTemplate.Interfaces.Views;
using StoryTellerTemplate.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StoryTellerTemplate.Views
{
    public partial class GamePage : ContentPage, IGameContentManager
    {
        private FormattedString fortText;
        public GamePage()
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
            var vm = BindingContext as GamePageViewModel;
            vm.BindCustomTextBindingPage(this);
        }
    }
}
