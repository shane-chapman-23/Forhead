using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private Rigidbody2D _RB;
    private PlayerInputHandler _inputHandler;

    [Header("Movement")]
    public float moveSpeed;
    [Header("Jumping")]
    public float jumpPower;

    private void Awake()
    {
        Instance = this;

        _RB = GetComponent<Rigidbody2D>();
        _inputHandler = GetComponent<PlayerInputHandler>();
    }

    private void FixedUpdate()
    {
        PlayerMove();
        PlayerJump();
    }

    private void PlayerMove()
    {
        Vector3 newVelocity = Vector3.right * moveSpeed * Head.Instance.PlayerMoveDirection;

        _RB.linearVelocity = newVelocity;
    }

    private void PlayerJump()
    {
        if (_inputHandler.JumpPressed)
        {
            _RB.linearVelocity = new Vector2(_RB.linearVelocity.x, jumpPower);
        }

    }
}
