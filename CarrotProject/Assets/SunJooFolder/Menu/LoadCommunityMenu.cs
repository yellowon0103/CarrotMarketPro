using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCommunityMenu : MonoBehaviour
{
    public void LoadCommunityScene(){
        Debug.Log("MenuCommunityButton Clicked");
        SceneManager.LoadScene("Community Scene");
    }    
}
