using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb = null;
    private Animator animator = null;
    private CoolJumps coolJumps = null;
    private PlayerAttack playerAttack = null;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coolJumps = GetComponent<CoolJumps>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        DoAnimationStuff();
    }

    void DoAnimationStuff()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (Input.GetButtonDown("Jump"))
        {
            animator.Play("Player_Jump");
        }

        animator.SetBool("Crouching", Input.GetButton("Crouch"));

        if (Input.GetMouseButton(1)) animator.Play("Player_Attack");
    }

    void Attack()
    {
        playerAttack.Attack();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"{damage} damage taken.");
    }
}
