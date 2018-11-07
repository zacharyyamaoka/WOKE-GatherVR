using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class Avacado : IFruit
{
    void Start()
    {
        //controllerUI = GameObject.Find("AvacadoControllerUI");
        screenUI = GameObject.Find("AvacadoScreenUI");
        fruitIcon = GameObject.Find("AvacadoIcon");
        price = 2.34f;
        fruitName = "Avacado";
    }

}


