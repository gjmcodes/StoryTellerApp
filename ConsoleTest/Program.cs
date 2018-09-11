using StoryTeller.Core.Services.Rooms;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new RoomActionService();
            var res = t.GetRoomActionsAsync("room-1").Result ;
            Console.WriteLine("Hello World!");
        }
    }
}
