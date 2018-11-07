using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herringbone: MonoBehaviour {
    /* This class is just for the herringbone
     */

    ObjectState _ObjectState;
    GameObject highlighted;
    GameObject activeObject;



    void Start () {
        
        _ObjectState = new ObjectState();
	}
	
    void Update() {
        // Callled from ObjectManager Class


        activeObject = this.GetComponent<RayCaster>().activeObject;

        print(activeObject);

        if (activeObject != null){
			if (activeObject.tag != null && activeObject.tag == ("Herringbone"))
			{ // if pointing at an object that can be picked up, turn it green

				highlighted = activeObject;
				LeanTween.color(activeObject, Color.green, 0.1f);

			}

			if (activeObject.tag == ("Herringbone"))
			{

				highlighted = activeObject;
				LeanTween.color(activeObject, Color.green, 0.1f);
			}
        }


    }

    public void Off() {

        if (highlighted != null) {
            
            LeanTween.color(highlighted, Color.white, 0.1f);
        }
    }

	//public void Update()
	//{
	//	if ()
	//	{

	//	}
	//}


}
