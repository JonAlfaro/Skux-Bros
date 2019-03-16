using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPosition = null;
    public Vector2 attackRange = new Vector2(0.3f, 0.3f);
    public LayerMask PlayerLayer;
    public int damage = 1;

    // Attack timing
    public float attackCoolDown = 0f;
    private float nextAttackTime = 0f;
    private float attackEndTime = 0f;
    private bool isAttacking = false;

    private Player player;
    private List<Collider2D> targetsToIgnore = new List<Collider2D>();

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (!isAttacking) return;

        // Check attack duration
        if (Time.time >= attackEndTime)
        {
            isAttacking = false;
            return;
        }

        Attack();
    }

    public void BeginAttacking(float attackTime)
    {
        attackEndTime = Time.time + attackTime; // Attack will be active for 0.5 seconds
        targetsToIgnore = new List<Collider2D> { GetComponent<Collider2D>() };
        isAttacking = true;
    }

    public void EndAttacking()
    {
        isAttacking = false;
    }

    private void Attack()
    {
        // Check cooldown
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackCoolDown; // Set time this attack will be available again

            // Get players in range
            Collider2D[] colliders = GetTargets();
            
            foreach (var collider in colliders)
            {
                // If the collider has a Player component, deal damage and add it to the targets to ignore
                Player target = collider.GetComponent<Player>();
                if (target && !targetsToIgnore.Contains(collider))
                {
                    target.TakeDamage(damage, player);
                    targetsToIgnore.Add(collider);
                }
            }
        }
    }

    private Collider2D[] GetTargets()
    {
        return Physics2D.OverlapBoxAll(attackPosition.position, attackRange, 0f, PlayerLayer);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPosition.position, attackRange);
    }
}
