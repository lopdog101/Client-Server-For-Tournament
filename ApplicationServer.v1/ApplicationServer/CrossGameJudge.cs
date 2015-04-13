using System;

namespace ApplicationServer.v1
{
    class CrossGameJudge : BaseGameJudge
    {
        private bool _isFinished;
        private byte [,] _battleField = new byte[3, 3];

        public CrossGameJudge(IGamePeer left, IGamePeer right) : base(left, right)
        {
        }

        public override void Judge()
        {
            //while (!_isFinished)
            //{
            //    var move = ReadLeftMove();

            //    Estimate(move);

            //    if (_isFinished)
            //    {
            //        SendLeftWin();
            //        SendRightLoose();
            //        break;
            //    }

            //    SendRightMove(move);

            //    move = ReadRightMove();

            //    Estimate(move);
            //    if (_isFinished)
            //    {
            //        SendRightWin();
            //        SendLeftLoose();
            //        break;
            //    }

            //    SendLeftMove(move);
            //}
        }
    }
}