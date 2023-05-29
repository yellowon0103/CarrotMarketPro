using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyCarrotManager : MonoBehaviour
{   
    public Button carrotButton;
    public Button soldButton;

    public GameObject carrotInfoTemplate;

    public GameObject carrotContent;
    public GameObject soldContent;

    void Awake(){
        for(int i = 0; i<5; ++i){
            GameObject carrotInfo = (GameObject)Instantiate(carrotInfoTemplate);
            carrotInfo.transform.SetParent(carrotContent.transform);
        }

        for(int i = 0; i<2; ++i){
            GameObject carrotInfo = (GameObject)Instantiate(carrotInfoTemplate);
            carrotInfo.transform.SetParent(soldContent.transform);
        }
    }

}
