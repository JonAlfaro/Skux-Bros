using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DummyPlayerControlledVelocity : MonoBehaviour
{
    [SerializeField] Vector2 v2Force = Vector2.zero;
    [SerializeField] KeyCode keyPositive = KeyCode.None;
    [SerializeField] KeyCode keyNegative = KeyCode.None;

    private Rigidbody2D rgb;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(keyPositive))
        {
            rgb.velocity += v2Force;
        }

        if (Input.GetKey(keyNegative))
        {
            rgb.velocity -= v2Force;
        }
    }
}
