using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerGameStats), menuName = "ScriptableObjects/" + nameof(PlayerGameStats))]
public class PlayerGameStats : ScriptableObject, IPlayerCharacter
{
    [SerializeField, Range(3f, 50f)] private float _playerBaseSpeed;
    [SerializeField, Range(3000f, 10000f)] private float _playerJumpForce;
    [SerializeField, Range(150f, 1000f)] private float _ballThrowForce;
    [SerializeField, Range(1.5f, 10f)] private float _sprintModifier;

    public float PlayerSpeed { get ; set; }
    public float PLayerJumpForce { get => _playerJumpForce; }
    public float BallThrowForce { get => _ballThrowForce; }
    public float PlayerBaseSpeed { get => _playerBaseSpeed; }
    public float SprintModifier { get => _sprintModifier; private set => _sprintModifier = value; }
}
