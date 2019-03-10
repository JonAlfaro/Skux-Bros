using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDeath : MonoBehaviour
{
    [SerializeField]
    string strTag;

    void Start()
    {
        Debug.Log("STARTING");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == strTag)
        {
            collision.gameObject.transform.position = new Vector2(0, 5);
        }
    }
}
