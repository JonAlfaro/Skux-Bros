using UnityEngine;

public class CoolJumps : MonoBehaviour
{
    [Range(1, 15)]
    public float JumpVelocity = 5.5f;
    public float FallMultiplier = 3.5f;
    public float LowJumpMultiplier = 3f;
    public int JumpAmount = 2;

    private bool isPressingJump = false;
    private bool isStartingJump = false;
    private Rigidbody2D rb = null;

    private int jumpsRemaining;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = JumpAmount;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        jumpsRemaining = JumpAmount;
    }

    // Reading input should be done in Update and not in FixedUpdate
    void Update()
    {
        isPressingJump = Input.GetButton("Jump");
        if (Input.GetButtonDown("Jump")) isStartingJump = true;
    }

    // Physics changes should be done in FixedUpdate
    void FixedUpdate()
    {
        // Start jumping
        if (isStartingJump)
        {
            if (jumpsRemaining-- > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpVelocity);
            }
            isStartingJump = false; // Set false here instead of Update so that we act on the input at least once
        }

        // Affects fall speed
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.fixedDeltaTime;
        }
        // If not holding jump, fall back down faster
        else if (rb.velocity.y > 0 && !isPressingJump)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }
}
