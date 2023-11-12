using UnityEngine;

public static class BallModel
{
    public static void ThrowBall(IBallView ball, Vector3 ballDirection)
    {
        ball.IsThrown = true;
        ball.Rigidbody.useGravity = true;
        ball.Rigidbody.velocity = Vector3.zero;
        var ballVelocityVector = ballDirection * ball.BallSpeed / ballDirection.magnitude;
        ballVelocityVector.y = ballDirection.y;
        ball.Rigidbody.AddForce(ballVelocityVector, ForceMode.VelocityChange);
    }

    public static void ReturnBall(IBallView ball)
    {
        ball.IsThrown = false;
        ball.Rigidbody.useGravity = false;
    }
}
