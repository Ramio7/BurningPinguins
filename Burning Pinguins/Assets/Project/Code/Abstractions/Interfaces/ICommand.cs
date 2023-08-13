public interface ICommand
{
    public KeyCommandPair KeyCommandPair { get; }

    public void Init();
}
