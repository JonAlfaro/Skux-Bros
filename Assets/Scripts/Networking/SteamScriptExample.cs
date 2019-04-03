using UnityEngine;
using Steamworks;

public class SteamScriptExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SteamManager.Initialized)
        {
            string name = SteamFriends.GetPersonaName();
            Debug.Log(name);
        }
    }

    private Callback<GameOverlayActivated_t> m_GameOverlayActivated;

    private void OnEnable()
    {
        if (SteamManager.Initialized)
        {
            m_GameOverlayActivated = Callback<GameOverlayActivated_t>.Create(OnGameOverlayActivated);
        }
    }

    private void OnGameOverlayActivated(GameOverlayActivated_t dfghbnjnm)
    {
        if (dfghbnjnm.m_bActive != 0)
        {
            Debug.Log("yes");
            FindObjectOfType<Player>().TakeDamage(3000f, transform);
        }
        else
        {
            Debug.Log("Yes(no)");
        }
    }
}
