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

    void Start(){   
         //if already logged in, hide LoginUI
        if(GameDataManager.Instance.getIsLoggedIn()){
            LoginUISetActive(false);
        }
        //if not, show LoginUI
        else{
            LoginUISetActive(true);
        } 
    }


    //login button iteractable when loginInputField.text length is 4
    public void CheckLoginInputFieldLen(){
        inputUserCode = loginInputField.text;
        Debug.Log("LoginManager>> CheckLoginInputFieldLen. inputUserCode = "+inputUserCode);

        if(inputUserCode.Length == 4){
            loginButton.interactable = true;
        }
        else{
            loginButton.interactable = false;
        }
    }

    //verify login
    public void OnLoginButtonClick(){
        inputUserCode = loginInputField.text;
        Debug.Log("LoginManager>> OnLoginButtonCLick. inputUserCode = "+inputUserCode);

        //registered user code
        if(GameDataManager.Instance.VerifyLogin(inputUserCode)){
            Debug.Log("LoginManager>> Login Success!");
            GameDataManager.Instance.ManageLoginData(inputUserCode);

            //hide LoginUI
            LoginUISetActive(false);
        }
        //unregistered user code
        else{
            Debug.Log("LoginManager>> Login failed! Not registered user code.");
        }
    }

    public void LoginUISetActive(bool inputState){
        //Initialize login UI
        loginInputField.text = "회원 코드 4자리 입력";
        loginButton.interactable = false;

        loginInputField.gameObject.SetActive(inputState);
        loginButton.gameObject.SetActive(inputState);
    }
}
