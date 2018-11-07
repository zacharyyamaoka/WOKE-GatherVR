using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace VRStandardAssets.Utils{
public class ScreenFade
    {
        VRCameraFade fade;

        public ScreenFade(){


        }

        public void FadeOut(){

        CanvasGroup faderScreen = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<CanvasGroup>();
        LeanTween.alphaCanvas(faderScreen, 1f, 2f);

        }
        public void FadeIn(){
        CanvasGroup faderScreen = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<CanvasGroup>();
        LeanTween.alphaCanvas(faderScreen, 0f, 2f);


    }
    }
//}
