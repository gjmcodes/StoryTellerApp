﻿using StoryTeller.Core.Player;
using System.Threading.Tasks;

namespace StoryTeller.Core.Interfaces.Services.Player
{
    public interface IPlayerService
    {
        Task<PlayerStatusInventoryAggregate> GetPlayerStatusInventoryAsync();
    }
}
