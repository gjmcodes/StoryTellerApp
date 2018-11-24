using StoryTeller.Core.Interfaces.Repositories.External.App;
using StoryTeller.Core.Models.Pronoums;
using StoryTeller.Xamarin.Domain.Entities.Pronoums;
using StoryTeller.Xamarin.Domain.Entities.Pronoums.Interfaces;
using StoryTeller.Xamarin.Domain.Entities.Pronoums.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.LocalData.Repositories.Pronoums
{
    public class PronoumLocalRepository : BaseRepository, IPronoumLocalRepository
    {
        private readonly IXamarinPronoumFactory _xamarinPronoumFactory;
        private readonly IAppUpdateExternalRepository _appUpdateExternalRepository;

        public PronoumLocalRepository(IXamarinPronoumFactory xamarinPronoumFactory,
            IAppUpdateExternalRepository appUpdateExternalRepository)
        {
            _xamarinPronoumFactory = xamarinPronoumFactory;
            _appUpdateExternalRepository = appUpdateExternalRepository;
        }

        public async Task<bool> AddPronoumsAsync(IEnumerable<Pronoum> pronoums)
        {
            var pronoumVersion = await _appUpdateExternalRepository.GetPronoumCurrentVersionByCultureAsync();

            var xamPronoums = await _xamarinPronoumFactory.MapPronoumToXamarin(pronoums, pronoumVersion.version);

            await Conn.InsertAllAsync(xamPronoums);

            return true;
        }

        public async Task<Pronoum> GetPronoumByIdAsync(string pronoumId)
        {
            var xamPronoum = await Conn.Table<XamarinPronoum>().FirstAsync(x => x.PronoumId == pronoumId);
            var pronoum = new Pronoum();

            pronoum.forFemale = xamPronoum.ForFemale;
            pronoum.forMale = xamPronoum.ForMale;
            pronoum.pronoumId = xamPronoum.PronoumId;

            return pronoum;
        }

        public async Task<int> GetVersionAsync()
        {
            var xamPronoum = await Conn.Table<XamarinPronoum>().FirstAsync();
            return xamPronoum.ExternalTableVersion;
        }

        protected override void ReleaseResources()
        {
            _xamarinPronoumFactory.Dispose();
            _appUpdateExternalRepository.Dispose();
            base.ReleaseResources();
        }
    }
}
