using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rb = null;
    private Animator animator = null;
    private string playerComponentStringOfHell = "";
    private bool facingRight = true;
    private int tick;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (!GetComponent<Player>().PlayerOne)
        {
            playerComponentStringOfHell = "-p2";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity.x);
        if (rb.velocity.x < -0.1)
        {
            if (facingRight) FlipGameObject();
        }
        if (rb.velocity.x > 0.1)
        {
            if (!facingRight) FlipGameObject();
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (Input.GetButtonDown($"Jump{playerComponentStringOfHell}"))
        {
            animator.Play("Player_Jump");
        }

        animator.SetBool("Crouching", Input.GetButton("Crouch"));

        if (playerComponentStringOfHell == "")
        {
            if (Input.GetMouseButtonDown(1))
            {
                animator.Play("Player_Attack");
            }
        }
        else
        {
            if (Input.GetButtonDown("MOUSE2"))
            {
                animator.Play("Player_Attack");
            }
        }


        if (Input.GetButton($"DownSpecial{playerComponentStringOfHell}"))
        {
            animator.SetBool("isPowerUp", true);
        }
        else
        {
            animator.SetBool("isPowerUp", false);
        }

        // TODO: Need to figure out a better way to do cooldowns etc
        if (Input.GetButton($"SideSpecial{playerComponentStringOfHell}") && !animator.GetBool("isSideSpecial"))
        {
            animator.SetBool("isSideSpecial", true);
        }
    }

    void FixedUpdate()
    {
        if (animator.GetBool("isSideSpecial"))
        {
            if (facingRight && tick == 0)
            {
                rb.velocity = new Vector2(-15, rb.velocity.y);
            }
            else if (!facingRight && tick == 0)
            {
                rb.velocity = new Vector2(15, rb.velocity.y);
            }
            tick++;
        }

        if (tick >= 7)
        {
            tick = 0;
            animator.SetBool("isSideSpecial", false);
        }

    }

    void FlipGameObject()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
