using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsUI : MonoBehaviour {

    private int score = 0;
    public Text ScoreText;
    //public Text AccumulatedScore;
    GameMaster save;

    private void Start()
    {
        save = GameMaster.instance;
    }

    private void Update()
    {
        ScoreText.text =  save.GetScore().ToString();
    }



}
