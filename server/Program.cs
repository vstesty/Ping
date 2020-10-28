using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server started!");
            UdpClient udpClient = new UdpClient(8080);

            while (true)

            {

                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                Byte[] receivedBytes = udpClient.Receive(ref RemoteIpEndPoint);

                string receiveData = Encoding.ASCII.GetString(receivedBytes);

                string returnData;

                if (receiveData == "turn=0")

                { send("ON", RemoteIpEndPoint.Address.ToString()); }

                else if (receiveData == "turn=1")

                { send("OFF", RemoteIpEndPoint.Address.ToString()); }
            }
        }

        static void send(string data, string tbHost)

        {

            UdpClient udpSendClient = new UdpClient(tbHost, 8080);

            Byte[] sendBytes = Encoding.ASCII.GetBytes(data); //Byte[] sendBytes = Encoding.ASCII.GetBytes(textBox1.Text);

            udpSendClient.Send(sendBytes, sendBytes.Length);

            Console.WriteLine(data);

        }
    }
}
