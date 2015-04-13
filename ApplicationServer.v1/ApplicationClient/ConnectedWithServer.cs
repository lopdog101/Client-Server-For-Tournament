using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ApplicationClient
{
    class ConnectedWithServer
    {
        public static void Run(int echoPort, string userName)
        {
            try
            {
                // connecting to the application server
                TcpClient eClient = new TcpClient("127.0.0.1", echoPort);

                // receiving from the connection input stream
                StreamReader rs = new StreamReader(eClient.GetStream());

                // create the output stream for the connection
                NetworkStream ws = eClient.GetStream();

                // formation of the text, including the name of the customer
                string dataToSend = userName + "\r\n";

                // sending it to the server
                byte[] data = Encoding.UTF8.GetBytes(dataToSend);
                ws.Write(data, 0, data.Length);

                //dialog with server	
                DataExchangeWithServer.ExchangeWithServer(userName, ws, rs);
                //closing connection	

                eClient.Close();
            }
            catch (Exception exp)
            {
                //display message in case of error
                Console.WriteLine("Exeption:" + exp);
            }
        }
    }
}