using System;
using System.Collections.Generic;
using UnityEngine;

public class KeyCommandPair : IDisposable
{
    public List<KeyCode> KeyCodes;
    public Action Command;

    public KeyCommandPair(List<KeyCode> keyCodes, Action method)
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
