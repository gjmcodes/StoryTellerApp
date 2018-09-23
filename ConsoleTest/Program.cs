using StoryTeller.Core.Actions;
using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Repositories.External.Persistence.Pages;
using StoryTeller.Core.Pages;
using StoryTeller.Core.Services.Rooms;
using StoryTeller.CrossCutting.User.Preferences;
using StoryTeller.ExternalData.FireBase.Dialogues;
using StoryTeller.ExternalData.FireBase.Pages;
using StoryTeller.ExternalData.FireBase.Persistent.Pages;
using StoryTeller.ExternalData.FireBase.Rooms;
using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //IPageExternalRepository pageRepo = new PageWs(new UserPreferences());
            //var t = pageRepo.GetPageByIdAsync("page-1").Result;

            IPageExternalPersistentRepository pagesRepo = new PagePersistentWs(new UserPreferences());

            var page = new Page();
            page.pageId = "page-2";
            page.content = new PageContent();
            page.content.content = "<p>Teste 2 teste 2 teste 2</p>";
            page.actions = new List<GameAction>()
            {
                new GameAction(){description = "Ação 4", pageIdToNavigate = "page-1"}
            };


            pagesRepo.CreatePageAsync(page, "PT").Wait();

            Console.WriteLine("Hello World!");
        }
    }
}
