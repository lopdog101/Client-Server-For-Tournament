using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ApplicationClient
{
    class DataExchangeWithServer
    {
        public static void ExchangeWithServer(string userName, NetworkStream ws, StreamReader rs)
        {
            while (true)
            {
                // form a message for sending to the server
                Console.Write(userName + ":");
                string dataToSend = Console.ReadLine();
                dataToSend += "\r\n";

                // send a message
                byte[] data = Encoding.UTF8.GetBytes(dataToSend);
                ws.Write(data, 0, data.Length);
                // if we want to finish the dialogue, enter QUIT 

                // and exit the cycle, because the server didn't answer
                if (dataToSend.IndexOf("QUIT") > -1)
                    break;

                // waiting for a response from the server
                string returnData = rs.ReadLine();

                // print the received message
                Console.WriteLine("Server: " + returnData);
            }
        }
    }
}