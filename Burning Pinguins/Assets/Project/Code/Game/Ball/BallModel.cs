using UnityEngine;

public static class BallModel
{
    public static void ThrowBall(IBallView ball, Vector3 ballDirection)
    {
        ball.IsThrown = true;
        ball.Rigidbody.useGravity = true;
        var ballVelocityVector = ballDirection * ball.BallSpeed;
        ballVelocityVector.y = ballDirection.y;
        ball.Rigidbody.AddForce(ballVelocityVector, ForceMode.VelocityChange); //придумать как ограничить скорость броска
    }

    public static void ReturnBall(IBallView ball)
    {
        ball.IsThrown = false;
        ball.Rigidbody.useGravity = false;
    }
}
