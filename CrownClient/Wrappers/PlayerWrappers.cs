using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC.Core;
using VRC;

namespace CrownClient.Utils
{
    public static class PlayerWrappers
    {
        public static PlayerManager Instance() => PlayerManager.field_Private_Static_PlayerManager_0;
        public static VRCPlayer GetMe(this PlayerManager manager) => manager.field_Private_List_1_Player_0[0].field_Internal_VRCPlayer_0;
        public static List<Player> GetAllPlayers(this PlayerManager manager) => manager.prop_ArrayOf_Player_0.ToList();
        public static APIUser GetUser(this Player p) => p.field_Private_APIUser_0;
        public static Player GetVRC_Player(this VRCPlayer p) => p.field_Private_Player_0;
        public static Player GetPlayer(this PlayerManager manager, string id)
        {
            List<Player> players = manager.GetAllPlayers();
            Player result = null;
            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];
                if (player.GetUser().displayName.ToLower().Contains(id.ToLower()))
                    result = player;
            }
            return result;
        }
        public static Player GetPlayer(this PlayerManager manager, int photon)
        {
            List<Player> players = manager.GetAllPlayers();
            Player result = null;
            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];
                if (player.GetComponent<Photon.Pun.PhotonView>().viewIdField == photon)
                    result = player;
            }

            return result;
        }
    }
}
