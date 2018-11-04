using Prism.Mvvm;
using StoryTellerTemplate.Interfaces.ViewModels;

namespace StoryTellerTemplate.Models.ContentDownload
{
    public class DownloadProgress : BindableBase, IContentDownloader
    {

        private bool _progressBarIsVisible;
        public bool ProgressBarIsVisible
        {
            get => _progressBarIsVisible;
            set => SetProperty(ref _progressBarIsVisible, value);
        }

        int amountOfTasks;
        double OneStep => amountOfTasks == 0 ? 0 : 1.0 / amountOfTasks;

        double progress;
        public double Progress
        {
            get => progress;
            set => SetProperty(ref progress, value);
        }

        public void SetAmountOfTasks(int amount)
        {
            amountOfTasks = amount;
        }

        public void UpdateProgress()
        {
            Progress += OneStep;
        }
    }
}
