using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using CrownLoader;
using UnityEngine;
using UnityEngine.UI;
using CrownClient.Utils;
using VRC;
using LogType = CrownLoader.LogType;
using UnityEngine.SceneManagement;
using VRC.SDKBase;
using CrownClient.Wrappers;
using CrownClient.PhotonUtils;

namespace CrownClient
{
    public class ClientHook : MelonMod
    {
        private void Initialize()
        {
            Console.Title = "CrownClient by .Nova";
            Log.Message(LogType.Success, $"Successfully loaded CrownClient v{Assembly.GetExecutingAssembly().GetName().Version}");
            MelonHandler.Mods.Add(this);
            Patcher.Execute();
        }

        public override void OnUpdate()
        {
            if(Input.GetKeyDown(KeyCode.P))
            {

            }
            if(Input.GetKeyDown(KeyCode.L))
            {

            }
        }
    }
}