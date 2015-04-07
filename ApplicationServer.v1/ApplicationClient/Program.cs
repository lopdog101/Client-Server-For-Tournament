using System;
using System.Text;
using System.IO;
using System.Net.Sockets;

namespace ApplicationClient
{
    class Program
    {
        // указание номера порта приложения-сервера
        public static void Main(string[] args)
        {
            Console.WriteLine("Application is running!");
            Console.WriteLine("Application-client[v.1]");
            Console.WriteLine("--------------------------------");

            Console.Write("Имя:");
            string UserName = Console.ReadLine();

            Console.WriteLine("port the application server: ");

            var ECHO_PORT = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Протокол работы:");

            try
            {
                // подсоединение к приложению-серверу 
                TcpClient eClient = new TcpClient("127.0.0.1", ECHO_PORT);

                // получение из соединения потока ввода
                StreamReader rs = new StreamReader(eClient.GetStream());

                // создание потока вывода для соединения
                NetworkStream ws = eClient.GetStream();

                // формирование текста, включающего имя клиента
                string dataToSend = UserName + "\r\n";

                // отсылка его на сервер
                byte[] data = Encoding.UTF8.GetBytes(dataToSend);
                ws.Write(data, 0, data.Length);

                // цикл диалога с сервером	
                while (true)
                {
                    // формируем сообщение для отсылки на сервер
                    Console.Write(UserName + ":");
                    dataToSend = Console.ReadLine();
                    dataToSend += "\r\n";

                    // отсылаем сообщение
                    data = Encoding.UTF8.GetBytes(dataToSend);
                    ws.Write(data, 0, data.Length);
                    // если хотим закончить диалог, вводим QUIT 

                    // и выходим из цикла, так как сервер на него не ответит
                    if (dataToSend.IndexOf("QUIT") > -1)
                        break;
                    
                    // ждем ответ от сервера
                    string returnData = rs.ReadLine();
                    
                    // печатаем полученное сообщение
                    Console.WriteLine("Сервер: " + returnData);
                }
                // сеанс диалога с сервером закончен, 
                // поэтому закрываем соединение	
                
                eClient.Close();
            }
            catch (Exception exp)
            {
                // вывод сообщения в случае возникновения оцибки
                Console.WriteLine("Исключение:" + exp);
            }
        }
    }

}
