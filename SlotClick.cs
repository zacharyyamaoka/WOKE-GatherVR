using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class SlotClick : MonoBehaviour {
    /* Slotclick provides bevhaviours for the fruit slots/buttons on the shopping bag inventory ui. 
     * It also controls the side bar which dislpays a scaled version of the selected fruited ands relevant information;
     */

    public bool pressed;
    public int slotNum; // Define this int from inspector. ie. slotNum for slot0 should be 0
    public GameObject activeObject;
    public static Text sideBarNum;
    public static Text sideBarName;
    public static Text sideBarPrice;
    public static GameObject pressedSlot;
    public static int activeSlot;
    Vector3 largeIconLocation; 
    GameObject purchased;
    GameObject largeIconLocation_gameobject;

    void Start () {

        activeSlot = 100;
        pressedSlot = GameObject.Find("NoSlot");
        largeIconLocation_gameobject = GameObject.Find("LargeIconLocation");
        //largeIconLocation = new Vector3(-0.332f, 1.84f, 1.17f); // Change this vector to change the location the scalled icon apears. Its callibrated to the current position of the shopping cart UI.
        largeIconLocation = largeIconLocation_gameobject.transform.position;
        // Text elements from sidebar
        sideBarNum = GameObject.Find("SideBarNum").GetComponent<Text>();
        sideBarName = GameObject.Find("SideBarName").GetComponent<Text>();
        sideBarPrice = GameObject.Find("SideBarPrice").GetComponent<Text>();
    }
	
    public void slotPressed() {
       
        // function is called by pressed button

        activeSlot = slotNum; // set static variable activeSlot as the instance slotNum

        if (!(pressed)) { // if it wasn't already pressed turn green and make sidebar relevant to its fruit.
            
            StartCoroutine(Green());
        }

        else { // if already pressed then turn off

            pressed = false;
            activeSlot = 100;
        }
    }
      
    IEnumerator Green() {
        
        pressed = true;

        LeanTween.color(gameObject.GetComponent<RectTransform>(), Color.green, 0.1f); // turn the button green, can only be seen when highlighting the slot as the slot material in its unhighlighted state has a low alpha. 

        int i = 0;

        foreach (GameObject key in IFruit.fruitInCart.Keys) {
            
            if (i == slotNum) {
                
                activeObject = key;
                purchased = Instantiate(key, largeIconLocation, Quaternion.Euler(new Vector3(0, 0, 0))); // Create a duplicated version of the fruit icon in the pressed slot on the sidebar
                LeanTween.scale(purchased, new Vector3(1.44f, 1.44f, 1.44f), 0.5f); // scale the duplicated version 
            }

            i++;
        }

        while ((activeSlot == slotNum) && (pressed == true)) { // Start while loop and stay untill the same button is pressed agian or another button is pressed

            // display relevent information
            sideBarNum.text = IFruit.fruitInCart[slotNum].ToString();
            sideBarName.text = activeObject.GetComponent<IFruit>().fruitName;
            sideBarPrice.text = "$" + activeObject.GetComponent<IFruit>().price.ToString() + " each, "  
                + "$" + ((float)(activeObject.GetComponent<IFruit>().price * Convert.ToInt32(IFruit.fruitInCart[slotNum]))).ToString("F2") + " total";
            
            yield return new WaitForSeconds(0.01f);
        }

        // Reset text to empty/idle state
        sideBarNum.text = "";
        sideBarName.text = "Select a Product";
        sideBarPrice.text = "";

        Destroy(purchased); // Destroy the scaled fruit Icon


        LeanTween.color(this.gameObject.GetComponent<RectTransform>(), Color.white, 0.1f); // turn button back to normal
        pressed = false;

        yield return new WaitForSeconds(0.1f);
    }
}
