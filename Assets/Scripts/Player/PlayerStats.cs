using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private Player player;
    public float DamageMultiplier = 0;


    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        EventHandler.Invoke(Constants.EventType.DamageMultiplier, this, new PlayerStatsEventArgs(this.player, this));
    }

    private void Update()
    {

    }

    public void IncreaseDamageMultiplier(float increment)
    {
        if (player.PlayerOne)
        {
            DamageMultiplier += increment;
            EventHandler.Invoke(Constants.EventType.DamageMultiplier, this, new PlayerStatsEventArgs(this.player, this));
        }
        else
        {
            DamageMultiplier += increment;
            EventHandler.Invoke(Constants.EventType.DamageMultiplier2, this, new PlayerStatsEventArgs(this.player, this));
        }
    }
}
