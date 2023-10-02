using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerGameCharacteristics), menuName = "ScriptableObjects/" + nameof(PlayerGameCharacteristics))]
public class PlayerGameCharacteristics : ScriptableObject, IPlayerCharacter
{
    [SerializeField, Range(3f, 50f)] private float _playerBaseSpeed;
    [SerializeField, Range(7000f, 20000f)] private float _playerJumpForce;
    [SerializeField, Range(150f, 1000f)] private float _ballThrowForce;
    [SerializeField, Range(1.5f, 10f)] private float _sprintModifier;

    public float PlayerSpeed { get ; set; }
    public float PLayerJumpForce { get => _playerJumpForce; }
    public float BallThrowForce { get => _ballThrowForce; }
    public float PlayerBaseSpeed { get => _playerBaseSpeed; }
    public float SprintModifier { get => _sprintModifier; }
}
