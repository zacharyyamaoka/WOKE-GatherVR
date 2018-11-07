using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class Lemon : IFruit
{
    void Start()
    {
        //controllerUI = GameObject.Find("AvacadoControllerUI");
        screenUI = GameObject.Find("LemonScreenUI");
        fruitIcon = GameObject.Find("LemonIcon");
        price = 2.34f;
        fruitName = "Lemon";
    }

}
