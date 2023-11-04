using System;
using System.Threading.Tasks;
using UnityEngine;

public class ReviveTimer : Timer
{
    private Action<IPlayerView> _revivePLayerCallback;
    private IPlayerView _playerToRevive;

    public ReviveTimer(float timerDuration, Action<IPlayerView> reviveTimerCallback) : base(timerDuration)
    {
        _timerDuration = timerDuration;
        _revivePLayerCallback = reviveTimerCallback;
        SetCancellationToken();
    }

    public void Start(IPlayerView playerToRevive)
    {
        _timerTarget = Time.time + _timerDuration;
        _playerToRevive = playerToRevive;
        GameEntryPoint.Instance.OnFixedUpdateEvent += Countdown;
    }

    public new void Stop()
    {
        _playerToRevive = null;
        _timerTarget = 0;
        GameEntryPoint.Instance.OnFixedUpdateEvent -= Countdown;
    }

    public new void Countdown()
    {
        if (_timerTarget >= Time.time) return;
        else
        {
            _revivePLayerCallback?.Invoke(_playerToRevive);
            Stop();
        }
    }

    public async void StartAsync(IPlayerView playerToRevive)
    {
        _timerTarget = Time.time + _timerDuration;
        _countdown = CountdownAsync();
        await Task.Run(() => _countdown, _cancellationToken);
        _revivePLayerCallback?.Invoke(playerToRevive);
    }
}
