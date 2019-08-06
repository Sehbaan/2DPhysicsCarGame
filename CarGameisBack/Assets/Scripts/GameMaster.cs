using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster instance;
    public int score = 0;
    public bool isDead;

    private GameObject SelectedCar;
    public bool[] isBought;
    public bool[] isSelected;
    public int[] cost;
    private int currentIndex = -1;

    // Use this for initialization
    void Awake() // happens before start
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this; // this will become the one object that will be referenced by this variable
        }
        else if (instance != this) // if control does exist and this is not it
        {
            Destroy(gameObject); // destroy this game object so we only have reference to the last
        }
    }

    public void Start()
    {
        //isSelected[0] = true;
    }

    public void DecrementScore(int coinValue)
    {
        score -= coinValue;
    }

    public void IncrementScore(int coinValue)
    {
        score += coinValue;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetCar(GameObject car)
    {
        SelectedCar = car;
        print("called");
    }

    public GameObject getCar()
    {
        print(SelectedCar);
        return SelectedCar;
    }

    public void setCurrentIndex(int num)
    {
        currentIndex = num;
    }

    public int getCurrentIndex()
    {
        return currentIndex;
    }
}
