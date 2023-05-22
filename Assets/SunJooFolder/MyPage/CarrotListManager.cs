using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class CarrotListManager : MonoBehaviour
{   
    //public
    public Button myCarrotButton;
    public Button myHiddenButton;
    public Button mySoldButton;

    // public UnityEngine.UIElements.ScrollView myCarrotList;
    // public UnityEngine.UIElements.ScrollView myHiddenList;
    // public UnityEngine.UIElements.ScrollView mySoldList;

    public GameObject carrotInfoTemplate;

    public GameObject myCarrotListContent;
    public GameObject myHiddenListContent;
    public GameObject mySoldListContent;


    void Awake(){
        onMyCarrotButtonClicked();

        for(int i = 0; i<10; ++i){
            GameObject carrotInfo = (GameObject)Instantiate(carrotInfoTemplate);
            carrotInfo.transform.SetParent(myCarrotListContent.transform);
        }
    }

    public void onMyCarrotButtonClicked(){
        Debug.Log("myCarrotButton Clicked");
        
        changeColorDark(myCarrotButton);
        changeColorCarrot(myHiddenButton);
        changeColorCarrot(mySoldButton);
        makeVisible(myCarrotListContent);
        makeInvisible(myHiddenListContent);
        makeInvisible(mySoldListContent);
    }

    public void onMyHiddenButtonClicked(){
        Debug.Log("myHiddenButton Clicked");
        
        changeColorCarrot(myCarrotButton);
        changeColorDark(myHiddenButton);
        changeColorCarrot(mySoldButton);
        makeInvisible(myCarrotListContent);
        makeVisible(myHiddenListContent);
        makeInvisible(mySoldListContent);
    }
    
    public void onMySoldButtonClicked(){
        Debug.Log("mySoldButton Clicked");
        
        changeColorCarrot(myCarrotButton);
        changeColorCarrot(myHiddenButton);
        changeColorDark(mySoldButton);
        makeInvisible(myCarrotListContent);
        makeInvisible(myHiddenListContent);
        makeVisible(mySoldListContent);
    }

    // void makeInvisible(UnityEngine.UIElements.ScrollView sv){
    //     sv.transform.scale= new Vector3(0,0,0);
    // }
    
    // void makeVisible(UnityEngine.UIElements.ScrollView sv){
    //     sv.transform.scale= new Vector3(1,1,1);
    //}
    
    void makeInvisible(GameObject content){
       content.transform.localScale= new Vector3(0,0,0);
    }
    
    void makeVisible(GameObject content){
        content.transform.localScale= new Vector3(1,1,1);
    }

    void changeColorCarrot(Button btn){
        ColorBlock colorBlock = btn.colors;
        colorBlock.normalColor = new Color32(255, 138, 61, 255);
    }

    void changeColorDark(Button btn){
        ColorBlock colorBlock = btn.colors;
        colorBlock.normalColor = new Color32(255, 100, 61, 255);
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
