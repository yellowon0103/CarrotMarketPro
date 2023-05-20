using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMyPageMenu : MonoBehaviour
{
    public void LoadMyPageScene(){
        Debug.Log("MenuMyPageButton Clicked");
        SceneManager.LoadScene("MyPage Scene");
    }    
}
