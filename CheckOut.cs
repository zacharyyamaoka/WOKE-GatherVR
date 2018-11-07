using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOut : MonoBehaviour {

    GameObject checkOutMenu;
    ViewCart _ViewCart;
    public GameObject viewBag;
    public GameObject checkOutMenuUIlocation;

    void Start() {
        
        _ViewCart = GameObject.Find("Actions").GetComponent<ViewCart>();
        checkOutMenu = GameObject.Find("CheckOutMenu");

        checkOutMenu.transform.position = new Vector3(0, -20, 10);
    }

	public void CheckOutMenu() {
        
		_ViewCart.Act();
        //checkOutMenu.transform.position = new Vector3(-0.573f, 1.654f, 1.09f); 
        //checkOutMenu.transform.position = new Vector3(20.932f, 1.467f, 1.089f);
        checkOutMenu.transform.position = checkOutMenuUIlocation.transform.position;
        checkOutMenu.transform.rotation = checkOutMenuUIlocation.transform.rotation;

        viewBag.SetActive(false);
    }

    public void CheckOutMenuBack() {
        
        _ViewCart.Act();
        checkOutMenu.transform.position = new Vector3(0, -20, 10);
    }
}