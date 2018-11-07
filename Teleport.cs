using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    
    public GameObject user;
    public GameObject endTeleport;
    public GameObject startTeleport;
    public GameObject vrController;

    //locations of the teleport points
    public GameObject tel1;
    public Vector3 teleportLoc;
    public Quaternion teleportRot;

    public Vector3 adjustmentLoc;
    public Vector3 adjustmentRot;
    public GameObject _map;

    bool busy;
    ScreenFade fader;

    public GameObject startScreen;
	// Use this for initialization
	void Start () {
        busy = false;
        fader = new ScreenFade();
        //teleportLoc = tel1.transform.position; //stores the game object position
        //teleportRot = tel1.transform.rotation; //stores the game object rotation
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Thankyou(){

        if (busy == false) {

            StartCoroutine(Tele(endTeleport.transform.position, Quaternion.Euler(new Vector3(0, 0, 0))));

        }

	}

    public void Welcome()
    {

        if (busy == false)
        {
            
            StartCoroutine(Tele(startTeleport.transform.position, startTeleport.transform.rotation));
        }
        //user.transform.position = startTeleport.transform.position;
        //user.transform.rotation = Quaternion.identity;

    }

    public void End() {

        fader.FadeOut();

    }


    public void teleTo() {

        StartCoroutine(Tele(teleportLoc, teleportRot));

    }

    IEnumerator Tele(Vector3 endposition, Quaternion endrotation)
    {
        fader.FadeOut();
        busy = true;
        yield return new WaitForSeconds(2f);
        user.transform.position = endposition;
        user.transform.rotation = endrotation;

        //print(endposition);
        //_map = GameObject.Find("Map");
        //_map.transform.localRotation = endrotation;
        //_map.transform.localPosition = endposition;


        fader.FadeIn();
        yield return new WaitForSeconds(2f);
        startScreen.SetActive(false);
        busy = false;
    }
}
