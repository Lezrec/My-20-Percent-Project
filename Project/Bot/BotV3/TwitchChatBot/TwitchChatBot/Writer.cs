using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TwitchChatBot
{
    /// <summary>
    /// Writes to the client stream.
    /// </summary>
    internal static class Writer
    {
        private static StreamWriter writer;

        public static void Load(TcpClient client)
        {
            writer = new StreamWriter(client.GetStream());
            writer.AutoFlush = true; // Hopefully I don't need to flush any more?
        }

        public static void Write(string text)
        {
            writer.WriteLine(text);
        }
    }
}
