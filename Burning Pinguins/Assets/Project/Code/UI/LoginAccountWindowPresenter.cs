using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class LoginAccountWindowPresenter : MonoBehaviour, IUiWindow
{
    public static Canvas Canvas { get; private set; }
}
