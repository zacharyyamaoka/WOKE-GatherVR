using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    // This class controls the fruit information screens

    public GameObject idleUI;

    StateManager _StateManager;
    ObjectManager _ObjectManager;
    ObjectState _ObjectState;
    GameObject activeObject;
    Vector3 wall;
    Vector3 inFront;
    Vector3 uiStorage;
    Quaternion screenRotation;
    public GameObject inFrontObject;
    void Start() {

        // initalize variables, intialize idleUI by dragging gameobject in from inspector

        // Classes that inherit from monobehave are called from GameObject GameEvents
        _ObjectManager = GameObject.Find("GameEvents").GetComponent<ObjectManager>();
        _StateManager = GameObject.Find("GameEvents").GetComponent<StateManager>();

        // Create new instance of Object State class
        _ObjectState = new ObjectState();

        // Adjust these values to change position of fruit + idle screens
        wall = new Vector3(0.28f, 2.3f, 2.8f); //position of the wall behind the fruit (for big sign)
        uiStorage = new Vector3(0, -30, 30);
        //inFront = new Vector3(0, 1.75f, 1.5f); 
        //inFront = new Vector3(21.6f, 0.978f, 1.58f);
        //inFront = new Vector3(21.3f, 1.462f, 1.3f);
        inFront = inFrontObject.transform.position;
        screenRotation = inFrontObject.transform.rotation;
		// Define starting posisiton for idle screen
		idleUI.transform.position = wall;

    }

    void Update() {
       
        // Get active object from ObjectManager, this is the object under the lazer pointer
        activeObject = this.GetComponent<ObjectManager>().isActive[1];

        // if browesing then idle UI should be at the wall and all Fruit screens should be in storage
        if (_StateManager.currentUserState == StateManager.UserState.browesing) {
            
            if (_ObjectState.CanGrabOffShelf(activeObject)) {

                //idleUI.transform.position = uiStorage;
                //activeObject.GetComponent < IFruit > ().ScreenDisplay(inFront);
            }

            else {
                
                idleUI.transform.position = wall;

                if (IFruit.displayedScreenUI != null) {
                    
                    IFruit.TurnScreenOff(uiStorage);
                }
            }
        }

        // if examining then the idle UI should be in storage and the Fruit screen of the held object should be displayed
        else if (_StateManager.currentUserState == StateManager.UserState.examining) {
            
            _ObjectManager.heldObject.GetComponent<IFruit>().ScreenDisplay(inFront, screenRotation);
            //idleUI.transform.position = uiStorage; // Enable to hide screen UI when examining a fruit
        }

        else if (_StateManager.currentUserState == StateManager.UserState.busy) {

        }
    }

    public void Clear() {
        //IFruit.TurnOn(idleUI, wall);
        IFruit.TurnScreenOff(uiStorage);

    }


    public void On() {
        // this function can be used to turn on the held objects, fruit screens at any time
        _ObjectManager.heldObject.GetComponent<IFruit>().ScreenDisplay(inFront, screenRotation);
        //idleUI.transform.position = uiStorage; //enable to hide idle screen UI when specific fruit screen UI apears

    }
}


  