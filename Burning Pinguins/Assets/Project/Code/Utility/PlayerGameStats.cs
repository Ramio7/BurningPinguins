using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerGameStats), menuName = "ScriptableObjects/" + nameof(PlayerGameStats))]
public class PlayerGameStats : ScriptableObject, IPlayerCharacter
{
    [SerializeField, Range(3f, 50f)] private float _playerBaseSpeed = 10.0f;
    [SerializeField, Range(1f, 15f)] private float _playerJumpForce = 2.0f;
    [SerializeField, Range(30f, 150f)] private float _ballThrowForce = 50.0f;
    [SerializeField, Range(1.5f, 10f)] private float _sprintModifier = 1.5f;

    public float PlayerSpeed { get ; set; }
    public float PLayerJumpForce { get => _playerJumpForce; }
    public float BallThrowForce { get => _ballThrowForce; }
    public float PlayerBaseSpped { get => _playerBaseSpeed; }
    public float SprintModifier { get => _sprintModifier; private set => _sprintModifier = value; }
}
