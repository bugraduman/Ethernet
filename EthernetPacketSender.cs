/*using System;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace Ethernet
{
    public class EthernetPacketSender
    {
        private static byte[] destinationMAC = { 0xA1, 0xB2, 0xC3, 0xD4, 0xE5, 0xF6 };

        public byte[] GetPacket(byte messageID, byte data)
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            PhysicalAddress sourceMAC = nics[0].GetPhysicalAddress();
            byte messageHeader1 = 0xaa;
            byte messageHeader2 = 0xbb;
            byte unused = 0x00;

            byte[] packet = new byte[17];
            Array.Copy(destinationMAC, 0, packet, 0, 6);
            Array.Copy(sourceMAC.GetAddressBytes(), 0, packet, 6, 6);
            packet[12] = messageHeader1;
            packet[13] = messageHeader2;
            packet[14] = messageID;
            packet[15] = unused;
            packet[16] = data;

            return packet;
        }


        //public static void Main()
        //{
        //    byte[] packet = GetPacket(10, 0x55);
        //    for (int i = 0; i < packet.Length; i++)
        //    {
        //        Console.Write("0x" + packet[i].ToString("X2") + " ");
        //    }
        //}
        // Other methods and class implementation...
    }
}*/