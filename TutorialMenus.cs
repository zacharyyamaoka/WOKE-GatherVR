using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenus : MonoBehaviour {
    public GameObject menu0;
    public GameObject menu1;
    public GameObject menu2;
    public GameObject menu3;
    public GameObject menu4;

    public GameObject Fruit;

    Teleport _Teleport;
    StateManager _StateManager;


    // Use this for initialization
    void Start () {
        Fruit.SetActive(false); // enable this when your starting in the tutorial room
        _Teleport = this.GetComponent<Teleport>();
        _StateManager = GameObject.Find("GameEvents").GetComponent<StateManager>();

    }
	
	// Update is called once per frame
	void Update () {
		


	}


    public void ZeroTooOne() {
        print("clicked");
        _Teleport.Welcome();
        Fruit.SetActive(true);

    }

    public void OneTooTwo()
    {

        _Teleport.Welcome();
        Fruit.SetActive(true);

    }

    public void TwoTooThree()
    {
        _Teleport.Welcome();
        Fruit.SetActive(true);


    }

    public void ThreeTooFour()
    {


        _Teleport.Welcome();
        Fruit.SetActive(true);
    }

}
