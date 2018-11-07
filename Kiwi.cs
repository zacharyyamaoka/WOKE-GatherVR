using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class Kiwi : IFruit {
    
    void Start() {
        //controllerUI = GameObject.Find("AvacadoControllerUI");
        screenUI = GameObject.Find("KiwiScreenUI");
        fruitIcon = GameObject.Find("KiwiIcon");
        price = 2.34f;
        fruitName = "Kiwi";
    }
}
