using System;

/*
 * Concrete types of the arguments to be passed from events.
 */

public class PlayerDamageEventArgs : EventArgs
{
    public PlayerDamageEventArgs(Player player, float damage)
    {
        Player = player;
        Damage = damage;
    }
    public Player Player { get; }
    public float Damage { get; }
}

public class PlayerStatsEventArgs : EventArgs
{
    public PlayerStatsEventArgs(Player player, PlayerStats playerStats)
    {
        Player = player;
        Stats = playerStats;
    }
    public Player Player { get; }
    public PlayerStats Stats { get; }
}