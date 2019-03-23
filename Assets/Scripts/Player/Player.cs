using UnityEngine;

public class Player : MonoBehaviour
{
    public float CurrentDamage { get; private set; }
    public bool PlayerOne = true;

    private Rigidbody2D rb;
    private Constants.EventType eventType;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        eventType = PlayerOne ? Constants.EventType.Player1Damage : Constants.EventType.Player2Damage;
    }

    public void TakeDamage(float damage, Player source)
    {
        CurrentDamage += damage;
        rb.velocity += CalculateForce(source);
        EventHandler.Invoke(eventType, this, new PlayerDamageEventArgs(this, damage));
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
