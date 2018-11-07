using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class Plum : IFruit
{
    void Start()
    {
        //controllerUI = GameObject.Find("PlumControllerUI");
        screenUI = GameObject.Find("PlumScreenUI");
        fruitIcon = GameObject.Find("PlumIcon");
        price = 2.34f;
        fruitName = "Plum";
    }

}


