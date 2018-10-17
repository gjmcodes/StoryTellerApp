using StoryTellerTemplate.Models.ContentDownload;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Interfaces.ViewModels
{
    public interface IContentDownloader
    {
        DownloadProgress DownloadProgress {get; set;}
        void SetAmountOfTasks(int amount);
        void UpdateProgress();
    }
}
