using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rb = null;
    private Animator animator = null;

    private bool facingRight = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x < -0.1)
        {
            if (facingRight) FlipGameObject();
        }
        if (rb.velocity.x > 0.1)
        {
            if (!facingRight) FlipGameObject();
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (Input.GetButtonDown("Jump"))
        {
            animator.Play("Player_Jump");
        }

        animator.SetBool("Crouching", Input.GetButton("Crouch"));

        if (Input.GetMouseButtonDown(1))
        {
            animator.Play("Player_Attack");
        }


        if (Input.GetButton("DownSpecial"))
        {
            animator.SetBool("isPowerUp", true);
        }
        else
        {
            animator.SetBool("isPowerUp", false);
        }
    }

    void FlipGameObject()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
