using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCart : MonoBehaviour {
    /* This Class controls everything in the shopping bag UI 
     * */

    // adjustments are used to find correct posistion for fruit icons. Edit code below to enable adjustments, Run game and then enter adjustments
    public Vector3 adjustment1;
    public Vector3 adjustment2;

    // Slots are the fruit slots in the shopping bag UI. Drag in gameobjects from inspector.
    public GameObject slot0;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    public GameObject slot6;
    public GameObject slot7;
    public GameObject slot8;
    public GameObject slot9;
    public GameObject slot10;
    public GameObject slot11;
    public GameObject slot12;
    public GameObject slot13;
    public GameObject slot14;
    public GameObject slot15;
    public GameObject slot16;
    public GameObject slot17;

    //Buttons are the buttons that correspond with the fruit slots. ie. Drag slot0 into button0

    public Button button0;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;
    public Button button10;
    public Button button11;
    public Button button12;
    public Button button13;
    public Button button14;
    public Button button15;
    public Button button16;
    public Button button17;
    List<GameObject> slots;
    List<Button> buttons;

    // Text items are from the checkout menu. Drag in gameobjects from inspector.
    public Text item0;
    public Text item1;
    public Text item2;
    public Text item3;
    public Text item4;
    public Text item5;
    public Text item6;
    public Text item7;
    public Text item8;

    // Prices are from the checkout menu. Drag in gameobjects from inspector.
    public Text price0;
    public Text price1;
    public Text price2;
    public Text price3;
    public Text price4;
    public Text price5;
    public Text price6;
    public Text price7;
    public Text price8;

    List<Text> items;
    List<Text> prices;

    // define the following checkout text elements from the inspector.
    public Text checkOutTotal;
    public Text tax;
    public Text subtotal;

    public Text outsideBagTotal; // Drag in text compoenent from the Price counter on the side of the bag

    public enum Page
    {

        page1,
        page2,
        page3

    }

    public Text totalText; // Total text from shopping cart inventory ui. 

    public Page currentPage;
    Vector3 storage;

    GameObject offset_colum1;
    GameObject offset_colum2;
    GameObject offset_colum3;

    void Start() {

        storage = new Vector3(0, 20, 30);
        currentPage = Page.page1;
        totalText = GameObject.Find("SideBarTotal").GetComponent<Text>();
        offset_colum1 = GameObject.Find("cartUI_Colum1");
        offset_colum2 = GameObject.Find("cartUI_Colum2");
        offset_colum3 = GameObject.Find("cartUI_Colum3");

        slots = new List<GameObject> {
            slot0, 
            slot1,
            slot2,
            slot3,
            slot4,
            slot5,
            slot6,
            slot7,
            slot8,
            slot9,
            slot10,
            slot11,
            slot12,
            slot13,
            slot14,
            slot15,
            slot16,
            slot17
        };

        items = new List<Text> {
            item0,
            item1,
            item2,
            item3,
            item4,
            item5,
            item6,
            item7,
            item8,
        };

        prices = new List<Text> {
            price0,
            price1,
            price2,
            price3,
            price4,
            price5,
            price6,
            price7,
            price8
        };

            buttons = new List<Button> {
            
            button0,
            button1,
            button2,
            button3,
            button4,
            button5,
            button6,
            button7,
            button8,
            button9,
            button10,
            button11,
            button12,
            button13,
            button14,
            button15,
            button16,
            button17 
        };

    }
        
    public void Add() { // Increase the fruit in questino by 1. Called from the plus button

            if (SlotClick.activeSlot <  IFruit.fruitInCart.Count) { 

                IFruit.fruitInCart[SlotClick.activeSlot] = Convert.ToInt32(IFruit.fruitInCart[SlotClick.activeSlot]) + 1;
            }

    }

    public void Subtract() { // Decreases the fruit in question by 1. Called from the minus button. If fruit quanity is = 0, then it is delted from inventory

        if (SlotClick.activeSlot < IFruit.fruitInCart.Count) {
            
            IFruit.fruitInCart[SlotClick.activeSlot] = Convert.ToInt32(IFruit.fruitInCart[SlotClick.activeSlot]) - 1;

            if (Convert.ToInt32(IFruit.fruitInCart[SlotClick.activeSlot]) == 0) { // if fruit quanity is zero then delte it from the dictionary fruitInCart
                
                int i = 0;
                foreach (GameObject key in IFruit.fruitInCart.Keys) { // loop thorugh dictionary until you find the correspoding key. 
                
                    if (i == SlotClick.activeSlot) {

                        slots[i].GetComponentInChildren<Text>().text = ""; // reset the slot text to empty
                        key.transform.position = new Vector3(0, -20, 30); // move the fruit icon to storage
                        IFruit.fruitInCart.Remove(key); // delete the key from the dictionary
                        SlotClick.activeSlot = 100; // set the activeSlot to an arbiratly large number so the fruit that was in the active slot can no longer be accesed
                    }

                    i++;
                }
            }
        }
    }

    void Update () {
        
        float total = 0;
        int i = 0;
        foreach (GameObject key in IFruit.fruitInCart.Keys) {

            buttons[i].interactable = true; // turn on the slots with fruit so they will turn green when highlighted

            if (i <= 8) {

                if (currentPage == Page.page1) {
                    
                    if ((i == 0) || (i == 3) || (i == 6) ) {
                        // for the fruit in slots 0, 3 and 6 move to a the slot posisiton plus a small correction. The correction accounts for the curviterure of the UI. This correction can be manually calucalted
                        // by enabling the adjusmtents vectors, running a game, picking up + buying a fruit and then making live updates to the vectors from the inspector while the game is running.

                        //key.transform.position = slots[i].transform.position + new Vector3(0.06f, 0, -0.05f); // + adjustment1;
                        //key.transform.position = slots[i].transform.position + new Vector3(-0.02f, 0, -0.08f); // + adjustment1;

                        // IF FRUIT IS RANDOMLY FLOATING IN AIR - THIS MAY BE THE PROBLEM BELOW. Qucick fix is just to store the cartui further below so
                        // the slot y position offset is greater and will hide the fruit until the cart ui is teleported into the correct posision.
                        key.transform.position = new Vector3(offset_colum1.transform.position.x, slots[i].transform.position.y, offset_colum1.transform.position.z);
					}

                    if ((i == 1) || (i == 4) || (i == 7)) {

                        //key.transform.position = slots[i].transform.position + new Vector3(0.03f, 0, -0.03f);
                        key.transform.position = new Vector3(offset_colum2.transform.position.x, slots[i].transform.position.y, offset_colum2.transform.position.z);

                    }

                    if ((i == 2) || (i == 5) || (i == 8)) {

                        //key.transform.position = slots[i].transform.position + new Vector3(0.01f, 0, 0.01f);
                        key.transform.position = new Vector3(offset_colum3.transform.position.x, slots[i].transform.position.y, offset_colum3.transform.position.z);
                    }
                }

                if (currentPage == Page.page2) {
                    
                    key.transform.position = storage; // hide all fruit icons on the second page. As a sinigle page only holds 8 fruit and I <= 8.
                }

                if (currentPage == Page.page3) {

                }
            }


            if (i > 8) { // Implement for multi page functionality

                if (currentPage == Page.page1) {
                    
                    key.transform.position = storage;
                }
                if (currentPage == Page.page2) {
                    
                    key.transform.position = slots[i].transform.position;
                }
                if (currentPage == Page.page3) {
                }
            }

            if (i > 18) {// Implement for multi page functionality

                if (currentPage == Page.page1) {
                }
                if (currentPage == Page.page2) {
                }
                if (currentPage == Page.page3) {
                }
            }
    

            // Update checkout recipt text
            prices[i].text = "$" + key.GetComponent<IFruit>().price.ToString("F2");
            items[i].text = IFruit.fruitInCart[i].ToString() + " " + key.GetComponent<IFruit>().fruitName;

            // Update quantiies on invetory UI
            slots[i].GetComponentInChildren<Text>().text = "x" + IFruit.fruitInCart[i].ToString();

            // Incremental total price of goods by price of fruit in current loop
            total = total + (float)(key.GetComponent<IFruit>().price * Convert.ToInt32(IFruit.fruitInCart[i]));
            i++;
        }

        // Update dynamic text
        totalText.text = "$" + total.ToString("F2"); // Total price on shopping bag inventory UI
        float taxvalue = total * 0.10f; // calculate 10% tax
        tax.text = "$" + taxvalue.ToString("F2"); // Tax
        subtotal.text = "$" + total.ToString("F2"); // Subtotal 
        outsideBagTotal.text = "$" + total.ToString("F2"); // Price display outside bag
        checkOutTotal.text = "$" + (total + taxvalue).ToString("F2"); // Checkout total price

        for (int num = IFruit.fruitInCart.Count; num <= 17; num++)
        {
            buttons[num].interactable = false; // turn off slots that do not hold a fruit, so they do not turn green on highlight.

            // reset text of empty slots
            slots[num].GetComponentInChildren<Text>().text = ""; 
            prices[i].text = "";
            items[i].text = "";

        }
    }
}
    