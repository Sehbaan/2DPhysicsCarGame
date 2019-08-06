﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour {


    public GameObject newFront;

    public GameObject frontOfCar;
    public GameObject flag;

    private float math;
    private float distance;
    private float percentage;

    public GameObject startOfBar;
    public GameObject endOfBar;
    public GameObject pointer;

    public GameObject startPosText;
    public GameObject endPosText;
    public Text movingDistance;

    private GameObject gameMaster;

    // Use this for initialization
    void Start () {

        newFront = GameObject.FindGameObjectWithTag("Front");
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster");
        flag = GameObject.FindGameObjectWithTag("Flag");
        math = 500 / (newFront.transform.position - flag.transform.position).sqrMagnitude;
    }

    // Update is called once per frame
    void FixedUpdate () {
        //print((500/(frontOfCar.transform.position - flag.transform.position).sqrMagnitude));
        //print("whats the difference?? " + math);
        CalculateDistance();
        GetDistancePercentage();
        MoveUIpointer();
    }

    void CalculateDistance()
    {
        distance = Mathf.RoundToInt((((newFront.transform.position - flag.transform.position).sqrMagnitude*math) - 500) * -1); // Continuously fetches us acc distance
        //print(distance);
        gameMaster.GetComponent<DistanceUI>().UpdateDistanceText(distance);

    }

    public float GetDistance()
    {
        return distance;
    }

    void GetDistancePercentage()
    {
        percentage = (distance / 500);
    }

    void MoveUIpointer(){
        pointer.transform.position = Vector3.Lerp(startOfBar.transform.position, endOfBar.transform.position, percentage);
        movingDistance.transform.position = Vector3.Lerp(startPosText.transform.position, endPosText.transform.position, percentage);
    }
}
