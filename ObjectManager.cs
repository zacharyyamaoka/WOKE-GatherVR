using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectManager : MonoBehaviour {
    /* The ObjectManager class manges both the hit object's (those that are under the lazer pointer) 
     * and the held objects (those that are floating next to the controller)
     */
    public GameObject activeObject;
    public GameObject heldObject;
    GameObject dummy1;
    GameObject dummy2;
    Highlight _Highlight;
    public List<GameObject> isActive;
    public Dictionary<GameObject, Vector3> objectsOffShelf;
    Map _mapState;
    GameObject user;
  
    void Start() {
        dummy1 = new GameObject();
        dummy2 = new GameObject();
        isActive = new List<GameObject> { dummy1, dummy2 };
        objectsOffShelf = new Dictionary<GameObject, Vector3>();

        _mapState = GameObject.Find("Actions").GetComponent<Map>();


        user = GameObject.Find("User");
        _Highlight = this.GetComponent<Highlight>();

    }

	void Update () {
        if (user.GetComponentInChildren<RayCaster>().activeObject != null) {
            activeObject = user.GetComponentInChildren<RayCaster>().activeObject; // Get RayCaster compoenent from User

		/*
        if (activeObject != null && activeObject.tag == ("TelButton"))
		{
            //print(activeObject.GetComponent<Map>().currentMapState);
            //print(_mapState.currentMapState);



			// if hitObject is a telbutton and enum of mapState equals enum of tele script attached to telButton
			if (activeObject.GetComponent<Map>().currentMapState == _mapState.currentMapState){
                //don't pass it into ObjectMemory or get highlighted
                print("YEAHH");

            } else {
				// MAKE OBJECT INTERACTIVE (repeated below )
				ObjectMemory(activeObject);
				_Highlight.On(); // Highlights interactive objects, look at Highlight class for more Detials
				heldObject = WhatsOffShelf().Key; // Quires the heldobject from the dictionary ObjectsOffshelf

                _mapState.currentMapState = activeObject.GetComponent<Map>().currentMapState; //set map to new state of telButton

			} 

		}


        // If the active object isn't Telbutton (anything else that can be highlightte)
        if (activeObject != null && activeObject.tag != ("TelButton"))
        { 
            // MAKE OBJECT INTERACTIVE (repeated above )
            ObjectMemory(activeObject);
    		_Highlight.On(); // Highlights interactive objects, look at Highlight class for more Detials
    		heldObject = WhatsOffShelf().Key; // Quires the heldobject from the dictionary ObjectsOffshelf
        }
        */

		ObjectMemory(activeObject);
		_Highlight.On(); // Highlights interactive objects, look at Highlight class for more Detials
		heldObject = WhatsOffShelf().Key; // Quires the heldobject from the dictionary ObjectsOffshelf
        }
        else {
            NewActive();
        }
	}


    public void ObjectMemory(GameObject hitObject) {

        /* This functions is a memory for pointed at objects. It will store the object currently being point at as isActive[1]
            and the object the was previosuly pointed at as isActive[0] */



        if (hitObject != isActive[1]) { // Returns true when pointing at a new object. 
            isActive.RemoveAt(0); // Remove the dummy 1 [index 0] of isActive List
            isActive.Add(hitObject); // Add the new object (hitObject) to the front of isActive List
            NewActive();
        }
    }

    public void NewActive() { // Turns off highlight on previously pointed at object, when a new obejct is pointed at

        _Highlight.Off();

    }

    public void AddToOffShelf(GameObject theGameObject) { // Called from outside classes when holding an object
        
        if (objectsOffShelf.ContainsKey(theGameObject) != true) {

            objectsOffShelf.Add(theGameObject, theGameObject.transform.position);
        }
    }

    public void AddToShelf(GameObject theGameObject) { // Called from outside classes when returning an object
        
        if (objectsOffShelf.ContainsKey(theGameObject)) {
            
            objectsOffShelf.Remove(theGameObject);
        }
    }

    public KeyValuePair<GameObject, Vector3> WhatsOffShelf() { // Called from outside classes to query for the currently held object

        foreach (KeyValuePair<GameObject, Vector3> entry in objectsOffShelf) {

            return new KeyValuePair<GameObject, Vector3>(entry.Key, entry.Value);
        }

        return new KeyValuePair<GameObject, Vector3>(null, new Vector3(0, 0, 0));
    }
}

