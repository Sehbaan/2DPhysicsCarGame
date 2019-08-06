using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOver : MonoBehaviour {

    private bool collided;
    public GameObject gameOverCanvas;
    private GameObject gameMaster;
    private float finalDistance;
    public Text levelScoreText;

    public Text secondsText;
    public Text airPointsText;
    public Text airTimeText;

    public Text finalDistanceText;

    public carController car;

    public static bool isTouching;

    public GameObject ExplosionEffect;
    public AudioSource explosionSource;

    public void Start()
    {
        collided = false;
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster");
        car = GameObject.FindGameObjectWithTag("CarTag").GetComponent<carController>();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Head")
        {

            endGame();


            isTouching = true;
            gameMaster.GetComponent<AirTimeUI>().DisabelAirTime();
            Transform parent = other.gameObject.transform.parent;
            Instantiate(ExplosionEffect, other.gameObject.transform.position, Quaternion.identity);
            parent.gameObject.SetActive(false);

        }
    }

    public void AirTimeUI(int accAirTime, int accAirPoints)
    {
        airTimeText.text =  accAirTime.ToString() + " Seconds";
        airPointsText.text = " + " + accAirPoints.ToString() + " Coins";
    }

    public void UpdateLevelScore(int score)
    {
        if (!collided)
        {
            levelScoreText.text = "+ " + score + " COINS";
        }
    }

    public void NavigateToMenu()
    {
        SceneManager.LoadScene(4);
    }

    public void endGame()
    {
        //collided = true;
        finalDistance = gameMaster.GetComponent<Distance>().GetDistance();
        finalDistanceText.text = "Distance: " + finalDistance + "m";

        AirTimeUI(Mathf.RoundToInt(car.accumulatedAirTime),car.accumulatedAirPoints);

        Transform parent = GameObject.FindGameObjectWithTag("CarTag").transform;
        Instantiate(ExplosionEffect, parent.transform.position, Quaternion.identity);
        explosionSource.Play();
        parent.gameObject.SetActive(false);


        gameOverCanvas.SetActive(true);

    }
}
