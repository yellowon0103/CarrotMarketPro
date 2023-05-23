using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginMainHandler : MonoBehaviour
{
    [Header("Panels")]
    public GameObject playerDetailsPanel;

    [Header("Player settings")]
    public TMP_InputField playerNameInputField;

    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerNickname"))
            playerNameInputField.text = PlayerPrefs.GetString("PlayerNickname");
    }

    public void OnLoginCarrotClicked()
    {
        PlayerPrefs.SetString("PlayerNickname", playerNameInputField.text);
        PlayerPrefs.Save();

        SceneManager.LoadScene("SunjooScene");
    }

}
