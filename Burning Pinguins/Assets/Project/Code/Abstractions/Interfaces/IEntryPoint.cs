using System;

public interface IEntryPoint
{
    public event Action OnUpdateEvent;

    public event Action OnFixedUpdateEvent;

    public static IEntryPoint Instance;
}
