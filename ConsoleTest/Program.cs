using StoryTeller.Core.Services.Rooms;
using StoryTeller.CrossCutting.User.Preferences;
using StoryTeller.ExternalData.FireBase.Dialogues;
using StoryTeller.ExternalData.FireBase.Rooms;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new DialogueWs(new UserPreferences());
            var res = t.GetDialogueById("diag-1").Result;

            //var t2 = new RoomEventWs();
            //var res2 = t2.GetRoomEventsAsync("room-1").Result;

            //var t3 = new RoomContentWs();
            //var res3 = t3.GetRoomDefaultContentAsync("room-1").Result;
            //var res4 = t3.GetRoomContentByIdAsync("room-1","room-content-1").Result;
            Console.WriteLine("Hello World!");
        }
    }
}
