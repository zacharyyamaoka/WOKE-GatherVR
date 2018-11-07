using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectState  
{


    public void Held(GameObject theHeldObject)
    {

        theHeldObject.GetComponent<Rigidbody>().isKinematic = true;
        theHeldObject.GetComponent<Rigidbody>().useGravity = false;
        theHeldObject.GetComponent<InteractiveObject>().currentMotionState = InteractiveObject.MotionState.moving;

    }

     
    public void Free(GameObject theObject)
    {
        theObject.GetComponent<Rigidbody>().isKinematic = false;
        theObject.GetComponent<Rigidbody>().useGravity = true;
        theObject.GetComponent<InteractiveObject>().currentMotionState = InteractiveObject.MotionState.still;

    }




    public bool OffShelf(GameObject theObject) {
        if (theObject.GetComponent<InteractiveObject>().currentShelfState == InteractiveObject.ShelfState.offShelf) {
            return true;
        }
        else {
            return false;
        }
    }

    public bool OnShelf(GameObject theObject)
    {
        if (theObject != null && theObject.GetComponent<InteractiveObject>().currentShelfState == InteractiveObject.ShelfState.onShelf)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void PutOnShelf(GameObject theObject) {
        theObject.GetComponent<InteractiveObject>().currentShelfState = InteractiveObject.ShelfState.onShelf;


    }

    public void TakeOffShelf(GameObject theObject)
    {
        theObject.GetComponent<InteractiveObject>().currentShelfState = InteractiveObject.ShelfState.offShelf;

    }




    public bool CanGrabOffShelf(GameObject theObject){ //asking object can be grabbed
		if ((theObject != null)
	&& (theObject.tag == "InteractiveEnvironment")
	&& (theObject.GetComponent<InteractiveObject>() != null)
	&& (theObject.GetComponent<InteractiveObject>().currentShelfState == InteractiveObject.ShelfState.onShelf)
	&& (theObject.GetComponent<Rigidbody>() != null))
		{
			return true;
		}

		else
		{
			return false;
		}

	}
    public bool IsASign(GameObject theObject){



        if ((theObject != null)
            && (theObject.tag == "Sign"))
        {


            return true;
        }
        else {
            return false;
        }
    }
    public bool IsAUI(GameObject theObject)
    {



        if ((theObject != null)
            && (theObject.tag == "UI"))
        {


            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CanInteract(GameObject theObject)


    {
        if ((theObject != null)
            && (theObject.tag == "InteractiveEnvironment")
            && (theObject.GetComponent<InteractiveObject>() != null)
//            && (theObject.GetComponent<InteractiveObject>().currentGrabState == InteractiveObject.GrabState.grabable)
            && (theObject.GetComponent<Rigidbody>() != null))
        {

            return true;
        }

        else
        {

            return false;
        }
    }

}