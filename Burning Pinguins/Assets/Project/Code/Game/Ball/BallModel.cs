using UnityEngine;

public static class BallModel
{
    public static void MoveBall(IBallView ball, Vector3 ballDirection)
    {
        ball.IsThrown = true;
        var newBallPosition = ball.BallPosition.position + ball.BallSpeed * Time.deltaTime * ballDirection;
        ball.BallPosition.position.Set(newBallPosition.x, newBallPosition.y, newBallPosition.z);
    }

    public static void ReturnBall(IBallView ball)
    {
        ball.IsThrown = false;
        ball.BallPosition.position = ball.StartingPoint.position;
    }
}
