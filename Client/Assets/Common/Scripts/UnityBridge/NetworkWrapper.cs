using UnityEngine;
using System;

namespace BuildingBlocks
{
    /// <summary>
    /// Network wrapper implements the INetwork interface using the static methods from Network.
    /// </summary>
    public class NetworkWrapper : INetwork
    {
        /// <summary>
        /// Instantiate the specified prefab at location with the rotation for the group.
        /// </summary>
        /// <returns>The instantiated Object</returns>
        public object Instantiate(UnityEngine.Object prefab, Vector3 location, Quaternion rotation, int group)
        {
            return Network.Instantiate(prefab, location, rotation, group);
        }

        /// <summary>
        /// Initializes the server.
        /// </summary>
        /// <returns>The server.</returns>
        /// <param name="maxConnection">Max connection.</param>
        /// <param name="portnumber">Portnumber.</param>
        /// <param name="NATPunchthrough">If set to <c>true</c> NAT punchthrough.</param>
        public NetworkConnectionError InitializeServer(int maxConnection, int portnumber, bool NATPunchthrough)
        {
            return Network.InitializeServer(maxConnection, portnumber, NATPunchthrough);
        }

        public NetworkConnectionError Connect(string ip, int port)
        {
            return Network.Connect(ip, port);
        }

        public void Disconnect()
        {
            Network.Disconnect();
        }

        public void SetSendingEnabled(int group, bool enabled)
        {
            Network.SetSendingEnabled(group, enabled);
        }

        public void RemoveRPCs(NetworkViewID viewId)
        {
            Network.RemoveRPCs(viewId);
        }

        public void Destroy(NetworkViewID viewId)
        {
            Network.Destroy(viewId);
        }

        public bool isClient
        {
            get
            {
                return Network.isClient;
            }
        }

        public bool isServer
        {
            get
            {
                return Network.isServer;
            }
        }

        public bool isMessageQueueRunning
        {
            get
            {
                return Network.isMessageQueueRunning;
            }

            set
            {
                Network.isMessageQueueRunning = value;
            }
        }
    }
}
