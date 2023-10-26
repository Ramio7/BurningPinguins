using System;
using System.Collections.Generic;
using UnityEngine;

public class Command : ICommand, IDisposable
{
    public KeyCommandPair KeyCommandPair { get; protected set; }

    public Command(List<KeyCode> keys, Action method)
    {
        KeyCommandPair = new(keys, method);
    }

    public void Init()
    {
        KeyCommandPair.Command?.Invoke();
    }

    public void Dispose()
    {
        KeyCommandPair.Dispose();
    }
}
