using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerView))]
public class PlayerPresenter : MonoBehaviour
{
    [Inject] private PlayerModel _playerModel;
    private PlayerView _playerView;

    private void Awake()
    {
        _playerView = GetComponent<PlayerView>();
    }
}
