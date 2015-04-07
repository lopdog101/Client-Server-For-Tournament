namespace ApplicationServer.v1
{
    interface IGameJudgeFactory
    {
        IGameJudge CreateJudge(IGamePeer left, IGamePeer right);
    }
}