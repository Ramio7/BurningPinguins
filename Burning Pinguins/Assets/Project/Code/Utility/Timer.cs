using System;
using System.Threading.Tasks;
using UnityEngine;

public class Timer : IDisposable
{
    private readonly float _timerDuration;
    private float _timerTarget;

    private Task _countdown;

    public Timer(float timerDuration)
    {
        _timerDuration = timerDuration;
    }

    public async void Start()
    {
        _timerTarget = Time.time + _timerDuration;
        _countdown = CountdownAsync();
        await Task.Run(() => _countdown);
    }

    public void Stop()
    {
        _countdown.Dispose();
    }

    private Task CountdownAsync()
    {
        while (_timerTarget >= Time.time) return Task.Delay(1);
        return Task.FromResult(true);
    }

    public void Dispose()
    {
        _countdown?.Dispose();
        _countdown = null;
    }
}
