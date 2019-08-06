using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelCompleteUI : MonoBehaviour {

    private carController car;
    public Text secondsText;
    public Text airPointsText;
    public Text levelPointsText;

    private GameObject loadLevel;

    // Use this for initialization
    void Start () {
       // car = GameObject.FindGameObjectWithTag("CarTag").GetComponent<carController>();
        loadLevel = GameObject.FindGameObjectWithTag("switch");
    }
	
	public void PrintSeconds(int seconds)
    {
        print("YO");
        //print("accumulated air time " + Mathf.RoundToInt(car.accumulatedAirTime).ToString());
        secondsText.text = seconds.ToString() + " seconds";
    }

    public void PrintAirPoints(int airPoints)
    {
        airPointsText.text = "+ " + airPoints.ToString() + " Coins";
    }

    public void PrintlevelPoints(int levelCoins)
    {
        levelPointsText.text = "+ " +  levelCoins + " Coins";
    }

    public void nextScreen()
    {
        PlayerPrefs.SetInt("levelReached", 2);
        loadLevel.GetComponent<LevelChanger>().LevelToFade(4);
    }

}
