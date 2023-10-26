using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerGameCharacteristics), menuName = "ScriptableObjects/" + nameof(PlayerGameCharacteristics))]
public class PlayerGameCharacteristics : ScriptableObject, IPlayerCharacter
{
    [SerializeField, Range(3f, 50f)] private float _playerBaseSpeed;
    [SerializeField, Range(0.0f, 10.0f)] private float _playerJumpHeight;
    [SerializeField, Range(1.5f, 10f)] private float _sprintModifier;

    public float PlayerSpeed { get; set; }
    public float PLayerJumpHeight { get => _playerJumpHeight; }
    public float PlayerBaseSpeed { get => _playerBaseSpeed; }
    public float SprintModifier { get => _sprintModifier; }
}
