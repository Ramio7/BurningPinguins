using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Timer : IDisposable
{
    protected float _timerDuration;
    protected Task _countdown;
    protected float _timerTarget;
    protected CancellationTokenSource _cancellationTokenSource;
    protected CancellationToken _cancellationToken;

    private readonly Action _timerCallback;

    public Timer(float timerDuration)
    {
        _timerDuration = timerDuration;
        SetCancellationToken();
    }

    public Timer(float timerDuration, Action timerCallback)
    {
        _timerDuration = timerDuration;
        _timerCallback = timerCallback;
        SetCancellationToken();
    }

    public virtual async void Start()
    {
        _timerTarget = Time.time + _timerDuration;
        _countdown = CountdownAsync();
        await Task.Run(() => _countdown, _cancellationToken);
        if (_countdown.IsCompletedSuccessfully) _timerCallback?.Invoke();
    }

    public void Stop() => _cancellationTokenSource.Cancel();

    public void Dispose()
    {
        _cancellationTokenSource.Dispose();
        _countdown?.Dispose();
    }

    protected Task CountdownAsync()
    {
        while (_timerTarget >= Time.time) return Task.Delay(1);
        return Task.FromResult(true);
    }

    protected void SetCancellationToken()
    {
        _cancellationTokenSource = new();
        _cancellationToken = _cancellationTokenSource.Token;
    }
}
