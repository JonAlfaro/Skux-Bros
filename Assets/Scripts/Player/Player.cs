using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, Player source)
    {
        rb.velocity += CalculateForce(source);
    }

    // TODO take arguments instead of hardcoded value
    Vector2 CalculateForce(Player source)
    {
        Vector2 knockback = new Vector2(0,0);
        Vector2 direction = source.transform.position - transform.position;
        knockback.x = direction.x < 0 ? 7 : -7;

        return knockback;
    }
}
