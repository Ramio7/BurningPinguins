public static class BallModel
{
    public static void ReturnBall(IBallView ball)
    {
        var parentTransform = ball.StartingPoint;
        ball.BallPosition = parentTransform.position;
        ball.IsThrown = false;
    }
}
