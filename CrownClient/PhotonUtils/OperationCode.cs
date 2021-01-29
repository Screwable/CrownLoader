using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrownClient.PhotonUtils
{
    public class OperationCode
    {
        public const byte Join = 255;
        public const byte Leave = 254;
        public const byte RaiseEvent = 253;
        public const byte SetProperties = 252;
        public const byte GetProperties = 251;
        public const byte Ping = 249;
        public const byte ChangeGroups = 248;
        public const byte Authenticate = 230;
        public const byte JoinLobby = 229;
        public const byte LeaveLobby = 228;
        public const byte CreateGame = 227;
        public const byte JoinGame = 226;
        public const byte JoinRandomGame = 225;
        public const byte DebugGame = 223;
        public const byte FindFriends = 222;
        public const byte LobbyStats = 221;
        public const byte Rpc = 219;
    }
}
