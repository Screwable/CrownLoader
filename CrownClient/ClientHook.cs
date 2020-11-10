using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using CrownLoader;
using UnityEngine;
using CrownClient.Utils;
using VRC;
using LogType = CrownLoader.LogType;

namespace CrownClient
{
    public class ClientHook : MelonMod
    {
        private Settings _Settings;

        private void Initialize()
        {
            Console.Title = "CrownClient by .Nova";
            Log.Message(LogType.Success, $"Successfully loaded CrownClient v{Assembly.GetExecutingAssembly().GetName().Version}");
            MelonHandler.Mods.Add(this);
            _Settings = new Settings();
            Patcher.Execute();
        }
    }
}