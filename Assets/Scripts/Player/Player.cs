using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private Rigidbody2D _RB;

    public float moveSpeed;

    private void Awake()
    {
        Instance = this;

        _RB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        _RB.AddForce(Vector3.right * moveSpeed * Head.Instance.PlayerMoveDirection, ForceMode2D.Impulse);
    }
}
