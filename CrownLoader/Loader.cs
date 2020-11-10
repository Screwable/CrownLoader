using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using System.Reflection;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Threading;

namespace CrownLoader
{
    public class Loader : MelonMod
    {
        private object client;
        private ClientInfo clientInfo;
        private const string PATH = @"CrownClient\CrownClient.dll";

        public override void OnApplicationStart()
        {
            try
            {
                Console.Clear();
                if (!Directory.Exists("CrownClient"))
                {
                    Log.Message(LogType.Error, "Could not locate CrownClient folder.");
                    Log.Message(LogType.Misc, "Creating folder...");
                    Directory.CreateDirectory("CrownClient");
                    Log.Message(LogType.Success, "Successfully created folder for CrownClient!");
                    Thread.Sleep(2000);
                }
                if(!File.Exists(PATH))
                {
                    Log.Message(LogType.Error, "Could not locate CrownClient.dll.");
                    Log.Message(LogType.Misc, "Fetching client from web...");
                    API.DownloadClient();
                    Thread.Sleep(2000);
                }

                Assembly assembly = Assembly.LoadFile(PATH);
                clientInfo = new ClientInfo(assembly.GetName().Version);
                string expectedVersion = API.RequestVersion().Result;

                if(clientInfo.IsUpToDate())
                {
                    Log.Message(LogType.Success, "Client is up to date, hooking to VRChat.");
                    LoadClient(assembly);
                }
                else
                {
                    Log.Message(LogType.Error, $"Client is out of date, current version is {clientInfo.Version} but expected {expectedVersion}");
                    Log.Message(LogType.Misc, "Updating...");
                    assembly = null;
                    File.Delete(PATH);

                    API.DownloadClient();
                    Thread.Sleep(2000);

                    assembly = Assembly.LoadFile(PATH);

                    LoadClient(assembly);
                }
            }
            catch
            {

            }
        }

        private void LoadClient(Assembly assembly)
        {
            client = assembly.CreateInstance("CrownClient.ClientHook");
            client.GetType().GetMethod("Initialize", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(client, null);
        }
    }
}
