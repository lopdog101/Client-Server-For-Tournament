using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ApplicationServer.v1
{
    class GameServer
    {
        private readonly IGameJudgeFactory _judgeFactory;
        private readonly int _portNumber;

        private TcpListener _listener;

        public GameServer(IGameJudgeFactory judgeFactory, int portNumber)
        {
            _judgeFactory = judgeFactory;
            _portNumber = portNumber;
        }

        public void Run()
        {
            try
            {
                StartListen();

                RunClientsLoop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Исключение:" + ex);
            }
            finally
            {
                if (_listener != null)
                    _listener.Stop();
            }
        }

        private void StartListen()
        {
            _listener = new TcpListener(new IPEndPoint(0, _portNumber));

            _listener.Start();

            Console.WriteLine("Server waits ...");
        }

        private void RunClientsLoop()
        {
            TcpClient left = null;
            TcpClient right = null;

            while (true)
            {
                var client = _listener.AcceptTcpClient();
                if (left == null)
                    left = client;
                else
                    right = client;

                bool hasPair = right != null;
                if (hasPair)
                {
                    var gameJudge = _judgeFactory.CreateJudge(new GamePeer(left), new GamePeer(right));
                    var thread = new Thread(gameJudge.Judge);
                    thread.Start();

                    left = null;
                    right = null;
                }
            }
        }
    }
}