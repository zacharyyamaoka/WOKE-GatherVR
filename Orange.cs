using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class Orange : IFruit
{
    void Start()
    {
       

        //controllerUI = GameObject.Find("OrangeControllerUI");
        screenUI = GameObject.Find("OrangeScreenUI");
        fruitIcon = GameObject.Find("OrangeIcon");
        price = 0.52f;
        fruitName = "Orange";

    }

}