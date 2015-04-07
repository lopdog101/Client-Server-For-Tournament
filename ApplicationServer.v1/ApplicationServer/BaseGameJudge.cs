namespace ApplicationServer.v1
{
    abstract class BaseGameJudge : IGameJudge
    {
        private readonly IGamePeer _left;
        private readonly IGamePeer _right;

        protected BaseGameJudge(IGamePeer left, IGamePeer right)
        {
            _left = left;
            _right = right;
        }

        protected string ReadFromLeft()
        {
            return _left.Recv();
        }

        protected void SendToLeft(string message)
        {
            _left.Send(message);
        }

        protected string ReadFromRight()
        {
            return _right.Recv();
        }

        protected void SendToRight(string message)
        {
            _right.Send(message);
        }

        public void Dispose()
        {
            _left.Dispose();
            _right.Dispose();
        }

        public abstract void Judge();
    }
}