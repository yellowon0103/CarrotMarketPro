using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginManager : MonoBehaviour
{   
    public Button loginButton;
    public TMP_InputField loginInputField;

    private string inputUserCode;


    void Awake(){
        loginButton.interactable = false;
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
