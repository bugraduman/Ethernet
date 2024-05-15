using System;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Net;
using System.Text;

namespace Ethernet
{
    public class EthernetPacketSender
    {
        private static byte[] destinationMAC = { 0xA1, 0xB2, 0xC3, 0xD4, 0xE5, 0xF6 };
        private TcpClient client;
        private NetworkStream stream;


        public void Start(string server, Int32 port)
        {
            client = new TcpClient(server, port);
            stream = client.GetStream();
        }

        public byte[] GetPacket(byte messageID, byte data)
        {
            byte[] packet = new byte[17];
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            PhysicalAddress sourceMAC = nics[0].GetPhysicalAddress();
            byte messageHeader1 = 0xaa;
            byte messageHeader2 = 0xbb;
            byte unused = 0x00;

            Array.Copy(destinationMAC, 0, packet, 0, destinationMAC.Length);
            Array.Copy(sourceMAC.GetAddressBytes(), 0, packet, 6, sourceMAC.GetAddressBytes().Length);
            packet[12] = messageHeader1;
            packet[13] = messageHeader2;
            packet[14] = messageID;
            packet[15] = unused;
            packet[16] = data;

            return packet;
        }

        public bool SendPackage(byte[] package)
        {
            if (IsConnected())
            {
                try
                {
                    stream.Write(package, 0, package.Length);
                    return true;
                }
                catch (NullReferenceException) { }
            }
            return false;
        }

        public bool IsConnected()
        {
            return client != null && client.Connected;
        }

        public void Stop()
        { 
            if (IsConnected())
            {
                client.Close();
                stream.Close();
            }
            
        }
    }
}