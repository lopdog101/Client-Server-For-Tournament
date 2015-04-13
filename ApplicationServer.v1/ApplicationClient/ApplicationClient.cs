using System;

namespace ApplicationClient
{
    class Program
    {
        // specify the port number of the application server
        public static void Main(string[] args)
        {
            Console.WriteLine("Application is running!");
            Console.WriteLine("Application-client[v.1]");
            Console.WriteLine("--------------------------------");
            
            Console.Write("Name_User:");
            var user = new UserData(Console.ReadLine());

            Console.Write("Name_Port:");
            user.SetPort(Console.ReadLine());

            Console.WriteLine("port the application server: ");

            Console.WriteLine("protocol_work:");

            ConnectedWithServer.Run(user.GetPort(), user.GetName());
        }
    }

}
