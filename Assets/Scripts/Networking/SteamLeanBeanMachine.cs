using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;


public class SteamLeanBeanMachine : MonoBehaviour
{
    private Callback<P2PSessionRequest_t> _p2PSessionRequestCallback;
    private CSteamID uuid;
    public Player player1;
    private Transform p1Transform;
    public Player player2;
    // Start is called before the first frame update
    void Awake()
    {
        p1Transform = player1.transform;
    }
    void Start()
    {

        // setup the callback method
        _p2PSessionRequestCallback = Callback<P2PSessionRequest_t>.Create(OnP2PSessionRequest);

        uuid = SteamUser.GetSteamID();
        string hello = "Hello!";

        // allocate new bytes array and copy string characters as bytes
        byte[] bytes = new byte[hello.Length * sizeof(char)];
        System.Buffer.BlockCopy(hello.ToCharArray(), 0, bytes, 0, bytes.Length);

        SteamNetworking.SendP2PPacket(uuid, bytes, (uint)bytes.Length, EP2PSend.k_EP2PSendReliable);
    }

    // Update is called once per frame
    void Update()
    {
        // if (p1Transform != player1.transform)
        // {
        uuid = SteamUser.GetSteamID();
        byte[] bytes = System.BitConverter.GetBytes((double)player1.transform.position.x);

        SteamNetworking.SendP2PPacket(uuid, bytes, (uint)bytes.Length, EP2PSend.k_EP2PSendReliable);
        //     p1Transform = player1.transform;
        // }
        uint size;

        // repeat while there's a P2P message available
        // will write its size to size variable
        while (SteamNetworking.IsP2PPacketAvailable(out size))
        {
            // allocate buffer and needed variables
            var buffer = new byte[size];
            uint bytesRead;
            CSteamID remoteId;

            // read the message into the buffer
            if (SteamNetworking.ReadP2PPacket(buffer, size, out bytesRead, out remoteId))
            {
                float kingX = (float)System.BitConverter.ToDouble(buffer, 0);


                // convert to string
                // int length = (int)buffer.Length;
                // char[] chars = new char[bytesRead / sizeof(char)];
                // System.Buffer.BlockCopy(buffer, 0, chars, 0, length);
                Vector3 newPos = player2.transform.position;
                newPos.x = kingX + 2;
                player2.transform.position = newPos;


                // string message = new string(chars, 0, chars.Length);
                Debug.Log("KingX a message: " + kingX);
                Debug.Log("RealX a message: " + p1Transform.position.x);
            }
        }
    }

    void OnP2PSessionRequest(P2PSessionRequest_t request)
    {
        CSteamID clientId = request.m_steamIDRemote;
        // if (SteamNetworking)
        // {
        SteamNetworking.AcceptP2PSessionWithUser(clientId);
        // }
        // else
        // {
        //     Debug.LogWarning("Unexpected session request from " + clientId);
        // }
    }
}
