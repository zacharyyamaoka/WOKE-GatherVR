using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {
    
    public enum UserState {
        
        browesing,
        examining,
        menu,
        tutorial,
        busy
    }

    public UserState currentUserState;

    void Start() {

        currentUserState = UserState.tutorial; // enable when not debugging and starting in tutorial room
        //currentUserState = UserState.browesing;

	}

   public void ChangeUserState(UserState state) {
        
        currentUserState = state;
    }
}
