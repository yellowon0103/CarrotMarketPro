using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSceneChangeManager : MonoBehaviour
{
    public Button MenuButton;

    public void MenuSceneChangeOnMenuButtonClick(){
        string buttonName = MenuButton.name;
        Debug.Log(MenuButton+"Clicked");

        if(buttonName == "MenuHomeButton"){
            SceneManager.LoadScene("SHMenu");
        }
        if(buttonName == "MenuCommunityButton"){
            SceneManager.LoadScene("CommLoading");
        }
        if(buttonName == "MenuMyPageButton"){
            SceneManager.LoadScene("3DMyPage Scene");
        }
    }    
}
