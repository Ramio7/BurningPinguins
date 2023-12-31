using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Timer : ITimer, IDisposable
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

    public void Dispose()
    {
        _cancellationTokenSource.Dispose();
        _countdown?.Dispose();
    }

    public void Start()
    {
        _timerTarget = Time.time + _timerDuration;
        GameEntryPoint.Instance.OnFixedUpdateEvent += Countdown;
    }

    public void Stop()
    {
        _timerTarget = 0;
        GameEntryPoint.Instance.OnFixedUpdateEvent -= Countdown;
    }

    protected void Countdown()
    {
        if (_timerTarget >= Time.time) return;
        else
        {
            _timerCallback?.Invoke();
            Stop();
        }
    }

    public async void StartAsync()
    {
        _timerTarget = Time.time + _timerDuration;
        _countdown = CountdownAsync();
        await Task.Run(() => _countdown, _cancellationToken);

        if (_countdown.IsCompletedSuccessfully) _timerCallback?.Invoke();
    }

    public void StopAsync() => _cancellationTokenSource.Cancel();

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
