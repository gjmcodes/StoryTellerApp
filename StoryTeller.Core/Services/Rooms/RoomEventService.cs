﻿using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Interfaces.Repositories.Local;
using StoryTeller.Core.Interfaces.Services.Rooms;
using StoryTeller.Core.Rooms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryTeller.Core.Services.Rooms
{
    public class RoomEventService : IRoomEventService
    {

        private readonly IRoomEventLocalRepository _roomEventLocalRepository;
        private readonly IRoomEventExternalRepository _roomEventExternalRepository;

        public RoomEventService()
        {

        }

        public async Task<IEnumerable<RoomEvent>> GetRoomEventsAsync(string roomId)
        {
            var roomEvents = await _roomEventLocalRepository.GetRoomEventsAsync(roomId);

            if (roomEvents?.Count() > 0)
                return roomEvents;

            roomEvents = await _roomEventExternalRepository.GetRoomEventsAsync(roomId);

            return roomEvents;
        }
    }
}
