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
        Debug.Log($"{damage} damage taken.");
        rb.velocity += CalculateForce(source);
    }

    Vector2 CalculateForce(Player source)
    {
        // Mega scuffed knockback need to research math to figure it out
        Vector2 direction = transform.position - source.transform.position * 4;
        return direction;
    }
}
