using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    public float damage;
    public Player player;

    public GameObject destroyEffect;

    private void Start()
    {
        Invoke(nameof(DestroyProjectile), lifeTime);
        if (!player.PlayerOne)
        {
            damage *= 3;
        }
    }
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance);
        if (hitInfo.collider != null && hitInfo.collider.gameObject != player.gameObject)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<Player>().TakeDamage(damage * player.Stats.DamageMultiplier, this.transform);
            }
            DestroyProjectile();
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        GameObject destroyEffectGO = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(destroyEffectGO, 2f);
        Destroy(gameObject);
    }

}
