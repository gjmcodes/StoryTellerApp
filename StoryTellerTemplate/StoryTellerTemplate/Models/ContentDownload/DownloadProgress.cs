using Prism.Mvvm;

namespace StoryTellerTemplate.Models.ContentDownload
{
    public class DownloadProgress : BindableBase
    {
        int progress;
        public int Progress
        {
            get => progress;
            set => SetProperty(ref progress, value);
        }
    }
}
