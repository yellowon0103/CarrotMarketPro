using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApplicationDataManager : MonoBehaviour
{
    public static ApplicationDataManager appDataManager;

    //--Application Data--
    public bool isLoggedIn;
    public string loginUserCode; //current logged in user code

    //---Login---
    //user code, user name distionary 
    public Dictionary<string, string> userCodeNameDict;
    
    //---MyPage---
    //carrot info struct
    public struct CarrotInfo{
        public string objectName;
        bool isSold;
        bool isHidden;
    }
    //user code, user carrot info list dictionary
    public Dictionary<string, List<CarrotInfo>> userCodeCarrotListDict;

    //singleton pattern
    void Awake(){
        DontDestroyOnLoad(appDataManager);

        if(appDataManager == null){
            appDataManager = this;
        }
        else if (appDataManager != this){
            Destroy(appDataManager);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
