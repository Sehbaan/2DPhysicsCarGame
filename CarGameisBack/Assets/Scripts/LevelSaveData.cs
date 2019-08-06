using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSaveData : MonoBehaviour {

    [SerializeField]
    public bool[] isBought;
    public bool[] isSelected;
    public int[] cost;
    private int currentIndex = -1;

    public static LevelSaveData instance;
    // Use this for initialization

    private void Awake()
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
        isSelected[0] = true;
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
