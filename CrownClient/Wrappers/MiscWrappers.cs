using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using VRC.Core;

namespace CrownClient.Utils
{
    public static class MiscWrappers
    {
        public static QuickMenu GetQuickMenu() => (QuickMenu)typeof(QuickMenu).GetProperties().First(x => x.PropertyType == typeof(QuickMenu)).GetGetMethod().Invoke(null, null);
        public static APIUser GetTargetPlayer() => (APIUser)typeof(QuickMenu).GetProperties().First(x => x.PropertyType == typeof(APIUser)).GetValue(GetQuickMenu());
    }
}
