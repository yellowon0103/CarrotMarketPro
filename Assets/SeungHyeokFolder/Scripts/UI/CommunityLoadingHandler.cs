using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunityLoadingHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("OnCommunityConnect", 0.5f);  // 0.5초 대기 후 연결(NetworkRunner 생성 오류 피하기 위해)
    }

    private void OnCommunityConnect() 
    {
        NetworkRunnerHandler networkRunnerHandler = FindObjectOfType<NetworkRunnerHandler>();

        networkRunnerHandler.JoinCommunity();
    }
}
