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
            page.pageId = "page-1";
            page.content = new PageContent();
            page.content.content = @"

<p>- <namecall_formal>charId=0001</namecall_formal>. Wake up!</p>

<c-data_name></c-data_name> open <namecall_gender></namecall_gender> eyes and you see T-2, the robot assigned to help you. <namecall_gender></namecall_gender> head hurts and the last 
thing <namecall_gender></namecall_gender> can remember was fleeing in a pod from Zeta, a ship ruled by errand smugglers.

- T-2... what happened?

- Well, <namecall_formal></namecall_formal>, it seems like they didn't like your message and that you're terrible at poker.

";
            page.actions = new List<GameAction>()
            {
                new GameAction(){description = " ''Poker...? Message? What?'' ", pageIdToNavigate = "page-1-dialogue-1"},
                new GameAction(){description = " Stand up and look around", pageIdToNavigate = "page-2"}
            };


            pagesRepo.CreatePageAsync(page, "PT").Wait();

            Console.WriteLine("Hello World!");
        }
    }
}
