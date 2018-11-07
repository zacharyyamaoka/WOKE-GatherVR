using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingBag : MonoBehaviour {
    /* This Class provides behaviours for the shopping bag and relevant gameobjects
     */

    public GameObject totalButton;

    void OnCollisionEnter(Collision collision){ // destoys fruit upon collision with shopping bag

        //LeanTween.color(totalButton.GetComponent<RectTransform>(), Color.green, 0.1f);
        Destroy(collision.gameObject);
        //LeanTween.color(totalButton.GetComponent<RectTransform>(), Color.white, 0.1f).setDelay(0.3f);

    }

    void OnCollisionExit(Collision collision)
    {


    }

    public void FlashGreen() { // turns total counter outside bag green
        
        LeanTween.color(totalButton.GetComponent<RectTransform>(), Color.green, 0.1f);
        LeanTween.color(totalButton.GetComponent<RectTransform>(), Color.white, 0.1f).setDelay(0.3f);

    }




   
}
