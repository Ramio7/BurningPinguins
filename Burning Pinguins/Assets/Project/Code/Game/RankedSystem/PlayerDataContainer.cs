using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataContainer : MonoBehaviour
{
    [SerializeField] private PlayerGameCharacteristics _characteristics;

    public static PlayerDataContainer Instance;

    private void OnEnable()
    {
        DontDestroyOnLoad(this);
        Instance = this;
    }

    private void OnDisable()
    {
        
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    public PlayerGameCharacteristics GetPlayerCharacteristics() => _characteristics;
}
