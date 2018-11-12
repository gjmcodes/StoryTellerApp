using StoryTeller.Core.Interfaces.Repositories.CharactersData;
using StoryTeller.Core.Interfaces.Repositories.Pronoums;
using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation.NameCalls
{
    public class PronoumFormatter : ContentFormatter
    {
        readonly IPronoumRepository _pronoumRepository;
        readonly ICharacterDataRepository _characterDataRepository;

        public PronoumFormatter(IPronoumRepository pronoumRepository,
            ICharacterDataRepository characterDataRepository)
        {
            _pronoumRepository = pronoumRepository;
            _characterDataRepository = characterDataRepository;
        }

        public override async Task<string> GetFormattedContentAsync(string contentBetweenMarkers)
        {
            var pronoum = await _pronoumRepository.GetPronoumByIdAsync(contentBetweenMarkers);
            var charData = await _characterDataRepository.GetCharacterDataAsync();

            return charData.IsFemale ? pronoum.forFemale : pronoum.forMale; 
        }

        protected override void ReleaseResources()
        {
            _pronoumRepository.Dispose();
            _characterDataRepository.Dispose();
        }
    }
}
