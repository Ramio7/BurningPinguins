using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerGameStats), menuName = "ScriptableObjects/" + nameof(PlayerGameStats))]
public class PlayerGameStats : ScriptableObject, IPlayerCharacter
{
    [SerializeField] private float _playerSpeed = 10.0f;
    [SerializeField] private float _playerJumpForce = 2.0f;
    [SerializeField] private float _ballThrowForce = 50.0f;
    public float PlayerSpeed { get => _playerSpeed; }
    public float PLayerJumpForce { get => _playerJumpForce; }
    public float BallThrowForce { get => _ballThrowForce; }
}
