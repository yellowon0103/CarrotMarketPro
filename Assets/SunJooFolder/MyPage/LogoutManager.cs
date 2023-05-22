using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogoutManager : MonoBehaviour
{
    public Button logoutButton;

    public void onLogoutButtonClick(){
        //ApplicationDataManager.appDataManager.isLoggedIn = false;
        //ApplicationDataManager.appDataManager.loginUserCode = "";

        SceneManager.LoadScene("SunjooScene");
    }
}
