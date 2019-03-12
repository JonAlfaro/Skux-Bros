using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackCoolDown = 0f;
    private float nextAttackTime = 0f;

    public Transform attackPosition = null;
    public float attackRange = 0.3f;
    public LayerMask PlayerLayer;
    public int damage = 1;

    public void Attack()
    {
        // Check cooldown
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackCoolDown; // Set time this attack will be available again

            // Get players in range
            Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPosition.position, attackRange);

            foreach (var collider in colliders)
            {
                // If the collider has a Player component, deal damage
                collider.GetComponent<Player>()?.TakeDamage(damage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
