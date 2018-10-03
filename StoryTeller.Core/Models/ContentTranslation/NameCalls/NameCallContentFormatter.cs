using StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly;
using StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly.NameCalls;
using System.Threading.Tasks;

namespace StoryTeller.Core.ContentTranslation.NameCalls
{
    public class NameCallContentFormatter : ContentFormatter
    {
        readonly INameCallLocalRepository _nameCallLocalRepository;
        readonly ICharacterDataLocalRepository _characterDataLocalRepository;

        public NameCallContentFormatter(INameCallLocalRepository nameCallLocalRepository, 
            ICharacterDataLocalRepository characterDataLocalRepository)
        {
            _nameCallLocalRepository = nameCallLocalRepository;
            _characterDataLocalRepository = characterDataLocalRepository;
        }

        public override async Task<string> GetFormattedContentAsync(string contentBetweenMarkers)
        {
            var pronoum = await _nameCallLocalRepository.GetPronoumByIdAsync(contentBetweenMarkers);
            var charData = await _characterDataLocalRepository.GetCharacterDataAsync();

            return charData.IsFemale ? pronoum.forFemale : pronoum.forMale; 
        }

        protected override void ReleaseResources()
        {
        }
    }
}
