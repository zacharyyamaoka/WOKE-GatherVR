using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileGrab : MonoBehaviour
{

    bool busy;

    Vector3 fruitHoldOffset;
    Vector3 GUIOffset;

    GameObject activeObject;
    GameObject heldObject;
    GameObject controller;
    GameObject user;

    ObjectManager _ObjectManager;
    ObjectState _ObjectState;
    StateManager _StateManager;
    UIController _UIController;

    public bool holding;

    // initalize ui from inspector slot. It should be the return button.
    public GameObject ui;
    static public GameObject grabbedStack;

    void Start() {
        // Initalize variables

        fruitHoldOffset = new Vector3(-0.15f, 0, 0); // Adjust fruitHoldOffset to chance position of fruit relative to controller
        GUIOffset = new Vector3(0, 0.6f, 0); // Adjust GUIOffset to change height that return button apears above pile of fruit
        _ObjectState = new ObjectState();
        _ObjectManager = GameObject.Find("GameEvents").GetComponent<ObjectManager>();
        _StateManager = GameObject.Find("GameEvents").GetComponent<StateManager>();
        _UIController = GameObject.Find("GameEvents").GetComponent<UIController>();
        controller = GameObject.Find("Model");
        user = GameObject.Find("MainCamera");
        busy = false;
    }

    void Update() {
        
        activeObject = _ObjectManager.isActive[1];

    }

    void FixedUpdate() {
        // if holding is true then fruit should stay next to the controller
        if (holding) {

            Hold();
        }
    }

    public void NotHolding() {
        // Called by other calsses to turn off holding
        holding = false;
    }

    public void Act() {
        // Called by Router to perform Coroutine Grab
        if (!(busy)) {

            StartCoroutine(Grab());//, endlocation));
        }
    }

    public void Hold() {

        // sets fruits oritation and posistion equal to that of the controller

        heldObject.transform.rotation = controller.transform.rotation * Quaternion.Euler(new Vector3(90, 0, 0));
        float angle = Mathf.Atan(controller.transform.forward.x / controller.transform.forward.z) * Mathf.Rad2Deg;
        heldObject.transform.position = controller.transform.position + controller.transform.forward * 0.05f + fruitHoldOffset;
    }

    void GUI(GameObject theObject) {


        // Calculates a rotation so the UI is always facing the user
        Vector3 netdistance = user.transform.position - theObject.transform.position;
        float angle = Mathf.Atan(netdistance.x / netdistance.z) * Mathf.Rad2Deg;
        float rotation = angle;

        //if (user.transform.eulerAngles.y >= 180) {

            //rotation = angle + 180;
            // something like this will be required if if you want to use the same return sigh at other store locations
        //}

        // Moves the Return button UI to above the fruit pile 
        ui.transform.position = theObject.transform.position + GUIOffset + netdistance/8; // Last part (netdistance/8) moves the return button forward so its not collding with shelves


        ui.transform.rotation = Quaternion.Euler(new Vector3(0, rotation, 0));
    }

    IEnumerator Grab() {
        
        busy = true; // prevent multiple grabbing
        _StateManager.ChangeUserState(StateManager.UserState.busy); // prevent further action when fruit is in the air
        grabbedStack = activeObject;

        print(activeObject + " costs $" + activeObject.GetComponent<IFruit>().price);

        GameObject grabbed = Instantiate(activeObject.GetComponent<IFruit>().fruitPrefab, activeObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0))); // create a copy of the selected fruit. ie. A single watermelon from the pile of watermelon
        _ObjectState.Held(grabbed); // Turn off the fruits gravity, important or else the fruit will build up velocity as it travels and will unnaturally fall at the end of the moition
        _ObjectManager.AddToOffShelf(grabbed); // Add object to offshelf dictionary. It can now be quiries from _ObjectManager.heldObject

        GUI(activeObject);

        // Rotate and move fruit to controller
        LeanTween.rotate(grabbed, new Vector3(90, 0, 0), 1.5f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.move(grabbed, controller.transform.position + (controller.transform.forward * 0.1f) + new Vector3(-0.2f, 0, 0), 1.5f).setEase(LeanTweenType.easeOutQuad);

        grabbed.GetComponent<Collider>().enabled = false; // Disable the fruits collider for extra secruity
        yield return new WaitForSeconds(0.1f); 
        _UIController.On(); // turn the fruits information screen on, change the first WaitforSeconds to increase or decrease delay. 
                            // Both should always sum to 1.5f as that is the time it takes for the object to arrive at the controller.
        yield return new WaitForSeconds(1.4f);


        heldObject = _ObjectManager.WhatsOffShelf().Key;

        holding = true;
        busy = false;

        _StateManager.ChangeUserState(StateManager.UserState.examining); // Set State to examining
    }
}