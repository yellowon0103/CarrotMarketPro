using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckUserCodeInputLength : MonoBehaviour
{   
    public Button loginButton;
    public InputField input;

    public void checkUserCodeInputLength(){
        string text = input.text;
        Debug.Log(text);

        if(text.Length == 4){
            loginButton.interactable = true;
        }
        else{
            loginButton.interactable = false;
        }
    }
}
