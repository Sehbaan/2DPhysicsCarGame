using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceUI : MonoBehaviour {

    public Text DistanceText;
    public Text GameOverDistance;

    // Update is called once per frame
    public void UpdateDistanceText(float distance)
    {
        DistanceText.text = distance.ToString() + "m"; 
    }
}
