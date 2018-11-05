using StoryTeller.Core.Interfaces.Repositories.Local.CharactersData;
using StoryTeller.Core.Interfaces.Repositories.Local.NameCalls;
using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation.NameCalls
{
    public class NameCallContentFormatter : ContentFormatter
    {
        readonly IPronoumLocalRepository _pronoumLocalRepository;
        readonly ICharacterDataLocalRepository _characterDataLocalRepository;

        public NameCallContentFormatter(IPronoumLocalRepository nameCallLocalRepository, 
            ICharacterDataLocalRepository characterDataLocalRepository)
        {
            _pronoumLocalRepository = nameCallLocalRepository;
            _characterDataLocalRepository = characterDataLocalRepository;
        }

        public override async Task<string> GetFormattedContentAsync(string contentBetweenMarkers)
        {
            var pronoum = await _pronoumLocalRepository.GetPronoumByIdAsync(contentBetweenMarkers);
            var charData = await _characterDataLocalRepository.GetCharacterDataAsync();

            return charData.IsFemale ? pronoum.forFemale : pronoum.forMale; 
        }

        protected override void ReleaseResources()
        {
            _pronoumLocalRepository.Dispose();
            _characterDataLocalRepository.Dispose();
        }
    }
}
