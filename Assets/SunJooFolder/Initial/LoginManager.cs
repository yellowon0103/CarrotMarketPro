using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginManager : MonoBehaviour
{   
    public Button loginButton;
    public TMP_InputField loginInputField;

    //public GameObject menuUIl
   // private List<Button> menuButtonList;

    private string inputUserCode;

    private bool login = false;
    private Dictionary<string, string> userCodeDic;

    void Awake(){
        userCodeDic.Add("1111", "csh");
        userCodeDic.Add("2222", "kyw");
        userCodeDic.Add("3333", "lsj");

        loginButton.interactable = true;
    }

    public void checkLoginInputFieldLen(){
        inputUserCode = loginInputField.text;
        Debug.Log("loginInputField: "+inputUserCode);

        if(inputUserCode.Length == 4){
            loginButton.interactable = true;
        }
        else{
            loginButton.interactable = false;
        }
    }

    //public void onLoginButtonClick(){
    //   
    //}
}
