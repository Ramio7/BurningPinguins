using System;
using System.Collections.Generic;
using UnityEngine;

public class Command : ICommand, IDisposable
{
    public KeyCommandPair KeyCommandStruct { get; protected set; }

    public Command(List<KeyCode> keys, Action method)
    {
        KeyCommandStruct = new(keys, method);
    }

    public void Init()
    {
        KeyCommandStruct.Command?.Invoke();
    }

    public void Dispose()
    {
        KeyCommandStruct.Dispose();
    }
}
