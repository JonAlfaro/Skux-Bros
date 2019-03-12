using UnityEngine;

public class Player : MonoBehaviour
{
    public void TakeDamage(int damage)
    {
        Debug.Log($"{damage} damage taken.");
    }
}
