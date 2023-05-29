using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    NetworkRunner networkRunner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExit()
    {
        NetworkRunner networkRunnerInScene = FindObjectOfType<NetworkRunner>();

        // 이미 네트워크 러너가 있는 경우 재사용
        if (networkRunnerInScene != null)
            networkRunner = networkRunnerInScene;

        networkRunner.Shutdown();

        SceneManager.LoadScene("SunjooScene");
    }
}
