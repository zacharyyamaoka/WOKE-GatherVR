using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCart : MonoBehaviour {
    
    GameObject user;
    public GameObject menu;
    public GameObject viewBag;
    ObjectManager _ObjectManager;
    ObjectState _ObjectState;
    UIController _UIController;
    StateManager _StateManager;
    PileReturn _PileReturn;
    public GameObject viewCartUIlocation;
    bool busy;
    bool menuUp;

    void Start() {
        
        user = GameObject.Find("User");
        _ObjectManager = GameObject.Find("GameEvents").GetComponent<ObjectManager>();
        _StateManager = GameObject.Find("GameEvents").GetComponent<StateManager>();
        _UIController = GameObject.Find("GameEvents").GetComponent<UIController>();
        _PileReturn = GameObject.Find("Actions").GetComponent<PileReturn>();
        _ObjectState = new ObjectState();

        busy = false;
        menuUp = false;
        menu.transform.position = new Vector3(0, -20, 0);
    }

    public void Act() {

        if (!(menuUp)) {
            
            if (!busy) {

                //menu.transform.position = new Vector3(-0.573f, 1.654f, 1.09f);// + new Vector3(user.transform.position.x, 0 , user.transform.position.z);
                //menu.transform.position = new Vector3(20.932f, 1.462f, 1.089f);// + new Vector3(user.transform.position.x, 0 , user.transform.position.z);
                menu.transform.position = viewCartUIlocation.transform.position;
                menu.transform.rotation = viewCartUIlocation.transform.rotation;
				menuUp = true;
                viewBag.SetActive(false);

                StartCoroutine(BringUp());

                if (_StateManager.currentUserState == StateManager.UserState.examining) {
                    
                    _PileReturn.Act();
                }

                _StateManager.currentUserState = StateManager.UserState.menu;
            }
        }

        else {
            
            if (!busy) {

            _StateManager.currentUserState = StateManager.UserState.browesing;
            StartCoroutine(BringUp());
            viewBag.SetActive(true);
            menu.transform.position = new Vector3(0, -20, 0);
            menuUp = false;
            SlotClick.activeSlot = 100;

            }
        }
    }

    IEnumerator BringUp() {
        
        busy = true;
        yield return new WaitForSeconds(1.5f);
        busy = false;
    }
}   