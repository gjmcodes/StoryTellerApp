using StoryTellerTemplate.Interfaces.Services.CharacterCreation;
using StoryTellerTemplate.Models.GameContent;
using StoryTellerTemplate.Models.MainPage;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoryTellerTemplate.Services.CharacterCreation
{
    public class CharacterCreationAppService : BaseAppService, ICharacterCreationAppService
    {
        public async Task<PageVm> GetCharacterCreationPageAsync()
        {
            var pagemock = new PageVm()
            {
                Actions = new List<GameActionVm>()
                {
                   new GameActionVm(){Description= "Ok", PageIdToFetch= "page-1" }
                },
                Content = new List<Span>()
                {
                    new Span(){ Text = "Você é um oficial de polícia novato. Seu nome é "}
                }
            };

            return pagemock;
        }
    }
}
