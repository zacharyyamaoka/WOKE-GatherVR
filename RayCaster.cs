using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayCaster : MonoBehaviour
{
    Ray raycast;
    RaycastHit hit;
    LineRenderer lazerPointer;
    public GameObject activeObject;
    public GameObject noObject;
    bool contact;
    GameObject target;

    void Start() {
        
        lazerPointer = this.GetComponentInChildren<LineRenderer>();
        //target = GameObject.Find("TargetUI");
        //print(target);

    }

    void Update() {
        
        raycast = new Ray(transform.position, transform.forward);
        CurvedUIInputModule.CustomControllerRay = raycast;
        contact = Physics.Raycast(raycast, out hit);

        if (contact) {
            
            activeObject = hit.collider.gameObject;
        }

        else {
            
            activeObject = null;
        }

        PointerLength();
    }

    void PointerLength() {

        if (hit.collider) {
            
            lazerPointer.SetPosition(1, new Vector3(0, 0, hit.distance));
            //print(hit.distance);

            //target.transform.localPosition = new Vector3(0, 0, hit.distance);
            //target.transform.localRotation
        }

        else {
            
            lazerPointer.SetPosition(1, new Vector3(0, 0, 20));
        }
    }
}
   