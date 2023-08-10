using System;
using System.Collections.Generic;
using UnityEngine;

public struct KeyCommandStruct
{
    public List<KeyCode> KeyCodes;
    public delegate void Command();

    //public KeyCommandStruct(List<KeyCode> keyCodes, )
    //{
    //    KeyCodes = keyCodes;
    //    Delegate.CreateDelegate(typeof(void), command.Method);
    //}
}
