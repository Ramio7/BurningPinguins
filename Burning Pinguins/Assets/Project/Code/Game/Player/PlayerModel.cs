public static class PlayerModel
{
    public static void CatchBall(IBallView otherPlayerBall)
    {
        var otherPlayer = otherPlayerBall.MyPlayer;
        otherPlayer.PlayerView.IsWithBall = false;
        SetBallActive(otherPlayerBall, false);
    }

    public static void GiveBall(IPlayerView otherPlayer)
    {
        otherPlayer.IsWithBall = true;

        var otherBall = otherPlayer.Ball;
        SetBallActive(otherBall, true);
    }

    private static void SetBallActive(IBallView otherPlayerBall, bool isActive)
    {
        otherPlayerBall.MeshRenderer.enabled = isActive;
        otherPlayerBall.Collider.enabled = isActive;

        if (isActive) otherPlayerBall.Timer.Start();
        else otherPlayerBall.Timer.Stop();
    }
}
