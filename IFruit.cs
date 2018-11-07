using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using UnityEngine;

public abstract class IFruit : MonoBehaviour {
    /* The IFruit Class is Inherited by all fruit classes. Its defines a number of shared functions and
     * enables the use of polymorphism.
     */


    public static GameObject displayedScreenUI;
    public static GameObject displayedControllerUI;
    public static OrderedDictionary fruitInCart = new OrderedDictionary(); // Ordered Dictionary keeps track of bag invetory in order fruit was added, 
    // If defined in awake() bug occurs where every instance of fruit creates their own copy of the dictionary.
    public GameObject noControllerUI;


    public GameObject controllerUI;
    public GameObject noScreenUI;

    // This variables are define in specific fruit subclasses
    public GameObject screenUI;
    public GameObject fruit;
    public GameObject fruitIcon;
    public GameObject fruitPrefab;
    public string fruitName;
    public float price;

    void Awake() {
        
        noScreenUI = GameObject.Find("noScreenUI");
        noControllerUI = GameObject.Find("noControllerUI");
        displayedScreenUI = noScreenUI;
        displayedControllerUI = noControllerUI;
    }

    void Start() {

        // This function is defined in specific fruit subclasses

    }

    public void AddToCart() {

        // if fruit is already in dictionary fruitInCart then incrment the value, otherwise create a new entry with a quanity of 1.
        if ((fruitInCart.Contains(fruitIcon))) {
            fruitInCart[fruitIcon] = Convert.ToInt32(fruitInCart[fruitIcon]) + 1;

        }
        else {

            fruitInCart.Add(fruitIcon, 1);       
        }
    }

    public void ControllerDisplay(Vector3 location) { // Displays relevant controller, ie Watermelon 1.59, besides the controller
         
        controllerUI.transform.position = location;
        displayedControllerUI = controllerUI;
    }

    public void ScreenDisplay(Vector3 location, Quaternion rotation) { // Displays relevant screenUI, ie Watermelon information screen, at specified location
        
        if (displayedScreenUI != screenUI) {
            // pass
        }

        displayedScreenUI = screenUI;
        screenUI.transform.position = location;
        screenUI.transform.rotation = rotation;
    }

    public static void TurnScreenOff(Vector3 location) {
        
       displayedScreenUI.transform.position = location;
        displayedScreenUI.GetComponent<AnimationButton>().Reset();
    }

    public static void TurnControllerOff(Vector3 location) {
        
        displayedControllerUI.transform.position = location;
    }
}


