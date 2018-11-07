using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class RedApple : IFruit {
    /* This class defines the varibles specific to the Red Apple fruit
     */

    void Start() {
        //controllerUI = GameObject.Find("RedAppleControllerUI"); // disablded as the controller UI is no longer being used
        screenUI = GameObject.Find("RedAppleScreenUI");
        fruitIcon = GameObject.Find("RedAppleIcon");
        price = 2.34f;
        fruitName = "Red Apple";
    }
}


