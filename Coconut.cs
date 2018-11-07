using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class Coconut : IFruit {
    
    void Start() {
        //controllerUI = GameObject.Find("AvacadoControllerUI");
        screenUI = GameObject.Find("CoconutScreenUI");
        fruitIcon = GameObject.Find("CoconutIcon");
        price = 2.34f;
        fruitName = "Coconut";
    }
}
