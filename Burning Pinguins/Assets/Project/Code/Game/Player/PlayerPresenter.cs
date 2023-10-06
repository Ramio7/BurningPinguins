using System;
using UnityEngine;

[RequireComponent(typeof(IPlayerView))]
public class PlayerPresenter : MonoBehaviour
{
    private IPlayerView _playerView;
    public IPlayerView PlayerView { get => _playerView; private set => _playerView = value; }

    public event Action<IPlayerView> OnPlayerShutDown;

    private void Awake()
    {
        PlayerView = GetComponent<IPlayerView>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (PlayerView.IsWithBall && collision.gameObject.TryGetComponent<PlayerPresenter>(out var player))
        {
            PlayerModel.GiveBall(player.PlayerView);
            PlayerModel.CatchBall(PlayerView.Ball);
        }

        if (collision.gameObject.TryGetComponent<IBallView>(out var ball))
        {
            PlayerModel.CatchBall(ball);
            PlayerModel.GiveBall(PlayerView);
        }
    }

    public void ShutDownPlayer() => OnPlayerShutDown?.Invoke(PlayerView);
}
