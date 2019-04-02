using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CoolText : MonoBehaviour
{
    public Constants.EventType EventType;
    public Text Text { get; private set; }

    void Awake()
    {
        Text = GetComponent<Text>();

        switch (EventType)
        {
            case Constants.EventType.Player1Damage:
            case Constants.EventType.Player2Damage:
                Listener.CreateListener(transform, (sender, args) => DrawPlayerHealth(((PlayerDamageEventArgs)args).Player), EventType);
                break;
            case Constants.EventType.DamageMultiplier:
                Listener.CreateListener(transform, (sender, args) => DrawDamageMultiplier(((PlayerStatsEventArgs)args).Stats), EventType);
                break;

        }
    }

    private void DrawPlayerHealth(Player player)
    {
        Text.text = $"{Math.Round(player.CurrentDamage, 2)}%";

        // Value betweeen 0 - 1. Damage / 100 means that at 100 damage color will be 255,0,0
        float greenAndBlueAmount = Mathf.Max(1 - (player.CurrentDamage / 100), 0);
        Text.color = new Color(1, greenAndBlueAmount, greenAndBlueAmount);
    }

    private void DrawDamageMultiplier(PlayerStats playerStats)
    {
        Text.text = $"×{Math.Round(playerStats.DamageMultiplier, 2)}";
    }
}
