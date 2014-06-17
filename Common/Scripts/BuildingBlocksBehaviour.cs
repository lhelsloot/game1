﻿
namespace BuildingBlocks
{
    public abstract class BuildingBlocksBehaviour : IBuildingBlocksBehaviour
    {
        public IGameObject gameObject { get; private set; }
        public INetworkView networkView { get; private set; }

        protected BuildingBlocksBehaviour(IGameObject gameObject)
        {
            this.gameObject = gameObject;

            if (gameObject != null)
            {
                this.networkView = gameObject.networkView;
            }
        }
    }
}
