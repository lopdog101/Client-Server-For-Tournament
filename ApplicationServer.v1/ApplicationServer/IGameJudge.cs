using System;

namespace ApplicationServer.v1
{
    internal interface IGameJudge : IDisposable
    {
        void Judge();
    }
}