using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRController : MonoBehaviour {
    /* This class assigns actions to the controls on the Gear VR Controller
     */

    StateManager _StateManager;
    Router router;
    public bool controllerRay;
    //Teleport _teleport;
    public Quaternion offset; 
   
	void Start () {

        router = GameObject.Find("GameEvents").GetComponent<Router>(); 
        _StateManager = GameObject.Find("GameEvents").GetComponent<StateManager>();


    }

    void Update() {

        ControllerPosition(); 
        ControllerOrintation();

        // || (Input.GetMouseButtonDown(0)) 


        // Currently Setup for one button interactions. 
        if ((OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))|| (Input.GetMouseButtonDown(0)) || (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))) {


            print(Input.GetMouseButtonDown(0));
            router.teleport();

            if (_StateManager.currentUserState == StateManager.UserState.tutorial) { // if state is tutorial, set CustomControllerButtonDown to true and grab
                CurvedUIInputModule.CustomControllerButtonDown = true; // Is used to interact with menus with the CurvedUIsettings compoenent attached. 
                router.Grab(); // if lazer pointed is pointing at an interactive object, then grab. Look at the Router for more details
            }

            if (_StateManager.currentUserState == StateManager.UserState.browesing) {

                CurvedUIInputModule.CustomControllerButtonDown = true;
                router.Grab();
            }

            if (_StateManager.currentUserState == StateManager.UserState.examining) {

                CurvedUIInputModule.CustomControllerButtonDown = true;
                router.DoAction();
            }

            if (_StateManager.currentUserState == StateManager.UserState.menu) {
                
                CurvedUIInputModule.CustomControllerButtonDown = true;
            }
        }

        else {

            CurvedUIInputModule.CustomControllerButtonDown = false;
        }
    }

    void ControllerOrintation() {


		//transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote); // queries controller rotation from OVR input
        transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote); // queries controller rotation from OVR input
		//transform.rotation = (OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote)) * offset; // adjust orientation of controller factoring in new teleport rotation 







	}

    void ControllerPosition() {
        
        transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch); // queries controller position from OVR input
    }
}


