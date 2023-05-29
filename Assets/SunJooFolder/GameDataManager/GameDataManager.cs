using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour
{
    //singleton instance
    public static GameDataManager instance = null;
    //singleton instance access property
    public static GameDataManager Instance{
        get{
            return instance;
        }
    }


    //(1) Game Login/Logout Data
    public bool isLoggedIn;
    public string loggedInUserCode; 

    //(2) LoggedIn Data
    //<user code, user name> dictionary 
    public Dictionary<string, string> userCodeNameDict;
    
    //(3) Carrot List Data
    //carrot info struct
    public struct CarrotInfo{
        string carrotName;
        bool isSold;
    }

    //<user code, user carrot info list> dictionary
    public Dictionary<string, List<CarrotInfo>> userCodeCarrotListDict;
   
    void Awake(){
         //singleton pattern
         if(instance){
            Destroy(this.gameObject);
            return;
         }
         instance = this;
         DontDestroyOnLoad(this.gameObject);
        

        //(1) init
        isLoggedIn = false;
        loggedInUserCode = "0";

        //(2) init
        userCodeNameDict.Add("0", "Visitor");
        userCodeNameDict.Add("1111", "ChoiSH");
        userCodeNameDict.Add("2222", "KimYW");
        userCodeNameDict.Add("3333", "LeeSJ");

        //(3) init
        userCodeCarrotListDict.Add("0", new List<CarrotInfo>());
        userCodeCarrotListDict.Add("1111", new List<CarrotInfo>());
        userCodeCarrotListDict.Add("2222", new List<CarrotInfo>());
        userCodeCarrotListDict.Add("3333", new List<CarrotInfo>());
    }

    //(1) called when login happened in LoginScene
    public void ManageLoginData(string inputLoginCode){
        isLoggedIn = true;
        loggedInUserCode = inputLoginCode;
        Debug.Log("GameDataManager>> Managed Login Data. loggedInUserCode: "+loggedInUserCode);
    }

    //(1) called when logout happened in MyPageScene
    public void ManageLogoutData(){
        isLoggedIn = false;
        loggedInUserCode = "0";
        Debug.Log("GameDataManager>> Managed Logout Data. loggedInUserCode: "+loggedInUserCode);
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
