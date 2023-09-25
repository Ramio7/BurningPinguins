using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField, Min(5.0f)] private float _cameraDistance;
    [SerializeField, Min(0.0f)] private float _cameraAngle;
    [SerializeField, Min(0.0f)] private float _cameraOffset;
    [SerializeField, Min(5.0f)] private float _cameraSpeed;
    [SerializeField, Min(5.0f)] private float _xAxisCameraFrame;
    [SerializeField, Min(5.0f)] private float _zAxisCameraFrame;
    [SerializeField] private Transform _playerPivot;
    [SerializeField] private Camera _camera;

    private void OnEnable()
    {
        _camera = Camera.main;
    }

    public void StartCameraFollowing()
    {
        _camera.transform.position = _playerPivot.position + new Vector3(0, _cameraDistance, -_cameraOffset);
        //var cameraLookPosition = допиши формулу расчёта стартового взгляда
        GameEntryPoint.Instance.OnUpdateEvent += Follow;
    }

    public void StopCameraFollowing() => GameEntryPoint.Instance.OnUpdateEvent -= Follow;

    private void Follow()
    {
        CalculateCameraFrame(out Vector3 cameraFrameCorner1, out Vector3 cameraFrameCorner2, out Vector3 cameraFrameCorner3, out Vector3 cameraFrameCorner4);
        if (_playerPivot.position.x >= cameraFrameCorner1.x || _playerPivot.position.x >= cameraFrameCorner2.x
            || _playerPivot.position.x <= cameraFrameCorner3.x || _playerPivot.position.x <= cameraFrameCorner4.x
            || _playerPivot.position.z >= cameraFrameCorner1.z || _playerPivot.position.z <= cameraFrameCorner2.z
            || _playerPivot.position.z >= cameraFrameCorner3.z || _playerPivot.position.z <= cameraFrameCorner4.z)
            _camera.transform.Translate(_playerPivot.position, Space.World);
    }

    private void CalculateCameraFrame(out Vector3 cameraFrameCorner1, out Vector3 cameraFrameCorner2, out Vector3 cameraFrameCorner3, out Vector3 cameraFrameCorner4)
    {
        cameraFrameCorner1 = _playerPivot.position + new Vector3(_xAxisCameraFrame / 2, 0, _zAxisCameraFrame / 2);
        cameraFrameCorner2 = _playerPivot.position + new Vector3(_xAxisCameraFrame / 2, 0, -_zAxisCameraFrame / 2);
        cameraFrameCorner3 = _playerPivot.position + new Vector3(-_xAxisCameraFrame / 2, 0, _zAxisCameraFrame / 2);
        cameraFrameCorner4 = _playerPivot.position + new Vector3(-_xAxisCameraFrame / 2, 0, -_zAxisCameraFrame / 2);
    }
}
