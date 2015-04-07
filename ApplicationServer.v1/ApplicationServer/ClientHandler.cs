using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ApplicationServer.v1
{
    public class ClientHandler
    {
        // сокет клиента
        public TcpClient clSocket;

        // метод осуществления диалога с клиентом	
        public void RunClient()
        {
            // создание потоков ввода и вывода с приложением-клиентом

            StreamReader rs = new StreamReader(clSocket.GetStream());
            NetworkStream ws = clSocket.GetStream();

            // получение имени клиента, который подключился к серверу

            string returnData = rs.ReadLine();
            string userName = returnData;
            Console.WriteLine(userName + " на сервере");

            // цикл диалога с клиентом
            while (true)
            {
                // получение сообщения от клиента	
                returnData = rs.ReadLine();

                // если клиент перешлет собщение QUIT, диалог заканчивается

                if (returnData.IndexOf("QUIT") > -1)
                {
                    Console.WriteLine(userName + " is offline.");
                    break;
                }
                Console.WriteLine(userName + ": " + returnData);
                returnData += "\r\n";

                Console.Write("server:");
                string str = Console.ReadLine();

                // сервер формирует и отсылает полученное 
                // сообщение – отзывается «эхом» 

                byte[] dataWrite = Encoding.UTF8.GetBytes(str + "\r\n");

                ws.Write(dataWrite, 0, dataWrite.Length);
            }
            // закрывает сокет после окончания диалога
            clSocket.Close();
        }
    }
}