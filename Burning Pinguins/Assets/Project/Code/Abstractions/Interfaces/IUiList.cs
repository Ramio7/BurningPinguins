using UnityEngine;

public interface IUiList
{
    public Transform ListTransform { get; }
    public void OnEnable();
    public void OnDisable();
}
