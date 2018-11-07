using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileReturn : MonoBehaviour
{
    ObjectManager _ObjectManager;
    ObjectState _ObjectState;
    UIController _UIController;
    StateManager _StateManager;
    GameObject heldObject;
    public GameObject ui;
    bool busy;
    PileGrab _PileGrab;
    void Start()
    {
        _ObjectManager = GameObject.Find("GameEvents").GetComponent<ObjectManager>();
        _StateManager = GameObject.Find("GameEvents").GetComponent<StateManager>();
        _UIController = GameObject.Find("GameEvents").GetComponent<UIController>();
        _ObjectState = new ObjectState();
        busy = false;
        _PileGrab = this.GetComponent<PileGrab>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Act()
    {
        if (!(busy))
        {
            StartCoroutine(PutBack());

            if (_StateManager.currentUserState == StateManager.UserState.examining)
            {

                //StartCoroutine(PutBack());//, endlocation));

            }

        }


    }

    void DestroyGUI()
    {
        ui.transform.position = new Vector3(0, -10, 0);
    }

    IEnumerator PutBack()
    {
        busy = true;

        Vector3 location = _ObjectManager.WhatsOffShelf().Value;
        heldObject = _ObjectManager.WhatsOffShelf().Key;
        _ObjectManager.AddToShelf(heldObject);

        _StateManager.ChangeUserState(StateManager.UserState.busy);
        _PileGrab.NotHolding();
        DestroyGUI();

        _UIController.Clear();



     


        //heldObject.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));


        LeanTween.move(heldObject, location + new Vector3(0, 1.0f, 0), 1.5f).setEase(LeanTweenType.easeOutQuad);//.setEase(LeanTweenType.easeOutBack);

        LeanTween.rotate(heldObject, new Vector3(-90, 0, 0), 1.5f).setEase(LeanTweenType.easeOutQuad);
        yield return new WaitForSeconds(1.5f);
        _StateManager.ChangeUserState(StateManager.UserState.browesing);
        _ObjectState.Free(heldObject);


        yield return new WaitForSeconds(0.5f);

        Destroy(heldObject);
        //heldObject.GetComponent<Collider>().enabled = true;


        busy = false;

    }
}