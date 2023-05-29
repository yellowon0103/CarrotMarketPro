using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{
    [Header("Panels")]
    public GameObject playerDetailsPanel;
    public GameObject sessionBrowserPanel;
    public GameObject createSessionPanel;
    public GameObject statusPanel;

    [Header("Player settings")]
    public TMP_InputField playerNameInputField;

    [Header("New Carrot Session")]
    public TMP_InputField sessionNameInputField;

    // Start is called before the first frame update
    void Start()
    {
        /*
        if (PlayerPrefs.HasKey("PlayerNickname"))
            playerNameInputField.text = PlayerPrefs.GetString("PlayerNickname");
        */

        // 로비를 열기 위한 네트워크 핸들러를 연다.
        // 0.5초 대기 후 실행
        Invoke("OnFindCarrotClicked", 0.5f);
    }

    void HideAllPanels()
    {
        playerDetailsPanel.SetActive(false);
        sessionBrowserPanel.SetActive(false);
        createSessionPanel.SetActive(false);
        statusPanel.SetActive(false);
    }

    public void OnFindCarrotClicked()
    {
        /*
        PlayerPrefs.SetString("PlayerNickname", playerNameInputField.text);
        PlayerPrefs.Save();
        */

        NetworkRunnerHandler networkRunnerHandler = FindObjectOfType<NetworkRunnerHandler>();

        networkRunnerHandler.OnJoinLobby();

        HideAllPanels();

        sessionBrowserPanel.gameObject.SetActive(true);
        FindObjectOfType<SessionListUIHandler>(true).OnLookingForGameSessions();
    }

    public void OnCreateNewCarrotCliked()
    {
        HideAllPanels();
        createSessionPanel.gameObject.SetActive(true);
    }

    public void OnStartNewSessionClicked()
    {
        NetworkRunnerHandler networkRunnerHandler = FindObjectOfType<NetworkRunnerHandler>();

        networkRunnerHandler.CreateGame(sessionNameInputField.text, "SHGround");  // 실질적 Scene Fetch. 여기서 닉네임 체크하면 될듯.

        PlayerPrefs.SetString("SessionName", sessionNameInputField.text);
        PlayerPrefs.Save();

        HideAllPanels();
        statusPanel.gameObject.SetActive(true);
    }

    public void OnJoiningServer()
    {
        HideAllPanels();

        statusPanel.gameObject.SetActive(true);


    }
}
