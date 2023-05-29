using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;
using UnityEditor;

public class NetworkSpawner : MonoBehaviour, INetworkRunnerCallbacks
{
    [SerializeField] private NetworkPrefabRef _playerPrefab;
    [SerializeField] private NetworkPrefabRef _nonVRplayerPrefab;
    private Dictionary<PlayerRef, NetworkObject> _spawnedCharacters = new Dictionary<PlayerRef, NetworkObject>();

    NetworkCharacterInputHandler _characterInputHandler;
    NetworkNonVRHandler _nonVRInputHandler;
    SessionListUIHandler _sessionListUIHandler;
    NetworkObject _sessionProduct = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        _sessionListUIHandler = FindObjectOfType<SessionListUIHandler>(true);
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        // Create a unique position for the player
        Vector3 spawnPosition = NetworkUtils.GetRandomSpawnPoint();
        NetworkObject networkPlayerObject = null;
        if (GameDataManager.Instance.getIsVRUser())
        {
            networkPlayerObject = runner.Spawn(_playerPrefab, spawnPosition, Quaternion.identity, player);  // for VR user
        }
        else
        {
            networkPlayerObject = runner.Spawn(_nonVRplayerPrefab, spawnPosition, Quaternion.identity, player);  // for non VR user
        }
        
        // Keep track of the player avatars so we can remove it when they disconnect
        _spawnedCharacters.Add(player, networkPlayerObject);

        string sessionName = null;

        if (PlayerPrefs.HasKey("SessionName"))
        {
            sessionName = PlayerPrefs.GetString("SessionName");
            PlayerPrefs.DeleteKey("SessionName");
            PlayerPrefs.Save();
        }
        if (_sessionProduct == null && sessionName != null) 
        {
            GameObject _productPrefab = Resources.Load<GameObject>(sessionName);
            if (_productPrefab != null)
            {
                Debug.Log($"Successfully loaded {sessionName} product prefab!");
                _sessionProduct = runner.Spawn(_productPrefab, new Vector3(0, 1, 0), Quaternion.identity);
            }

            else 
            {
                Debug.Log($"The 3D mesh for {sessionName} is not yet mounted.");
            }
        }
            
    }
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        // Find and remove the players avatar
        if (_spawnedCharacters.TryGetValue(player, out NetworkObject networkObject))
        {
            runner.Despawn(networkObject);
            _spawnedCharacters.Remove(player);
        }
    }
    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        if (GameDataManager.Instance.getIsVRUser())
        {
            // for VR user

            if (_characterInputHandler == null && NetworkPlayer.Local != null)
                _characterInputHandler = NetworkPlayer.Local.GetComponent<NetworkCharacterInputHandler>();

            if (_characterInputHandler != null)
                input.Set(_characterInputHandler.GetNetworkInput());

        }
        else
        {
            // for Non VR user
            if (_nonVRInputHandler == null && NetworkPlayer.Local != null)
            {
                _nonVRInputHandler = NetworkPlayer.Local.GetComponent<NetworkNonVRHandler>();
            }

            if (_nonVRInputHandler != null)
                input.Set(_nonVRInputHandler.GetNetworkInput());
        }
        
    }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Debug.Log("OnShutdown");
    }
    public void OnConnectedToServer(NetworkRunner runner)
    {
        Debug.Log("OnConnectedToServer");
    }
    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        Debug.Log("OnDisconnectedFromServer");
    }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        Debug.Log("OnConnectRequest");
    }
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        Debug.Log("OnConnectFailed");
    }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        if (_sessionListUIHandler == null)
            return;

        if (sessionList.Count == 0)
        {
            Debug.Log("Joined Lobby no session found");

            _sessionListUIHandler.OnNoSessionsFound();
        }
        else
        {
            _sessionListUIHandler.ClearList();

            foreach (SessionInfo sessionInfo in sessionList)
            {
                _sessionListUIHandler.AddToList(sessionInfo);

                Debug.Log($"Found session {sessionInfo.Name} playerCount {sessionInfo.PlayerCount}");
            }
        }



    }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data) { }
    public void OnSceneLoadDone(NetworkRunner runner) { }
    public void OnSceneLoadStart(NetworkRunner runner) { }

}
