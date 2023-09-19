using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerGameStats), menuName = "ScriptableObjects/" + nameof(PlayerGameStats))]
public class PlayerGameStats : ScriptableObject, IPlayerCharacter
{
    [SerializeField] private float _playerBaseSpeed = 10.0f;
    [SerializeField] private float _playerJumpForce = 2.0f;
    [SerializeField] private float _ballThrowForce = 50.0f;
    [SerializeField] private float _sprintModifier = 1.5f;

    public float PlayerSpeed { get ; set; }
    public float PLayerJumpForce { get => _playerJumpForce; }
    public float BallThrowForce { get => _ballThrowForce; }
    public float PlayerBaseSpped { get => _playerBaseSpeed; }
    public float SprintModifier { get => _sprintModifier; private set => _sprintModifier = value; }
}
