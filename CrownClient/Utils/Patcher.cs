using CrownLoader;
using Harmony;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;
using Photon;
using ExitGames.Client.Photon;
using Newtonsoft.Json;
using VRC.SDKBase;
using CrownClient.PhotonUtils;
using CrownClient.Wrappers;
using SysCollections = System.Collections.Generic;

namespace CrownClient.Utils
{
    public static class Patcher
    {
        private static HarmonyInstance instance;

        public static void Execute()
        {
            try
            {
                instance = HarmonyInstance.Create("Patcher");
                instance.Patch(typeof(PortalTrigger).GetMethod("OnTriggerEnter", BindingFlags.Instance | BindingFlags.Public), FindPatch("AntiPortalPatch"));
                instance.Patch(typeof(PhotonPeer).GetMethod("SendOperation", BindingFlags.Instance | BindingFlags.Public), FindPatch("GetOperationData"));
                instance.Patch(typeof(PhotonPeer).GetMethod("SendOperation", BindingFlags.Instance | BindingFlags.Public), FindPatch("InstancePhotonPeer"));
            }
            catch(System.Exception e)
            {
                Log.Message(LogType.Error, $"Failed to patch method: {e}");
            }
            finally
            {
                Log.Message(LogType.Success, "Following patches loaded successfully: ", string.Join(", ", instance.GetPatchedMethods().Select(x => x.Name)));
            }
        }

        private static bool AntiPortalPatch()
        {
            return false;
        }

        private static bool GetOperationData(ref byte __0, ref Dictionary<byte, Object> __1, SendOptions __2)
        {
           SysCollections.List<string> dict = new SysCollections.List<string>();
            foreach (SysCollections.KeyValuePair<string, string> kvp in __1.ConvertToDictionary())
            {
                dict.Add($"[{kvp.Key}] = {kvp.Value}");
            }

            return true;
        }

        //store the photonpeer used by our client so we can use it later to send ops as we want
        //this is so stupid but it works
        private static bool InstancePhotonPeer(object __instance)
        {
            if (PhotonWrappers.PhotonPeer == null)
            {
                PhotonWrappers.PhotonPeer = (PhotonPeer)__instance;
                Log.Message(LogType.Misc, $"PhotonPeer successfully stored, client is able to send custom events!");
            }
            return true;
        }

        private static HarmonyMethod FindPatch(string method)
        {
            return new HarmonyMethod(typeof(Patcher).GetMethod(method, BindingFlags.Static | BindingFlags.NonPublic));
        }
    }
}
