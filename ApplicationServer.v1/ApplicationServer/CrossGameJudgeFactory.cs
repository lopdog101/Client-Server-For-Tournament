namespace ApplicationServer.v1
{
    class CrossGameJudgeFactory : IGameJudgeFactory
    {
        public IGameJudge CreateJudge(IGamePeer left, IGamePeer right)
        {
            return new CrossGameJudge(left, right);
        }
    }
}