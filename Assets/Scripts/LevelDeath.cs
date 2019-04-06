using UnityEngine;

public class LevelDeath : MonoBehaviour
{
    [SerializeField] string strTag = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(strTag))
        {
            collision.gameObject.transform.position = new Vector2(0, 1);
            var rBody = collision.gameObject.GetComponent<Rigidbody2D>();
            collision.gameObject.GetComponent<Player>().ResetStats();
            collision.gameObject.GetComponent<Player>().TakeDamage(0f, collision.transform);
            if (rBody)
            {
                rBody.velocity = new Vector2(0, 0);
            }

        }
    }
}
