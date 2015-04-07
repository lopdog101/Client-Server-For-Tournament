using System;

namespace ApplicationServer.v1
{
    interface IGamePeer : IDisposable
    {
        void Send(string message);
        string Recv();
    }
}