using System;
using System.Collections.Generic;
using UnityEngine;

public class Command : ICommand, IDisposable
{
    public KeyCommandStruct KeyCommandStruct { get; private set; }

    public Command(List<KeyCode> keys, Action method)
    {
        KeyCommandStruct = new()
        {
            KeyCodes = keys,
            Command = method,
        };
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
