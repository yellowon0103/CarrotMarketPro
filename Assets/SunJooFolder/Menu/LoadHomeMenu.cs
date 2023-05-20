using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHomeMenu : MonoBehaviour
{
    public void LoadHomeScene(){
        Debug.Log("MenuHomeButton Clicked");
        SceneManager.LoadScene("Home Scene");
    }    
}
