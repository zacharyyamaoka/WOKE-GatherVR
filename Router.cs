using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Router : MonoBehaviour {
    /* The Router Class is used to assign specific Action classes to the actions called by VRController. 
     * Its an attempt to decouple the controller from the actions
     */

    ShelfGrab _Shelfgrab;
    GameObject activeObject;
    ObjectState _ObjectState;
    ObjectManager _ObjectManager;
    StateManager _StateManager;
    ViewCart _ViewCart;
    PileGrab _PileGrab;
    PileReturn _PileReturn;
    PileToCart _PileToCart;
    Map _mapState;

    void Start()
    {
        _ObjectState = new ObjectState();
        _ObjectManager = GameObject.Find("GameEvents").GetComponent<ObjectManager>(); //gets the component ObjectManager from the GameObject GameEvents

        // Intialize actions from components on Action gameobject. All future actions should be attached to Action object and called in the same way
        // All actions also need to implment the function Act()
        _PileGrab = GameObject.Find("Actions").GetComponent<PileGrab>();
        _Shelfgrab = GameObject.Find("Actions").GetComponent<ShelfGrab>();
        _StateManager = GameObject.Find("GameEvents").GetComponent<StateManager>();
        _ViewCart = GameObject.Find("Actions").GetComponent<ViewCart>();
        _PileToCart = GameObject.Find("Actions").GetComponent<PileToCart>();
        _PileReturn = GameObject.Find("Actions").GetComponent<PileReturn>();

        _mapState = GameObject.Find("Actions").GetComponent<Map>();

    }

    public void Buy() {
        
        _PileToCart.Act();
    }

    public void DoAction()
    {
        //"this" is equal to the GameObject (active objects)
        if (this.GetComponent<ObjectManager>().isActive[1] != null) { // if pointed at something
            
            if (this.GetComponent<ObjectManager>().isActive[1].tag == "Storage") { // if pointing at shopping bag, add fruit to bag

                _PileToCart.Act();
            }


            else if (this.GetComponent<ObjectManager>().isActive[1].transform.root.tag != null &&
                    this.GetComponent<ObjectManager>().isActive[1].transform.root.tag == "UI") { // if point at screen UI do nothing with fruit
                
            }

            else {

                _PileReturn.Act(); // otherwise return the fruit to its pile
            }

        } else { //if nothing is selected
            _PileReturn.Act(); // otherwise return the fruit to its pile
		}


    }

    public void teleport(){
        if (this.GetComponent<ObjectManager>().isActive[1] != null && this.GetComponent<ObjectManager>().isActive[1].tag == "TelButton")
		{

            //_mapState.currentMapState = this.GetComponent<Map>().currentMapState; //set map to new state of telButton

            //if current state doesn't equal map state, then allow it to teleport. 
			
            //if not already teleported to, let it teleport
            if (this.GetComponent<Map>().currentMapState != _mapState.currentMapState){
                //don't pass it into ObjectMemory or get highlighted
                //print("YEAHH");
                this.GetComponent<ObjectManager>().isActive[1].GetComponent<Teleport>().teleTo();

            }



            // set the currentMapState to equal the name of the object being clicked on (Bakery, Dairy, DryGoods, etc)
            //print(map.currentMapState);



		}

	}

    public void Grab() {
        
        activeObject = this.GetComponent<ObjectManager>().isActive[1];

		if (_ObjectState.CanGrabOffShelf(activeObject)) { // if you can grab the pointed at object grab it.
            _PileGrab.Act();
            _StateManager.ChangeUserState(StateManager.UserState.busy);
        }
    }

    public void Release() {

        activeObject = this.GetComponent<ObjectManager>().isActive[1];
        if (_ObjectState.IsAUI(activeObject)) {
       
        }
    }

    IEnumerator Switch() { // not used, needs debugging. Is intended to application is if pointed at a different pile of fruit,
                           // autonamticly return currently held fruit and grab new fruit.
   
        _PileReturn.Act();
        yield return new WaitForSeconds(1.5f);
        _PileGrab.Act();
    }
}