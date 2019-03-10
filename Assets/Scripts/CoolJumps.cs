using UnityEngine;

public class CoolJumps : MonoBehaviour
{
    [Range(1, 15)]
    public float jumpVelocity = 5.5f;
    public float fallMultiplier = 3.5f;
    public float lowJumpMultiplier = 3f;

    private bool isPressingJump = false;
    private bool isStartingJump = false;
    private Rigidbody2D rb = null;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            isStartingJump = false; // Set false here instead of Update so that we act on the input at least once
        }

        // Affects fall speed
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        // If not holding jump, fall back down faster
        else if (rb.velocity.y > 0 && !isPressingJump)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }
}
