using UnityEngine;

public class Player : MonoBehaviour
{
    public float CurrentDamage { get; private set; }
    public bool PlayerOne = true;
    private Rigidbody2D rb;
    private Constants.EventType eventType;
    public PlayerStats Stats;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        eventType = PlayerOne ? Constants.EventType.Player1Damage : Constants.EventType.Player2Damage;
        Stats = GetComponent<PlayerStats>();
    }

    public void TakeDamage(float damage, Transform source)
    {
        CurrentDamage += damage;
        rb.velocity += CalculateForce(source);
        EventHandler.Invoke(eventType, this, new PlayerDamageEventArgs(this, damage));
    }

    Vector2 CalculateForce(Transform source)
    {
        Vector2 knockback = new Vector2(0, 0);
        Vector2 direction = source.position - transform.position;

        float force = 2 + (CurrentDamage / 10);

        knockback.x = direction.x < 0 ? force : -force;

        return knockback;
    }

    public void ResetStats()
    {
        CurrentDamage = 0;
    }
}


