public static class PlayerModel
{
    public static void CatchBall(IBallView otherPlayerBall)
    {
        var otherPlayer = otherPlayerBall.MyPlayer;
        otherPlayer.PlayerView.IsWithBall = false;

        otherPlayerBall.MeshRenderer.enabled = false;
        otherPlayerBall.Collider.enabled = false;
        otherPlayerBall.Timer.Stop();
    }

    public static void GiveBall(IPlayerView otherPlayer)
    {
        otherPlayer.IsWithBall = true;

        var otherBall = otherPlayer.Ball;
        otherBall.MeshRenderer.enabled = true;
        otherBall.Collider.enabled = true;
        otherBall.Timer.Start();
    }
}
