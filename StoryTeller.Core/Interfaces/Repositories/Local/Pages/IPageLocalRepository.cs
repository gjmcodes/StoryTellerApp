using StoryTeller.Core.Models.Pages.DTOs;
using StoryTeller.Core.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Repositories.Local.Pages
{
    public interface IPageLocalRepository : IBaseRepository
    {
        Task<TranslatedPageDto> GetPageByIdAsync(string pageId);
        Task<bool> AddPagesFromExternalDownloadAsync(IEnumerable<Page> entities);
    }
}
