using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField, Min(0.0f)] private float _cameraAngle;
    [SerializeField, Min(0.0f)] private float _cameraOffset;
    [SerializeField, Min(5.0f)] private float _cameraSpeed;
    [SerializeField] private Transform _playerPivot;
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3 _cameraPosition;

    private float _cameraNearClippingOffset = 0.1f;

    private void OnEnable()
    {
        _camera = Camera.main;
    }

    public void StartCameraFollowing()
    {
        _camera.nearClipPlane = _cameraOffset - _cameraNearClippingOffset;
        GameEntryPoint.Instance.OnUpdateEvent += Follow;
    }

    public void StopCameraFollowing() => GameEntryPoint.Instance.OnUpdateEvent -= Follow;

    private void Follow()
    {
        CalculateCameraPosition();
        CalculateCameraRotation();
    }

    private void CalculateCameraPosition()
    {
        var cameraPositionZCoord = _playerPivot.position.z - _cameraOffset * Mathf.Tan(_cameraAngle * Mathf.PI / 180);
        _camera.transform.position = new(_playerPivot.position.x, _cameraOffset, cameraPositionZCoord);
    }

    private void CalculateCameraRotation()
    {
        var lookPositionZCoord = _camera.transform.position.y * Mathf.Tan(_cameraAngle * Mathf.PI / 180) + _camera.transform.position.z;
        var cameraLookPosition = new Vector3(_camera.transform.position.x, 0, lookPositionZCoord);
        _camera.transform.LookAt(cameraLookPosition);
    }
}
