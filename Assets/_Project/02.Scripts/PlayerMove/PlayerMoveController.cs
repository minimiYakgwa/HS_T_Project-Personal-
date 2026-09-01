using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMoveController : MonoBehaviour
{
    // 기본 컴포넌트
    private Rigidbody _rigid;
    private Transform _cameraTransform;
   
    // 방향 변수
    private Vector3 _dir = Vector3.zero;
    private Quaternion _rotation = Quaternion.identity;
    private Vector2 _dirInput = Vector2.zero;

    // 사용자 설정 변수
    [Tooltip("사용자 설정 필드")]
    [SerializeField, Min(0f)] private float _moveSpeed;
    [SerializeField, Min(0f)] private float _rotationSpeed;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        _cameraTransform = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        CalculateDir();

        if (IsMoving())
        {
            Move();
            Rotate();
        }
    }

    // 이동 관련 메소드
    void Move()
    {
        _rigid.MovePosition(transform.position + _dir * _moveSpeed * Time.fixedDeltaTime);
    }
    void Rotate()
    { 
        _rigid.MoveRotation(Quaternion.RotateTowards(
            _rigid.rotation,
            _rotation,
            _rotationSpeed * Time.fixedDeltaTime));
    }
    bool IsMoving() => _dir.sqrMagnitude > 0.0001f;
    void OnMove(InputValue value)
    {
        _dirInput = value.Get<Vector2>();
    }
    void CalculateDir()
    {
        Vector3 right =
            Vector3.ProjectOnPlane(_cameraTransform.right, Vector3.up).normalized;
        Vector3 forward = Vector3.Cross(right, Vector3.up).normalized;

        _dir = Vector3.ClampMagnitude(
            right * _dirInput.x + forward * _dirInput.y, 1f);

        if (IsMoving())
            _rotation = Quaternion.LookRotation(_dir);
    }

    void OnAttack()
    {
        
    }
    

}
