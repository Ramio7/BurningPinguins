using UnityEngine;

[RequireComponent(typeof(IPlayerController))]
public abstract class UserInput : MonoBehaviour
{
    protected IPlayerController PlayerController => gameObject.GetComponent<IPlayerController>();
    protected ColliderContactController ContactController;

    public void OnEnable()
    {
        GameEntryPoint.Instance.OnUpdateEvent += OnUpdate;
        ContactController = new(PlayerController.Collider);
    }

    public void OnDisable()
    {
        GameEntryPoint.Instance.OnUpdateEvent -= OnUpdate;
        ContactController?.Dispose();
    }

    protected void OnUpdate()
    {
        Move();
        Sprint();
        Jump();
        Throw();
    }

    protected abstract void Move();
    protected abstract void Sprint();
    protected abstract void Jump();
    protected abstract void Throw();
}
