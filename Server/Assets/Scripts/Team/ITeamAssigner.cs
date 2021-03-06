﻿using System.Collections.Generic;
using BuildingBlocks.Player;

namespace BuildingBlocks.Team
{
    public interface ITeamAssigner
    {
        int NumberOfTeams { get; }
        IEnumerable<ITeam> Teams { get; }

        void AddPlayer(IPlayer player);
        void RemovePlayer(IPlayer player);

        IPlayer GetPlayer(INetworkPlayer networkPlayer);
        ITeam GetTeam(int teamId);
    }
}
