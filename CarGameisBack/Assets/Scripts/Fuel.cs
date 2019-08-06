using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour {

    public Image fuelBarImage;
    public float amountToAdd;
    private float startFuel;
    public float fuel;
    public GameObject gameController;

	// Use this for initialization
	void Start () {
        startFuel = fuel;
        gameController = GameObject.FindWithTag("GameMaster");
        InvokeRepeating("RemainingFuel", 0.2f,0.2f); // every second it'll decrease the fuel
	}

    void RemainingFuel()
    {

        fuel--;
        fuelBarImage.fillAmount = fuel/startFuel; // so we get a percentage of how much the bar should be filled
        if(fuel<=0){
            endGame();
        }
    }

    public void addFuel()
    {
        fuel += amountToAdd;
        if(fuel>100)
        {
            fuel = 100;
        }
        //fuelBarImage.fillAmount = fuel / startFuel;
    }

    void endGame()
    {
        print("you lose and pop up some window or some shiz");
        gameController.GetComponent<GameOver>().endGame();
        CancelInvoke();
        return;
    }
}
