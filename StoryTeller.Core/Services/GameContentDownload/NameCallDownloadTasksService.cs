using StoryTeller.Core.Interfaces.Repositories.External.NameCalls;
using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.NameCalls;
using StoryTeller.Core.Interfaces.Services.GameContentDownload;
using StoryTeller.Core.Models.NameCalls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.GameContentDownload
{
    public class NameCallDownloadTasksService : BaseService, INameCallDownloadTasksService
    {
        private readonly IPronoumsNameCallsExternalRepository _pronoumsNameCallsExternalRepository;
        private readonly IPronoumLocalRepository _nameCallLocalPersistentRepository;

        public async Task<bool> DownloadPronoumNameCallsByCultureAsync(string culture)
        {
            var pronoums = await _pronoumsNameCallsExternalRepository.GetPronoumNameCallsByCultureAsync(culture);
            var result = await _nameCallLocalPersistentRepository.PersistNameCallsAsync(pronoums);

            return result;
        }
    }
}
