using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginManager : MonoBehaviour
{   
    public Button loginButton;
    public TMP_InputField loginInputField;

    //input text in login input field
    private string inputUserCode;

    void Awake(){   
        //init login button
        loginButton.interactable = false;
    }

    //login button iteractable when loginInputField.text length is 4
    public void CheckLoginInputFieldLen(){
        inputUserCode = loginInputField.text;

        if(inputUserCode.Length == 4){
            loginButton.interactable = true;
        }
        else{
            loginButton.interactable = false;
        }
    }

    //verify login
    public void OnLoginButtonClick(){
        //registered user code
        if(gameDataManager.Contains(inputUserCode)){
            Debug.Log("LoginManager>> Login Success!")
            gameDataManager.ManageLoginData(inputUserCode);
        }
        //unregistered user code
        else{
            Debug.Log("LoginManager>> Login failed! Not registered user code.");
        }
    }
}
