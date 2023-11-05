public static class PlayerModel
{
    public static void CatchBall(IBallView ball, PlayerPresenter me) //продумай как теперь передавать мяч
    {
        var otherPlayer = ball.MyPlayer;
        otherPlayer.PlayerView.IsWithBall = false;

        SetBallActive(ball);
    }

    public static void GiveBall(IBallView ball, PlayerPresenter otherPlayer)
    {
        otherPlayer.PlayerView.IsWithBall = true;
        otherPlayer.PlayerView.Ball = ball;
        ball.StartingPoint = otherPlayer.PlayerView.BallStartingPosition;
        ball.MyPlayer = otherPlayer;

        SetBallActive(ball);
    }

    private static void SetBallActive(IBallView ball)
    {
        ball.IsThrown = false;

        ball.Timer.Stop();
        ball.SetTimer();
        ball.Timer.Start();
    }
}
