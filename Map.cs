using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
	public enum Place
	{
        
		Bakery,
		Dairy,
		DryGoods,
		Frozen,
		Fruit,
        Meals,
        NonFood,
        Veggies,
        Featured,
        Tutorial,
        Suggested

	}

	public Place currentMapState;

	void Start()
	{
		//currentMapState = Place.Tutorial;
	}

	public void ChangeMapState(Place state)
	{
		currentMapState = state;
	}
}
