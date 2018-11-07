using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight: MonoBehaviour {
    /* This class is used to highlight gameobjects green
     */

    ObjectState _ObjectState;
    GameObject highlighted;
    GameObject activeObject;
    Map _mapState;




    void Start () {
        
        _ObjectState = new ObjectState();
        _mapState = GameObject.Find("Actions").GetComponent<Map>();


	}
	
    public void On() {
        // Callled from ObjectManager Class

        activeObject = this.GetComponent<ObjectManager>().isActive[1]; //finds what object is currently being looked at 

        if (activeObject != null && activeObject.tag == ("TelButton"))
		{

			/*
			print(_mapState.currentMapState.ToString());
			string nameOfTelButton = _mapState.currentMapState.ToString();

			if (activeObject.tag == nameOfTelButton) // if pointing at telbutton that has already been tele. to
			{
                //do nothing.
			}
			else
			{
				highlighted = activeObject;
				LeanTween.color(activeObject, Color.red, 0.1f);
				//update state of map to equal string of 

                _mapState.currentMapState = (enum)nameOfTelButton;
			}
            */


			

            //Check if mapstate equals telbutton state, if so, don't render
			highlighted = activeObject;
			LeanTween.color(activeObject, Color.red, 0.1f);
			




		}

        if(_ObjectState.CanGrabOffShelf(activeObject)) { // if pointing at an object that can be picked up, turn it green
            
            highlighted = activeObject;
            LeanTween.color(activeObject, Color.green, 0.1f);
            if (activeObject.tag == ("Storage")) {
            
            highlighted = activeObject;
            LeanTween.color(activeObject, Color.green, 0.1f);
        }
        }

        if (activeObject != null && activeObject.tag == ("Storage")) {
            
            highlighted = activeObject;
            LeanTween.color(activeObject, Color.green, 0.1f);
        }
    }

    public void Off() {

        if (highlighted != null) { //if something is highlighted, turn what is highlighted off
            
            LeanTween.color(highlighted, Color.white, 0.1f);

        }
    }



}
