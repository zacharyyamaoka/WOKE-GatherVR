﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InteractiveObject : MonoBehaviour
{
    
    public enum MotionState {
        still,
        moving
    }


    public enum GrabState {
        grabable,
        notGrabable
    }

    public enum ShelfState{
        onShelf,
        offShelf
        }

    public MotionState currentMotionState;
    public GrabState currentGrabState;
    public ShelfState currentShelfState;

        public bool colliding;
        void Awake ()
        {

                currentMotionState = MotionState.still;
                currentGrabState = GrabState.grabable;
                currentShelfState = ShelfState.onShelf;
        }
     void FixedUpdate() {

        if (colliding && (currentMotionState == MotionState.moving)) {
            
           currentGrabState = GrabState.notGrabable;
        }
    }

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag != "InteractiveEnvironment") {
            
            if ((currentMotionState == MotionState.still)) {
                
                colliding = false;
            }
        }

        if ((currentMotionState == MotionState.moving)) {
            
            colliding = true;
        }
    }

    void OnTriggerStay(Collider other) {

        if ((currentMotionState == MotionState.moving)) {

            colliding = true;
            currentGrabState = GrabState.notGrabable;
        }
    }
}



