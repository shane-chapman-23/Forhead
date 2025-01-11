using UnityEngine;

public class Head : MonoBehaviour
{
    public static Head Instance;

    private PlayerInputHandler _inputHandler;
    private HingeJoint2D _hingeJoint;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    public int PlayerMoveDirection { get; private set; }
    public int PlayerFacingDirection { get; private set; } = 1;

    private int _inputX;
    private float _rotationSpeed;
    private float _headGravity = 50f;
    private Vector3 _headAngle;

    private void Awake()
    {

        Instance = this;

        _inputHandler = GetComponentInParent<PlayerInputHandler>();
        _hingeJoint = GetComponent<HingeJoint2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _headAngle = transform.eulerAngles;
        _inputX = _inputHandler.NormInputX;

        CalculateHeadRotationSpeed();
        RotateHead();
        SetFacingDirection();
        SetMoveDirection();
    }

    private void RotateHead()
    {
        JointMotor2D motor = _hingeJoint.motor;

        if (_inputHandler.NormInputX == 0)
        {
            _hingeJoint.useMotor = true;
            motor.motorSpeed = _headGravity * PlayerMoveDirection;
            _hingeJoint.motor = motor;
            return;
        }
        _hingeJoint.useMotor = true;
        motor.motorSpeed = _rotationSpeed * _inputHandler.NormInputX;
        _hingeJoint.motor = motor;
    }


    private void CalculateHeadRotationSpeed()
    {
        if  (_inputX == -1 && _headAngle.z < 180 && _headAngle.z > 10 || _inputX == 1 && _headAngle.z < 350 && _headAngle.z > 100)
        {
            _rotationSpeed = 200;
        }
        else
        {
            _rotationSpeed = 100;
        }
    }

    private void CalculateHeadGravity()
    {

    }

    private void SetMoveDirection()
    {
        if (_headAngle.z > 180 && _headAngle.z < 360)
        {
            PlayerMoveDirection = 1;
        }
        else if (_headAngle.z > 0 && _headAngle.z < 180)
        {
            PlayerMoveDirection = -1;
        }
    }

    private void SetFacingDirection()
    {
        if (_headAngle.z > 180 && _headAngle.z < 330)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_headAngle.z > 30 && _headAngle.z < 180)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
