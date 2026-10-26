using UnityEngine;
using UnityEngine.InputSystem;

public class Repaso : MonoBehaviour
{
    private Rigidbody2D _rBody;
    private Animator _animator;

    private InputAction _jumpAction;
    private InputAction _moveAction;
    private Vector2 _moveInput;

    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private float _jumpForce = 5f;

    [SerializeField] private Transform _groundSensor;
    [SerializeField] private float _sensorRadius = 0.5f;

    void Awake()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _jumpAction = InputSystem.actions["Jump"];
        _moveAction = InputSystem.actions["Move"];
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();

        if(_moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRunning", true);
        }
        else if(_moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }

        if(_jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            Jump();
        }

        _animator.SetBool("IsJumping", !IsGrounded());
    }

    void FixedUpdate()
    {
        _rBody.linearVelocityX = _moveInput.x * _movementSpeed;

        //_rBody.linearVelocity = new Vector2(_moveInput.x * _movementSpeed, _rBody.linearVelocity.y);
    }

    void Jump()
    {
        _rBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(_groundSensor.position, _sensorRadius);

        foreach (Collider2D item in collider2Ds)
        {
            if(item.gameObject.layer == 6)
            {
                return true;
            }
        }

        return false;
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundSensor.position, _sensorRadius);
    }
}
