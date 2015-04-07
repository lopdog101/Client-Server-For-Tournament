using System;

namespace ApplicationServer.v1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application is running!");
            Console.WriteLine("Echo-server[v.1]");
            Console.WriteLine("--------------------------------");

            Console.WriteLine("Enter the port number for reading: ");
            int portNumber = Convert.ToInt32(Console.ReadLine());

            var factory = new CrossGameJudgeFactory();
            new GameServer(factory, portNumber).Run();
        }
    }
}
