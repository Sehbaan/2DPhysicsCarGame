using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour {

    LevelSaveData levelSave;
    GameMaster gameSave;

    GameObject switchLevel;


    //public bool[] isBought;
    public Button[] buyButtons;
    //public bool[] isSelected;
    public GameObject[] mapPanel;

    public Text myScore;

    private void Awake()
    {
        levelSave = LevelSaveData.instance;
        print(levelSave.cost[1]);
        gameSave = GameMaster.instance;
    }

    private void Start()
    {
        switchLevel = GameObject.FindGameObjectWithTag("switch");
    }

    private void OnLevelWasLoaded()
    {
        for (int i = 0; i < levelSave.isBought.Length; i++)
        {
            if(levelSave.isBought[i])
            {
                buyButtons[i].GetComponentInChildren<Text>().text = "SELECT MAP";
            }
            if(levelSave.getCurrentIndex() == i)
            {
                buyButtons[i].GetComponentInChildren<Text>().text = "MAP SELECTED";
                ChangeScrollablePic(levelSave.getCurrentIndex());
                print(levelSave.getCurrentIndex());
            }
        }
    }

    void Update()
    {
        myScore.text = gameSave.GetScore().ToString() + " COINS";
    }


    public void BuyCarButton(int index)
    {
        print(index);
        if(!levelSave.isBought[index])
        {


            if(levelSave.cost[index]<=gameSave.GetScore())
            {
                buyButtons[index].GetComponentInChildren<Text>().text = "SELECT MAP";
                gameSave.DecrementScore(levelSave.cost[index]);
                levelSave.isBought[index] = true;
            }
            else
            {
                print("not enough money");
            }

        } 
        else {
            for (int i = 0; i < levelSave.isBought.Length;i++)
            {
                if(levelSave.isBought[i] && i!=index){
                    buyButtons[i].GetComponentInChildren<Text>().text = "SELECT MAP";
                }
            }
            levelSave.setCurrentIndex(index);
            buyButtons[index].GetComponentInChildren<Text>().text = "MAP SELECTED";
        }
    }

    public void ChangeScrollablePic(int panelIndex)
    {

         for (int i = 0; i < mapPanel.Length;i++)
         {
             if(levelSave.isSelected[i] && i!=panelIndex)
             {
                 levelSave.isSelected[i] = false;
                 mapPanel[i].SetActive(false);
             }
         }
         mapPanel[panelIndex].SetActive(true);
         levelSave.isSelected[panelIndex] = true;
            
    }

    public void GoBack()
    {
        switchLevel.GetComponent<LevelChanger>().LevelToFade(4);
    }
}
