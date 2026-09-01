using Unity.Cinemachine;
using UnityEngine;

public class SetCinemachineTrackingTarget : MonoBehaviour
{
    private CinemachineCamera _camera;
    private Transform _target;

    private void Awake()
    {
        _camera = GetComponent<CinemachineCamera>();
        _target = FindAnyObjectByType<PlayerMoveController>().transform;
        
    }
    void Start()
    {
        SetTrackingPlayer();
    }

    public void SetTrackingPlayer()
    {
        if (_camera != null)
        {
            if (_target == null)
                _target = FindAnyObjectByType<PlayerMoveController>().transform;
            _camera.Target.TrackingTarget = _target;
        }
    }

    
}
