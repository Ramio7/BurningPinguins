using System;

public class PlayerModel : IDisposable
{
    public void CatchBall(IBall ball)
    {
        ball.MeshRenderer.enabled = false;
        ball.Collider.enabled = false;
        ball.Timer.Stop();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
