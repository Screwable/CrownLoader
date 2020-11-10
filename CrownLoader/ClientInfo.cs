using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrownLoader
{
    public class ClientInfo
    {
        public Version Version { get; }

        public ClientInfo(Version version)
        {
            Version = version;
        }
        
        public bool IsUpToDate()
        {
            return this.Version >= Version.Parse(API.RequestVersion().Result);
        }
    }
}
