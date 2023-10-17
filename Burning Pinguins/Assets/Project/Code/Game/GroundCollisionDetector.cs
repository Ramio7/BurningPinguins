using UnityEngine;

public class GroundCollisionDetector : MonoBehaviour
{
    [SerializeField] private float _collisionThreshold = 0.025f;
    private bool _isGrounded;
    private float _rayLength;

    public bool IsGrounded { get => _isGrounded; }

    private void OnEnable()
    {
        _rayLength = _collisionThreshold + transform.position.y + GetComponent<Collider>().bounds.min.y;
        GameEntryPoint.Instance.OnUpdateEvent += CheckIsOnGround;
    }

    private void OnDisable()
    {
        GameEntryPoint.Instance.OnUpdateEvent -= CheckIsOnGround;
    }

    private void CheckIsOnGround()
    {
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, _rayLength);
        Debug.DrawRay(transform.position, Vector3.down * _rayLength, Color.red);
        if (hit.collider != null) _isGrounded = true;
        else _isGrounded = false;
    }
}
