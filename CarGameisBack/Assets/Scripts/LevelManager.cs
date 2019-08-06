using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {


    public Button[] LevelSelectButton;

	// Use this for initialization
	void Start () 
    {
        int levelReached = PlayerPrefs.GetInt("levelReached",1);

        for (int i = 0; i < LevelSelectButton.Length;i++)
        {
            LevelSelectButton[2].interactable = true;
            if (i+1>levelReached)
            {
                LevelSelectButton[i].interactable = false;
            }
        }
	}

	// Update is called once per frame
	void Update () {
		
	}
}
