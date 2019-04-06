using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;

    public GameObject projectile;
    public Transform shotPoint;
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public AudioSource gunSound;
    public AudioClip gunSoundX;
    private Player player;
    private System.Random rand = new System.Random();
    void Start()
    {
        gunSound.clip = gunSoundX;
        player = GetComponentInParent<Player>();
    }
    private void Update()
    {
        // Aiming
        if (player.PlayerOne)
        {
            UpdateRotationUsingMousePosition();
        }
        else
        {
            UpdateRotationGLOCKWISE();
        }

        // Shooting
        if (timeBetweenShots <= 0)
        {
            if (IsPressingThingThatTheyNeedToPressToGo())
            {
                var go = Instantiate(projectile, shotPoint.position, transform.rotation);
                go.GetComponent<Projectile>().player = player;
                gunSound.Play();
                timeBetweenShots = startTimeBetweenShots;
            }
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }

    }

    private void UpdateRotationUsingMousePosition()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }

    // (Clockwise)
    private void UpdateRotationGLOCKWISE()
    {
        transform.RotateAround(transform.position, new Vector3(0, 0, 1), 1 * player.Stats.DamageMultiplier);
    }

    private bool IsPressingThingThatTheyNeedToPressToGo()
    {
        return (player.PlayerOne && Input.GetMouseButtonDown(0)) || (!player.PlayerOne && Input.GetButtonDown("PLAYER_@_SHOOTINGLOL"));
    }
}
