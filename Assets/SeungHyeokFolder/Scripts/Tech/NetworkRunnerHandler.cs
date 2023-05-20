using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;
using System.Linq;

public class NetworkRunnerHandler : MonoBehaviour
{
    public NetworkRunner networkRunnerPrefab;

    NetworkRunner networkRunner;

    private void Awake()
    {
        NetworkRunner networkRunnerInScene = FindObjectOfType<NetworkRunner>();

        // 이미 네트워크 러너가 있는 경우 재사용
        if (networkRunnerInScene != null)
            networkRunner = networkRunnerInScene;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (networkRunner == null)
        {
            networkRunner = Instantiate(networkRunnerPrefab);
            networkRunner.name = "Network runner";

            if (SceneManager.GetActiveScene().name != "SHMenu")
            {
                var clientTask = InitializeNetworkRunner(networkRunner, GameMode.AutoHostOrClient, "TestSession", NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null);
            }

            Debug.Log($"Server NetworkRunner started");
        }
    }

    /*
    private void OnGUI()
    {
        if (clientTask == null) 
        {
            if (GUI.Button(new Rect(0, 0, 200, 40), "Host"))
            {
                clientTask = InitializeNetworkRunner(networkRunner, GameMode.Host, NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null);
                Debug.Log($"Server NetworkRunner Host started");
            }
            if (GUI.Button(new Rect(0, 40, 200, 40), "Join"))
            {
                clientTask = InitializeNetworkRunner(networkRunner, GameMode.Client, NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null);
                Debug.Log($"Server NetworkRunner Client started");
            }
        }   
    }*/


    protected virtual Task InitializeNetworkRunner(NetworkRunner runner, GameMode gameMode, string sessionName, NetAddress address, SceneRef scene, Action<NetworkRunner> initialized)
    {
        var sceneManager = runner.GetComponents(typeof(MonoBehaviour)).OfType<INetworkSceneManager>().FirstOrDefault();

        if (sceneManager == null)
        {
            // 이미 씬에 있는 오브젝트를 다룬다
            sceneManager = runner.gameObject.AddComponent<NetworkSceneManagerDefault>();
        }

        runner.ProvideInput = true;

        return runner.StartGame(new StartGameArgs
        {
            GameMode = gameMode,
            Address = address,
            Scene = scene,
            SessionName = sessionName,
            CustomLobbyName = "Carrot",
            Initialized = initialized,
            SceneManager = sceneManager
        });
    }

    public void OnJoinLobby()
    {
        var clientTask = JoinLobby();

    }

    private async Task JoinLobby()
    {
        Debug.Log("JoinLobby Started");

        string lobbyID = "Carrot";

        var result = await networkRunner.JoinSessionLobby(SessionLobby.Custom, lobbyID);

        if (!result.Ok)
        {
            Debug.Log($"Unable to Join lobby {lobbyID}");
        }
        else
        {
            Debug.Log("JoinLobby OK");
        }
    }

    public void CreateGame(string sessionName, string sceneName)
    {
        Debug.Log($"Create session {sessionName} scene {sceneName} build Index {SceneUtility.GetBuildIndexByScenePath($"Scenes/{sceneName}")}");

        // 호스트로서 새로운 당근 생성
        var clientTask = InitializeNetworkRunner(networkRunner, GameMode.Host, sessionName, NetAddress.Any(), SceneUtility.GetBuildIndexByScenePath($"Scenes/{sceneName}"), null);
    }

    public void JoinGame(SessionInfo sessionInfo)
    {
        Debug.Log($"Join Session {sessionInfo.Name}");

        // 클라이언트로서 당근에 접속
        var clientTask = InitializeNetworkRunner(networkRunner, GameMode.Client, sessionInfo.Name, NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null);
    }
}

