using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public TextMeshProUGUI chatText;
    public TMP_InputField inputField;
    public ScrollRect scrollView;

    private void Start()
    {
        Screen.SetResolution(960, 600, false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !inputField.isFocused)
        {
            inputField.ActivateInputField();
        }
    }

    public void SendChatMessage()
    {
        string message = inputField.text;
        Debug.Log(message);
        if (!string.IsNullOrEmpty(message))
        {
            NetworkPlayer.Local.RPC_SendMessage(message);
            inputField.text = string.Empty;
        }
    }

    public void ReceiveChatMessage(string message)
    {
        chatText.text += "\n" + message;

        // 스크롤을 가장 아래로 내림
        StartCoroutine(ScrollToBottom());
    }

    private IEnumerator ScrollToBottom()
    {
        yield return null;
        scrollView.verticalNormalizedPosition = 0f;
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public GameObject chatContent;
    public TMP_InputField inputField;
    public TextMeshProUGUI chatTextPrefab;
    public ScrollRect scrollView;

    private void Start()
    {
        Screen.SetResolution(960, 600, false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !inputField.isFocused)
        {
            inputField.ActivateInputField();
        }
    }

    public void SendChatMessage()
    {
        string message = inputField.text;
        Debug.Log(message);
        if (!string.IsNullOrEmpty(message))
        {
            NetworkPlayer.Local.RPC_SendMessage(message);
            inputField.text = string.Empty;
        }
    }

    public void ReceiveChatMessage(string message)
    {
        TextMeshProUGUI chatText = Instantiate(chatTextPrefab, chatContent.transform);
        chatText.text = message;

        // 스크롤을 가장 아래로 내림
        StartCoroutine(ScrollToBottom());
    }

    private IEnumerator ScrollToBottom()
    {
        yield return null;
        scrollView.verticalNormalizedPosition = 0f;
    }
}

*/