using UnityEngine;

public interface IUiWindow
{
    public static Canvas Canvas { get; }
    public void OnEnable();
    public void OnDisable();
}
