using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileSwitch : MonoBehaviour
{
    ObjectManager _ObjectManager;
    ObjectState _ObjectState;
    UIController _UIController;
    StateManager _StateManager;
    GameObject heldObject;
    GameObject activeObject;
    public GameObject ui;
    bool busy;
    PileGrab _PileGrab;
    /* void Start()
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
         activeObject = _ObjectManager.isActive[1];

     }
     public void Act()
     {
         if (!(busy))
         {
             if (_StateManager.currentUserState == StateManager.UserState.examining)
             {

                 StartCoroutine(PutBack());//, endlocation));

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
         _StateManager.ChangeUserState(StateManager.UserState.busy);
         _PileGrab.NotHolding();
         DestroyGUI();
         _UIController.Clear();
         Vector3 location = _ObjectManager.WhatsOffShelf().Value;
         heldObject = _ObjectManager.WhatsOffShelf().Key;
         _ObjectManager.AddToShelf(heldObject);

      LeanTween.move(heldObject, location + new Vector3(0, 1.0f, 0), 1.5f).setEase(LeanTweenType.easeOutQuad);//.setEase(LeanTweenType.easeOutBack);
         LeanTween.rotate(heldObject, new Vector3(-90, 0, 0), 1.5f).setEase(LeanTweenType.easeOutQuad);


         PileGrab.grabbedStack = activeObject;
         GameObject grabbed = Instantiate(activeObject.GetComponent<IFruit>().fruitPrefab, activeObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
         _ObjectState.Held(grabbed);
         _ObjectManager.AddToOffShelf(grabbed);
         GUI(activeObject);

     LeanTween.rotate(grabbed, new Vector3(90, 0, 0), 1.5f).setEase(LeanTweenType.easeOutQuad);
     LeanTween.move(grabbed, controller.transform.position + (controller.transform.forward* 0.1f)  + new Vector3(-0.2f, 0, 0), 1.5f).setEase(LeanTweenType.easeOutQuad);//.setEase(LeanTweenType.easeOutBack);
         mover = heldObject.GetComponent<Rigidbody>();

         yield return new WaitForSeconds(1.5f);




         _ObjectState.Free(heldObject);


         yield return new WaitForSeconds(1f);

         Destroy(heldObject);
         //heldObject.GetComponent<Collider>().enabled = true;

         _StateManager.ChangeUserState(StateManager.UserState.examining);

         busy = false;

     }
 }




 grabbed.GetComponent<Collider>().enabled = false;

         yield return new WaitForSeconds(1.5f);

 heldObject = _ObjectManager.WhatsOffShelf().Key;
         mover = heldObject.GetComponent<Rigidbody>();

         holding = true;
       ;*/


}