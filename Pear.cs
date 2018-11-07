using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class Pear : IFruit
{
    void Start()
    {
        //controllerUI = GameObject.Find("PearControllerUI");
        screenUI = GameObject.Find("PearScreenUI"); // Manually assign screen UI from inspector
        fruitIcon = GameObject.Find("PearIcon");
        price = 1.52f;
        fruitName = "Pear";


    }

}