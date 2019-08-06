using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    private GameObject gameMaster;

    public GameObject garagePanel;
    public GameObject menuPanel;

    GameMaster Save;

    public Button[] buyButtons;
    public GameObject[] cars;

    public GameObject[] carPanel;

    public Text myScore;

    private void Awake()
    {
        Save = GameMaster.instance;
    }

    private void Update()
    {
        myScore.text = Save.GetScore().ToString() + " COINS";
    }

    public void BuyCarButton(int index)
    {
        if (!Save.isBought[index])
        {
            if (Save.GetScore() >= Save.cost[index])
            {
                buyButtons[index].GetComponentInChildren<Text>().text = "SELECT CAR";
                Save.DecrementScore(Save.cost[index]); // decrease money
                Save.isBought[index] = true;
            } else {
                print("you dont have enough money");
            }
        }
        else if(Save.isBought[index])
        {
            for (int i = 0; i < Save.isBought.Length; i++)
            {
                if (Save.isBought[i] && i != index)
                {
                    buyButtons[i].GetComponentInChildren<Text>().text = "SELECT CAR";
                }
            }
            Save.setCurrentIndex(index);
            Save.SetCar(cars[index]); ////
            buyButtons[index].GetComponentInChildren<Text>().text = "SELECTED CAR";
        }
    }

    public void ChangeScrollablePic(int panelIndex)
    {

        for (int i = 0; i < carPanel.Length; i++)
        {
            if (Save.isSelected[i] && i != panelIndex)
            {
                Save.isSelected[i] = false;
                carPanel[i].SetActive(false);
            }
        }
        carPanel[panelIndex].SetActive(true);
        Save.isSelected[panelIndex] = true;

    }

    public void goBack()
    {
        garagePanel.SetActive(false);
        menuPanel.SetActive(true);
    }

}

