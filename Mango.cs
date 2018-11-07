using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class Mango : IFruit
{
    void Start()
    {
        //controllerUI = GameObject.Find("AvacadoControllerUI");
        screenUI = GameObject.Find("MangoScreenUI");
        fruitIcon = GameObject.Find("MangoIcon");
        price = 2.34f;
        fruitName = "Mango";
    }

}
