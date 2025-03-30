using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Riptide.Transports;
using Riptide;
using Riptide.Utils;
using System;


public enum ServerToClientId : ushort
 {
     sync = 1,
     activeScene,
     playerSpawned,
     playerMovement,
     playerHealthChanged,
     playerActiveWeaponUpdated,
     playerAmmoChanged,
     playerDied,
     playerRespawned,
     projectileSpawned,
     projectileMovement,
     projectileCollided,
     projectileHitmarker,
 }

 public enum ClientToServerId : ushort
 {
     name = 1,
     input,
     switchActiveWeapon,
     primaryUse,
     reload,
 }
public class NetworkManager : MonoBehaviour
{
    public static NetworkManager Instance
    {
        get => instance;

        private set
        {
            if (instance == null)
            {
                instance = value;
            }
            else if (instance != null)
            {
                Destroy(value);
            }
        }
    }
    [SerializeField] private string ip;
    [SerializeField] private ushort port;

    private static NetworkManager instance;

    private Client client;

    public Client Client => client; 

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        RiptideLogger.Initialize(Debug.Log, Debug.Log, Debug.LogWarning, Debug.LogError, false);
        client = new Client();
        Client.Connected += DidConnect;
        Client.ConnectionFailed += FailedToConnect;
        Client.ClientDisconnected += PlayerLeft;
        Client.Disconnected += DidDisconnect;
    }
    private void DidConnect(object sender, EventArgs e)
    {
        UIManager.Singleton.SendName();
    }

    public void Connect(){
        client.Connect($"{ip}:{port}");
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        client.Update();
    }
    private void DidConnect(object sender, ConnectedEventArgs e)
    {
        UIManager.Singleton.SendName();
    }

    private void FailedToConnect(object sender, ConnectionFailedEventArgs e)
    {
        UIManager.Singleton.BackToMain();
    }

    private void PlayerLeft(object sender, ClientDisconnectedEventArgs e)
    {
        Destroy(Player.Players[e.Id].gameObject);
    }

    private void DidDisconnect(object sender, Riptide.DisconnectedEventArgs e)
    {
        UIManager.Singleton.BackToMain();
    }
}
