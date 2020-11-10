using CrownLoader;
using Harmony;
using Il2CppSystem;
using System.Reflection;

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
                Log.Message(LogType.Success, "Patches Successful");
            }
            catch
            {
                Log.Message(LogType.Error, "Failed to patch methods.");
            }
        }

        private static bool AntiPortalPatch()
        {
            return false;
        }

        private static HarmonyMethod FindPatch(string method)
        {
            return new HarmonyMethod(typeof(Patcher).GetMethod(method, BindingFlags.Static | BindingFlags.NonPublic));
        }
    }
}
