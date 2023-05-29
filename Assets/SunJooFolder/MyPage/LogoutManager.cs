using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogoutManager : MonoBehaviour
{
    public GameObject ProfileUI;
    public Button logoutButton; 

    private void Start() {
        
    }

    public void onLogoutButtonClick(){
        Debug.Log("LogoutManager>> Logout Succes!");
        GameDataManager.Instance.ManageLogoutData();
        //go back to LoginScene
        SceneManager.LoadScene("SunjooScene");
    }

}
