using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogoutManager : MonoBehaviour
{
    public GameObject ProfileUI;
    public Button logoutButton; 

    void private void Start() {
        
    }

    public void onLogoutButtonClick(){
        Debug.Log("LogoutManager>> Logout Succes!");
        gameDataManager.ManageLogoutData();
        //go back to LoginScene
        SceneManager.LoadScene("SunjooScene");
    }

    private void D
}
