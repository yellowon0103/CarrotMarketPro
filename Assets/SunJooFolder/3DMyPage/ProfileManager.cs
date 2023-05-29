using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileManager : MonoBehaviour
{
    public TMP_Text userNameText;

    // Start is called before the first frame update
    void Start()
    {
        //display current logged in user name
        userNameText.text = GameDataManager.Instance.getLoggedInUserName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
