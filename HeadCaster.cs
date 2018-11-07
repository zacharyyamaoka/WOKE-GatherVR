using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCaster : MonoBehaviour
{
    Ray raycast;
    public GameObject activeObject;
    RaycastHit hit;
    bool contact;
    void Start()
    {
    }

    void Update()
    {
        raycast = new Ray(transform.position, transform.forward);
        CurvedUIInputModule.CustomControllerRay = raycast;
        contact = Physics.Raycast(raycast, out hit);
        if (contact)
        {
            activeObject = hit.collider.gameObject;
        }
        else
        {
            activeObject = null;
        }
    }
}
