using StoryTellerTemplate.Models.ContentDownload;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Interfaces.ViewModels
{
    public interface IContentDownloader
    {
        void SetAmountOfTasks(int amount);
        void UpdateProgress();
    }
}
