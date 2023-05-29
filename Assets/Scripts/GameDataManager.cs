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

    //----------------------------------------------

    //(1) Login Data
    private bool isLoggedIn;
    private string loggedInUserCode; 

    private bool isVRUser;

    //(2) User Data
    //<user code, user name> dictionary 
    private Dictionary<string, string> userCodeNameDict;
    
    //(3) Carrot List Data
    //carrot info struct
    public struct CarrotInfo{
        string carrotName;
        bool isSold;

        CarrotInfo(string _carrotName, bool _isSold){
            this.carrotName = _carrotName;
            this.isSold = _isSold;
        }
    }
    //<user code, carrot info list> dictionaty
    private Dictionary<string, List<CarrotInfo>> userCodeCarrotListDict;

    //----------------------------------------------
   
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
        isVRUser = false;

        //(2) init
        userCodeNameDict = new Dictionary<string, string>();
        initUserCodeNameDict();

        //(3) init
        userCodeCarrotListDict = new Dictionary<string, List<CarrotInfo>>();
        initUserCodeCarrotListDict();
    }   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //----------(1) Login Data Managemant-----------------------------------

    public bool getIsLoggedIn(){return isLoggedIn;}
    public string getLoggedInUserCode(){return loggedInUserCode;}

    public bool getIsVRUser(){return isVRUser;}

    //called when login happened in SunjooScene
    public void ManageLoginData(string inputUserCode, bool VROptionToggleValue){
        isLoggedIn = true;
        loggedInUserCode = inputUserCode;

        isVRUser = VROptionToggleValue;

        Debug.Log("GameDataManager>> Managed Login Data. loggedInUserCode: "+loggedInUserCode);
        Debug.Log("GameDataManager>> Managed Login Data. isVRUser: "+isVRUser);
    }

    //called when logout happened in MyPageScene
    public void ManageLogoutData(){
        isLoggedIn = false;
        loggedInUserCode = "0";
        isVRUser = false;
        Debug.Log("GameDataManager>> Managed Logout Data. loggedInUserCode: "+loggedInUserCode);
    }

    //----------(2) User Data Managemant------------------------------------
    void initUserCodeNameDict(){
        userCodeNameDict.Add("0", "로그인이 필요합니다");
        userCodeNameDict.Add("1111", "최승혁");
        userCodeNameDict.Add("2222", "김예원");
        userCodeNameDict.Add("3333", "이선주");
    }

    //called to show user name in profileUI in MyPageScene
    public string getLoggedInUserName(){
        string userName;
        if(userCodeNameDict.TryGetValue(loggedInUserCode, out userName)){
            Debug.Log("GameDataManager>> getLoggedInUserName. userName: "+userName);
            return userName;
        }
        Debug.Log("GameDataManager>> getLoggedInUserName. Couldn't get user name!");
        return "";
    }

    //called to verify login in SunjooScene
    public bool VerifyLogin(string inputUserCode){
        Debug.Log("GameDataManager>> Verify Login. inputUserCode: "+inputUserCode);
        if(inputUserCode == null || !userCodeNameDict.ContainsKey(inputUserCode)){
            return false;
        }
        return true;
    }
    
    //----------(3) Carrot List Data Managemant-----------------------------
    void initUserCodeCarrotListDict(){
        userCodeCarrotListDict.Add("0", new List<CarrotInfo>());
        userCodeCarrotListDict.Add("1111", new List<CarrotInfo>());
        userCodeCarrotListDict.Add("2222", new List<CarrotInfo>());
        userCodeCarrotListDict.Add("3333", new List<CarrotInfo>());

        //test code
        //AddCarrotInfo("1111", "handcream", false);
        //AddCarrotInfo("1111", "kitty", false);
        //AddCarrotInfo("2222", "bunny", false);
    }

    /*
    public void AddCarrotInfo(string userCode, string carrotName, bool isSold){
        List<CarrotInfo> carrotList;
        if(userCodeNameDict.TryGetValue(userCode, out carrotList)){
            Debug.Log("GameDataManager>> AddCarrotInfo. userCode: "+userCode+", carrotName: "+carrotName);
            carrotList.Add(new CarrotInfo(carrotName, isSold));
        }
        else{
            Debug.Log("GameDataManager>> AddCarrotInfo. Couldn't get carrot list!");
        }
    }
    */
}
