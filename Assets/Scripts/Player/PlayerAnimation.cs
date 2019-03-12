using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rb = null;
    private Animator animator = null;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
