using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class Pomogranate : IFruit {
    
    void Start() {
        //controllerUI = GameObject.Find("AvacadoControllerUI");
        screenUI = GameObject.Find("PomogranateScreenUI");
        fruitIcon = GameObject.Find("PomogranateIcon");
        price = 2.34f;
        fruitName = "Pomogranate";
    }
}


