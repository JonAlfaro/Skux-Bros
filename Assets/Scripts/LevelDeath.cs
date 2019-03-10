using UnityEngine;

public class LevelDeath : MonoBehaviour
{
    [SerializeField] string strTag = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(strTag))
        {
            collision.gameObject.transform.position = new Vector2(0, 1);
        }
    }
}
