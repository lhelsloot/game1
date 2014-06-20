﻿using UnityEngine;
using BuildingBlocks.Team;
using BuildingBlocks.CubeFinger;

namespace BuildingBlocks.Player
{
    public interface IPlayer
    {
        ITeam Team { get; }
        ICubeFinger CubeFinger { get; set; }

        bool HasFullBlock { get; }

        void SetTeam(int teamId);
        void SetBlockType(bool isFullBlock, Color color);
    }
}
