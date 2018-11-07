using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class WaterMelon: IFruit {
    
    void Start() {
        
        //controllerUI = GameObject.Find("WatermelonControllerUI");
        screenUI = GameObject.Find("WatermelonScreenUI");
        fruitIcon = GameObject.Find("WatermelonIcon");
        price = 3.65f;
        fruitName = "WaterMelon";
    }
}