using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayerControlledVelocity : MonoBehaviour
{
    [SerializeField]
    Vector2 v2Force;
    [SerializeField]
    KeyCode keyPositive;
    [SerializeField]
    KeyCode keyNegative;
    private Rigidbody2D rgb;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(keyPositive))
            rgb.velocity += v2Force;

        if (Input.GetKey(keyNegative))
            rgb.velocity -= v2Force;
    }
}
