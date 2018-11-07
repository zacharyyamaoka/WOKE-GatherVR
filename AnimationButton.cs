using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationButton : MonoBehaviour {

    public Animator animator;
    int currentSlide;
    int firstSlide;
    int lastSlide;
    bool busy;

    void Start () {

        firstSlide = 1;
        currentSlide = 1;
        lastSlide = 3;
	}

    public void Reset() {
        
        StartCoroutine(BackToOne());
    }

    public void RightPressed() {

        if (currentSlide < lastSlide) {
            
            animator.SetTrigger("RightPressed");
            currentSlide += 1;
        }
    }

    public void LeftPressed() {

        if (currentSlide > firstSlide) {

            animator.SetTrigger("LeftPressed");
            currentSlide -= 1;
        } 
    }

    IEnumerator BackToOne() {
        
        while (currentSlide > firstSlide) {
            
            LeftPressed();
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1.5f);
    }
}
