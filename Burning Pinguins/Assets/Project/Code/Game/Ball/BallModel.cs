using UnityEngine;

public static class BallModel
{
    public static void MoveBall(IBallView ball, Vector3 ballDirection)
    {
        var newBallPosition = ball.This.transform.position + ball.BallSpeed * Time.deltaTime * ballDirection;
        ball.This.transform.position = newBallPosition;
    }

    public static void ReturnBall(IBallView ball)
    {
        ball.IsThrown = false;
        ball.This.transform.position = ball.StartingPoint.position;
    }
}
