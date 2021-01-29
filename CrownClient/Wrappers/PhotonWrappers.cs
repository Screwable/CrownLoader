using Il2CppSystem.Collections.Generic;
using Il2CppSystem;
using ExitGames.Client.Photon;
using static CrownClient.PhotonUtils.OperationCode;
using static CrownClient.PhotonUtils.ParameterKey;

namespace CrownClient.Wrappers
{
    public static class PhotonWrappers
    {
        public static PhotonPeer PhotonPeer
        {
            get => _peer;
            set => _peer = value;
        }
        private static PhotonPeer _peer = null;

        public static void RaiseEvent(byte eventCode, object eventData, SendOptions options)
        {
            //Dictionary<byte, Object> parameters = new Dictionary<byte, Object>();
            //parameters[EventCode] = eventCode;

            //if (eventData != null)
            //    parameters[Data] = eventData;
        }
    }
}
