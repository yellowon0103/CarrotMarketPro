using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyCarrotManager : MonoBehaviour
{   
    public Button carrotButton;
    public Button hiddenButton;
    public Button soldButton;

    public GameObject carrotInfoTemplate;

    public GameObject carrotContent;
    public GameObject hiddenContent;
    public GameObject soldContent;

   //public Panel carrotPanel;
    //public Panel hiddenPanel;
    //public Panel soldPanel;


    void Awake(){
        onMyCarrotButtonClicked();

        for(int i = 0; i<5; ++i){
            GameObject carrotInfo = (GameObject)Instantiate(carrotInfoTemplate);
            carrotInfo.transform.SetParent(carrotContent.transform);
        }
        for(int i = 0; i<3; ++i){
            GameObject carrotInfo = (GameObject)Instantiate(carrotInfoTemplate);
            carrotInfo.transform.SetParent(hiddenContent.transform);
        }
        for(int i = 0; i<2; ++i){
            GameObject carrotInfo = (GameObject)Instantiate(carrotInfoTemplate);
            carrotInfo.transform.SetParent(soldContent.transform);
        }
    }

    public void onMyCarrotButtonClicked(){
        Debug.Log("carrotButton Clicked");
        
        changeColorDark(carrotButton);
        changeColorCarrot(hiddenButton);
        changeColorCarrot(soldButton);
        // makeVisible(carrotPanel);
        // makeInvisible(hiddenPanel);
        // makeInvisible(soldPanel);
    }

    public void onMyHiddenButtonClicked(){
        Debug.Log("hiddenButton Clicked");
        
        changeColorCarrot(carrotButton);
        changeColorDark(hiddenButton);
        changeColorCarrot(soldButton);
        // makeInvisible(carrotPanel);
        // makeVisible(hiddenPanel);
        // makeInvisible(soldPanel);
    }
    
    public void onMySoldButtonClicked(){
        Debug.Log("soldButton Clicked");
        
        changeColorCarrot(carrotButton);
        changeColorCarrot(hiddenButton);
        changeColorDark(soldButton);
        // makeInvisible(carrotPanel);
        // makeInvisible(hiddenPanel);
        // makeVisible(soldPanel);
    }

    
    // void makeInvisible(Panel panel){
    //     panel.transform.localScale= new Vector3(0,0,0);
    // }
    
    // void makeVisible(Panel panel){
    //     panel.transform.localScale= new Vector3(1,1,1);
    // }

    void changeColorCarrot(Button btn){
        ColorBlock colorBlock = btn.colors;
        colorBlock.normalColor = new Color32(255, 138, 61, 255);
    }

    void changeColorDark(Button btn){
        ColorBlock colorBlock = btn.colors;
        colorBlock.normalColor = new Color32(255, 100, 61, 255);
    }

}
