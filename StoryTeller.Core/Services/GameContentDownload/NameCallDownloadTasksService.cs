using StoryTeller.Core.Interfaces.Repositories.External.Pronoums;
using StoryTeller.Core.Interfaces.Repositories.Local.NameCalls;
using StoryTeller.Core.Interfaces.Services.GameContentDownload;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.GameContentDownload
{
    public class NameCallDownloadTasksService : BaseService, INameCallDownloadTasksService
    {
        private readonly IPronoumsNameCallsExternalRepository _pronoumsNameCallsExternalRepository;
        private readonly IPronoumLocalRepository _nameCallLocalPersistentRepository;

        public NameCallDownloadTasksService(
            IPronoumsNameCallsExternalRepository pronoumsNameCallsExternalRepository,
            IPronoumLocalRepository nameCallLocalPersistentRepository)
        {
            _pronoumsNameCallsExternalRepository = pronoumsNameCallsExternalRepository;
            _nameCallLocalPersistentRepository = nameCallLocalPersistentRepository;
        }

        public async Task<bool> DownloadPronoumNameCallsByCultureAsync(string culture)
        {
            var pronoums = await _pronoumsNameCallsExternalRepository.GetPronoumNameCallsByCultureAsync(culture);
            var result = await _nameCallLocalPersistentRepository.PersistNameCallsAsync(pronoums);

            return result;
        }
    }
}
