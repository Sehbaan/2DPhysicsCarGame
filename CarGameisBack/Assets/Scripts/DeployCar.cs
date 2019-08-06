﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployCar : MonoBehaviour {

    public GameObject car;
    public GameObject deployLocation;

    private void Awake()
    {
        if (GameMaster.instance.getCar()==null)
        {
            print("HELLOOOOOOOOOOOOOOOO");
            Instantiate(car, new Vector3(-818, 126), Quaternion.identity);
        } 
        else 
        {

            Instantiate(GameMaster.instance.getCar(), new Vector3(-818, 126), Quaternion.identity);
            print("hello");
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
