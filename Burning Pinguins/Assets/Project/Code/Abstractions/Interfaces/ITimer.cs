public interface ITimer
{
    void Start();
    void Stop();
    void StartAsync() { }
    void StopAsync() { }
}
