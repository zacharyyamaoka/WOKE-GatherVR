using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileToCart : MonoBehaviour {
    /* PileToCart is an action that is called from the Router Class. Its main function Act() starts the coroutine GoToBag(). 
     * GoToBag, quieres the held object from the object manager, creates a copy of it, and then moves + drops it over the bag
     */

    ObjectManager _ObjectManager;
    ObjectState _ObjectState;
    StateManager _StateManager;
    public GameObject ui; // The ui gameobject needs to be defined from the inspector, it should be the return button gameobject
    GameObject heldObject;
    ShoppingBag _ShoppingBag;
    GameObject shoppingBag;

    void Start()
    {
        shoppingBag = GameObject.Find("ShoppingBag");
        _ShoppingBag = shoppingBag.GetComponent<ShoppingBag>();
        _ObjectManager = GameObject.Find("GameEvents").GetComponent<ObjectManager>();
        _StateManager = GameObject.Find("GameEvents").GetComponent<StateManager>();
        _ObjectState = new ObjectState();
    }

    public void Act() { // All actions need to implment the function Act()
        
        StartCoroutine(GoToBag());
    }

    void DestroyGUI() {
        
        ui.transform.position = new Vector3(0, -10, 0);
    }

    IEnumerator GoToBag() {

        // Queries currently held gameobject and its location
        Vector3 location = _ObjectManager.WhatsOffShelf().Value;
        heldObject = _ObjectManager.WhatsOffShelf().Key;

        // Creates at copy of held gameobject at the same location
        GameObject purchased = Instantiate(heldObject, heldObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        heldObject.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        heldObject.GetComponent<IFruit>().AddToCart(); // Calls the AddToCart() function from IFRUIT, which increase the amount purchased of the held object by one (+1)
        _ShoppingBag.FlashGreen();
        // Moves duplicated gameobject over the bag
        LeanTween.move(purchased, shoppingBag.transform.position + new Vector3(0, 0.6f, 0), 1.5f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.rotate(heldObject, new Vector3(90, 0, 0), 1.5f).setEase(LeanTweenType.easeOutQuad);



        yield return new WaitForSeconds(1.5f); // Wait for object to reach desired location

        purchased.GetComponent<Collider>().enabled = true; // Turn on the duplicated gameobjects collider. 
                                                           // This allows its to collide with the Shopping bag, which destroys it. Look at ShoppingBag class for more Details

        _ObjectState.Free(purchased); // Drops gameobject into bag by enabling gravity, look at class ObjectState for more details

    }
}
