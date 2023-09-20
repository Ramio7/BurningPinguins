using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Min(5.0f)] private float _cameraDistance;
    [SerializeField, Min(0.0f)] private float _cameraAngle;
    [SerializeField, Min(0.0f)] private float _cameraOffset;
    [SerializeField, Min(5.0f)] private float _cameraSpeed;
    [SerializeField, Min(5.0f)] private float _xAxisCameraFrame;
    [SerializeField, Min(5.0f)] private float _zAxisCameraFrame;

    private readonly Camera _camera;
    private readonly Transform _playerTransform;

    public CameraController(Camera mainCamera, Transform playerTransform)
    {
        _camera = mainCamera;
        _playerTransform = playerTransform;
        StartCameraFollowing(playerTransform);
    }

    public void StartCameraFollowing(Transform playerTransfrom)
    {
        _camera.transform.position = playerTransfrom.position + new Vector3(0, _cameraDistance, -_cameraOffset);
        var zAxis = new Vector3(0, 0, 1);
        _camera.transform.rotation.ToAngleAxis(out _cameraAngle, out zAxis);
        GameEntryPoint.Instance.OnUpdateEvent += Follow;
    }

    public void StopCameraFollowing() => GameEntryPoint.Instance.OnUpdateEvent -= Follow;

    private void Follow()
    {
        CalculateCameraFrame(out Vector3 cameraFrameCorner1, out Vector3 cameraFrameCorner2, out Vector3 cameraFrameCorner3, out Vector3 cameraFrameCorner4);
        if (_playerTransform.position.x >= cameraFrameCorner1.x || _playerTransform.position.x >= cameraFrameCorner2.x
            || _playerTransform.position.x <= cameraFrameCorner3.x || _playerTransform.position.x <= cameraFrameCorner4.x
            || _playerTransform.position.z >= cameraFrameCorner1.z || _playerTransform.position.z <= cameraFrameCorner2.z
            || _playerTransform.position.z >= cameraFrameCorner3.z || _playerTransform.position.z <= cameraFrameCorner4.z)
            _camera.transform.Translate(_playerTransform.position, Space.World);
    }

    private void CalculateCameraFrame(out Vector3 cameraFrameCorner1, out Vector3 cameraFrameCorner2, out Vector3 cameraFrameCorner3, out Vector3 cameraFrameCorner4)
    {
        cameraFrameCorner1 = _playerTransform.position + new Vector3(_xAxisCameraFrame / 2, 0, _zAxisCameraFrame / 2);
        cameraFrameCorner2 = _playerTransform.position + new Vector3(_xAxisCameraFrame / 2, 0, -_zAxisCameraFrame / 2);
        cameraFrameCorner3 = _playerTransform.position + new Vector3(-_xAxisCameraFrame / 2, 0, _zAxisCameraFrame / 2);
        cameraFrameCorner4 = _playerTransform.position + new Vector3(-_xAxisCameraFrame / 2, 0, -_zAxisCameraFrame / 2);
    }
}
