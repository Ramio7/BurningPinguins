using System;
using System.Threading.Tasks;
using UnityEngine;

public class ReviveTimer : Timer
{
    private Action<IPlayerView> _revivePLayerCallback;

    public ReviveTimer(float timerDuration, Action<IPlayerView> reviveTimerCallback) : base(timerDuration)
    {
        _timerDuration = timerDuration;
        _revivePLayerCallback = reviveTimerCallback;
        SetCancellationToken();
    }

    public async void Start(IPlayerView playerToRevive)
    {
        _timerTarget = Time.time + _timerDuration;
        _countdown = CountdownAsync();
        await Task.Run(() => _countdown, _cancellationToken);
        _revivePLayerCallback?.Invoke(playerToRevive);
    }
}
