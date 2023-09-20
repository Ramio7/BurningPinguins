public interface IPlayerCharacter
{
    public float PlayerBaseSpeed { get; }
    public float PlayerSpeed { get; set; }
    public float SprintModifier { get; }
    public float PLayerJumpForce { get; }
    public float BallThrowForce { get; }
}
