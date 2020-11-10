using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace CrownLoader
{
    public static class Log
    {
        public static void Message(LogType lt, string content)
        {
            Console.ForegroundColor = SetColor(lt);
            string caller = Assembly.GetCallingAssembly().GetName().Name;
            string time = DateTime.Now.ToString("HH:mm:ss");

            Console.WriteLine("[{0}][{1}]: {2}", new object[]
                {
                    caller,
                    time,
                    content
                });

            Console.ResetColor();
        }

        private static ConsoleColor SetColor(LogType lt)
        {
            switch(lt)
            {
                case LogType.Error: return ConsoleColor.Red;
                case LogType.Success: return ConsoleColor.Green;
                case LogType.Misc: return ConsoleColor.Cyan;

                default: return ConsoleColor.Gray;
            }
        }

    }
    public enum LogType
    {
        Error,
        Success,
        Misc,
    }
}
