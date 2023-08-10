using System;
using Unity.Jobs;
using UnityEngine;

public class Command : ICommand, IDisposable
{
    public KeyCommandStruct KeyCommandStruct { get; private set; }

    private Action _activeCommand;

    public Command(KeyCommandStruct keyCommandStruct)
    {
        KeyCommandStruct = keyCommandStruct;
    }

    public void Init()
    {
        _activeCommand = KeyCommandStruct.Command;
        _activeCommand?.Invoke();
    }

    public void Dispose()
    {
        _activeCommand = null;
    }
}
