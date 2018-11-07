using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class FruitInfoTabs : MonoBehaviour
{

    public Sprite image0;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    public Sprite image4;

    public GameObject currentImage;

    // button objects
    public GameObject button0;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    // non highlighted buttons
	public Sprite buttonNotSelected0;
    public Sprite buttonNotSelected1;
    public Sprite buttonNotSelected2;
    public Sprite buttonNotSelected3;
    public Sprite buttonNotSelected4;

	// non highlighted buttons
	public Sprite buttonSelected0;
	public Sprite buttonSelected1;
	public Sprite buttonSelected2;
	public Sprite buttonSelected3;
	public Sprite buttonSelected4;

    // view button (tab 0)
    public GameObject viewButton;

	// view button (tab 0)
	public GameObject visitFarmButton;

	
    void Start() {
		//select button 1 by default
		button0.GetComponent<Image>().sprite = buttonSelected0;
		// show/hide the view button
		viewButton.SetActive(true);
		// show/hide the visit farm button
		visitFarmButton.SetActive(false);
    }



    public void Button0() {
        // update UI tab image
        currentImage.GetComponent<Image>().sprite = image0;
        // highlight this button
        button0.GetComponent<Image>().sprite = buttonSelected0;
        // un-highlight all other buttons
        button1.GetComponent<Image>().sprite = buttonNotSelected1;
        button2.GetComponent<Image>().sprite = buttonNotSelected2;
        button3.GetComponent<Image>().sprite = buttonNotSelected3;
        button4.GetComponent<Image>().sprite = buttonNotSelected4;
        // show/hide the view button
        viewButton.SetActive(true);
		// show/hide the visit farm button
        visitFarmButton.SetActive(false);

	}

	public void Button1()
	{
		// update UI tab image
		currentImage.GetComponent<Image>().sprite = image1;
		// highlight this button
		button1.GetComponent<Image>().sprite = buttonSelected1;
		// un-highlight all other buttons
		button0.GetComponent<Image>().sprite = buttonNotSelected0;
		button2.GetComponent<Image>().sprite = buttonNotSelected2;
		button3.GetComponent<Image>().sprite = buttonNotSelected3;
		button4.GetComponent<Image>().sprite = buttonNotSelected4;
		// show/hide the view button
		viewButton.SetActive(false);
		// show/hide the visit farm button
		visitFarmButton.SetActive(true);
	}

	public void Button2()
	{
		// update UI tab image
		currentImage.GetComponent<Image>().sprite = image2;
		// highlight this button
		button2.GetComponent<Image>().sprite = buttonSelected2;
		// un-highlight all other buttons
		button0.GetComponent<Image>().sprite = buttonNotSelected0;
		button1.GetComponent<Image>().sprite = buttonNotSelected1;
		button3.GetComponent<Image>().sprite = buttonNotSelected3;
		button4.GetComponent<Image>().sprite = buttonNotSelected4;
		// show/hide the view button
		viewButton.SetActive(false);
		// show/hide the visit farm button
		visitFarmButton.SetActive(false);
	}

	public void Button3()
	{
		// update UI tab image
		currentImage.GetComponent<Image>().sprite = image3;
		// highlight this button
		button3.GetComponent<Image>().sprite = buttonSelected3;
		// un-highlight all other buttons
		button0.GetComponent<Image>().sprite = buttonNotSelected0;
        button1.GetComponent<Image>().sprite = buttonNotSelected1;
		button2.GetComponent<Image>().sprite = buttonNotSelected2;
		button4.GetComponent<Image>().sprite = buttonNotSelected4;
		// show/hide the view button
		viewButton.SetActive(false);
		// show/hide the visit farm button
		visitFarmButton.SetActive(false);
	}

	public void Button4()
	{
		// update UI tab image
		currentImage.GetComponent<Image>().sprite = image4;
		// highlight this button
		button4.GetComponent<Image>().sprite = buttonSelected4;
		// un-highlight all other buttons
		button0.GetComponent<Image>().sprite = buttonNotSelected0;
		button1.GetComponent<Image>().sprite = buttonNotSelected1;
		button2.GetComponent<Image>().sprite = buttonNotSelected2;
        button3.GetComponent<Image>().sprite = buttonNotSelected3;
		// show/hide the view button
		viewButton.SetActive(false);
		// show/hide the visit farm button
		visitFarmButton.SetActive(false);
		
	}

}