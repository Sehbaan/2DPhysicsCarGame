using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirTimeUI : MonoBehaviour {

    // Use this for initialization
    public GameObject airTimeText;
	public void EnableAirTime(int currentAirPoints)
    {   
        airTimeText.gameObject.SetActive(true);
        airTimeText.GetComponentInChildren<Text>().text = "AIRTIME " + Environment.NewLine + currentAirPoints;
    }

    public void DisabelAirTime()
    {
        airTimeText.gameObject.SetActive(false);
    }
}
