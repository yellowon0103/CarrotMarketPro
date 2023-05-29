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
    private bool isLoggedIn;
    private string loggedInUserCode; 

    //(2) LoggedIn Data
    //<user code, user name> dictionary 
    private Dictionary<string, string> userCodeNameDict;
    
    //(3) Carrot List Data
    //carrot info struct
    public struct CarrotInfo{
        string carrotName;
        bool isSold;
    }

    //<user code, user carrot info list> dictionary
    private Dictionary<string, List<CarrotInfo>> userCodeCarrotListDict;
   
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
        userCodeNameDict = new Dictionary<string, string>();
        userCodeNameDict.Add("0", "로그인이 필요합니다");
        userCodeNameDict.Add("1111", "최승혁");
        userCodeNameDict.Add("2222", "김예원");
        userCodeNameDict.Add("3333", "이선주");

        //(3) init
        userCodeCarrotListDict = new Dictionary<string, List<CarrotInfo>>();
        userCodeCarrotListDict.Add("0", new List<CarrotInfo>());
        userCodeCarrotListDict.Add("1111", new List<CarrotInfo>());
        userCodeCarrotListDict.Add("2222", new List<CarrotInfo>());
        userCodeCarrotListDict.Add("3333", new List<CarrotInfo>());
    }

    //(1) getter
    public bool getIsLoggedIn(){return isLoggedIn;}
    public string getLoggedInUserCode(){return loggedInUserCode;}

    //(1) called when verifing login in SunjooScene
    public bool VerifyLogin(string inputUserCode){
        Debug.Log("GameDataManager>> Verify Login. inputUserCode: "+inputUserCode);
        if(inputUserCode == null || !userCodeNameDict.ContainsKey(inputUserCode)){
            return false;
        }
        return true;
    }

    //(1) called when login happened in SunjooScene
    public void ManageLoginData(string inputUserCode){
        isLoggedIn = true;
        loggedInUserCode = inputUserCode;
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
