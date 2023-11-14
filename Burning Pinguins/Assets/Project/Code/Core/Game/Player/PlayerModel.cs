using UnityEngine;

public static class PlayerModel
{
    public static void CatchBall(IBallView ball, PlayerPresenter me)
    {
        var otherPlayer = ball.MyPlayer;
        otherPlayer.PlayerView.IsWithBall = false;

        SetBallActive(ball, me);
    }

    public static void GiveBall(IBallView ball, PlayerPresenter otherPlayer)
    {
        otherPlayer.PlayerView.IsWithBall = true;
        otherPlayer.PlayerView.Ball = ball;
        ball.StartingPoint = otherPlayer.PlayerView.BallStartingPosition;
        ball.MyPlayer = otherPlayer;

        SetBallActive(ball, otherPlayer);
    }

    private static void SetBallActive(IBallView ball, PlayerPresenter playerWithBall)
    {
        ball.IsThrown = false;
        ball.GameObject.GetComponent<MeshRenderer>().enabled = true;

        ball.Timer?.Stop();
        ball.SetTimer(playerWithBall);
        ball.Timer.Start();
    }
}
