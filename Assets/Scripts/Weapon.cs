﻿using System.Collections;
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

    void Start()
    {
        gunSound.clip = gunSoundX;
        player = GetComponentInParent<Player>();
    }
    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBetweenShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
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
}
