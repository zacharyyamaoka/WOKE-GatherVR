using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class GreenApple : IFruit {
    void Start() {
        //controllerUI = GameObject.Find("AvacadoControllerUI");
        screenUI = GameObject.Find("GreenAppleScreenUI");
        fruitIcon = GameObject.Find("GreenAppleIcon");
        price = 2.34f;
        fruitName = "GreenApple";
    }
}


