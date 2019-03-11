using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackCoolDown = 0f;
    private float nextAttackTime = 0f;

    public Transform attackPosition = null;
    public float attackRange = 0f;
    public LayerMask PlayerLayer;

    void Start()
    {
        
    }

    public void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackCoolDown;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPosition.position, attackRange);
        }
    }
}
