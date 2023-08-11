using System;
using System.Collections.Generic;
using UnityEngine;

public struct KeyCommandStruct : IDisposable
{
    public List<KeyCode> KeyCodes;
    public Action Command;

    public KeyCommandStruct(List<KeyCode> keyCodes, Action method)
    {
        KeyCodes = keyCodes;
        Command = method;
    }

    public void Dispose()
    {
        KeyCodes = null;
        Command = null;
    }
}
