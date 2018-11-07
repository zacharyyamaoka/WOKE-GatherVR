using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCart : MonoBehaviour
{
    ObjectManager _ObjectManager;
    ObjectState _ObjectState;
    StateManager _StateManager;
    GameObject heldObject;
    GameObject controller;
    public GameObject ui;
    bool busy;
    ShelfGrab _ShelfGrab;

    void Start()
    {
        controller = GameObject.Find("Model");

        _ObjectManager = GameObject.Find("GameEvents").GetComponent<ObjectManager>();
        _StateManager = GameObject.Find("GameEvents").GetComponent<StateManager>();

        _ObjectState = new ObjectState();
        busy = false;
        _ShelfGrab = this.GetComponent<ShelfGrab>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Act()
    {
        print("Buttons work");
        if (!(busy))
        {

            StartCoroutine(FlyBehind());//, endlocation));

        }


    }

    void DestroyGUI()
    {
        ui.transform.position = new Vector3(0, -10, 0);
    }

    IEnumerator FlyBehind()
    {
        //busy = true;
        Vector3 location = _ObjectManager.WhatsOffShelf().Value;
        heldObject = _ObjectManager.WhatsOffShelf().Key;

        GameObject purchased = Instantiate(heldObject, heldObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        heldObject.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));

        //heldObject.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));

        //LeanTween.move(purchased, controller.transform.position + controller.transform.forward, 1.5f).setEase(LeanTweenType.easeOutQuad);//.setEase(LeanTweenType.easeOutBack);
        LeanTween.move(purchased, new Vector3(-0.713f, 1.5f, 0.441f), 1.5f).setEase(LeanTweenType.easeOutQuad);//.setEase(LeanTweenType.easeOutBack);
        LeanTween.rotate(heldObject, new Vector3(90, 0, 0), 1.5f).setEase(LeanTweenType.easeOutQuad);
        heldObject.GetComponent<Collider>().enabled = true;

        yield return new WaitForSeconds(1.5f);

        _ObjectState.Free(purchased);

        //busy = false;

    }
}
