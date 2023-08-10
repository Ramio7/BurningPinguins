using System;
using System.Collections.Generic;
using UnityEngine;

public struct KeyCommandStruct
{
    public List<KeyCode> KeyCodes;
    public Action Command;

    public KeyCommandStruct(List<KeyCode> keyCodes, Action command)
    {
        KeyCodes = keyCodes;
        Command = command;
    }
}
