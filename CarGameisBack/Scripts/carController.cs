using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// enables car to move
public class carController : MonoBehaviour
{
    private GameObject gameMaster;
    private GameMaster save;

    public GameObject levelCompletePanel;

    public int coinValue = 100;
    //public CoinsUI coinsUI;
    public GameObject coinPrefab;
    public GameObject coinGoTo;
    private int levelCoins;

    public float frontSpeed = 1500; // can change this
    public float backSpeed = 1500; // can change this
    public float rotationSpeed = 15f;
    public float testRotation = 100f;

    public WheelJoint2D bWheel;
    public WheelJoint2D fWheel;
    private float move;
    private float rotate;

    public GameObject frontOfCar;

    public GameObject FfirePoint;
    public GameObject BfirePoint;
    public LayerMask detectionLayer;
    bool Ftouching = false;
    bool Btouching = false;

    bool inAir = false;
    private bool gameEnded = false;
    float seconds = 0;
    float timer = 0;
    public int accumulatedAirPoints = 0;
    public float accumulatedAirTime = 0;
    private int currentAirPoints = 0;



    private void Start()
    {
        //detectionLayer = 1 << 9; // pushes all the way to 9th bit so 0000...1 0000 000
        //detectionLayer = LayerMask.NameToLayer("Map");
        levelCoins = 0;
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster");
        gameMaster.GetComponent<Distance>().setFrontOfCar(frontOfCar);
        save = GameMaster.instance;
        levelCompletePanel = GameObject.FindGameObjectWithTag("LevelCompletePanel");
        levelCompletePanel.SetActive(false);
        //InvokeRepeating("RegisterFlip",0.5f,0.5f);
    }

    void OnLevelWasLoaded(int level)
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster");
        save = GameMaster.instance;
        //gameMaster.GetComponent<CoinsUI>().updateCoins(save.GetScore());
    }

    // Update is called once per frame
    void Update()
    {
        move = -Input.GetAxis("Vertical"); // on movement of up key we move at speed specified, keeps moving back hence the -1
        rotate = -Input.GetAxis("Horizontal"); // side keys
        AirTime();
        RegisterAirTime();
    }

    // anything to do with physics goes inside fixedUpdate
    void FixedUpdate()
    {

        // controls movement of wheels using rigid body motor
        if (move < 0)
        {
            fWheel.useMotor = true;
            bWheel.useMotor = true;
            JointMotor2D backControlMotor = new JointMotor2D { motorSpeed = move * backSpeed, maxMotorTorque = 1000 }; // sets to value inside already
            JointMotor2D frontControlMotor = new JointMotor2D { motorSpeed = move * frontSpeed, maxMotorTorque = 1000 };
            bWheel.motor = backControlMotor;
            fWheel.motor = frontControlMotor;
        }
        else if (move > 0) // going backwards
        {
            fWheel.useMotor = true;
            bWheel.useMotor = true;
            JointMotor2D backControlMotor = new JointMotor2D { motorSpeed = move * backSpeed, maxMotorTorque = 1000 }; // sets to value inside already
            JointMotor2D frontControlMotor = new JointMotor2D { motorSpeed = move * frontSpeed, maxMotorTorque = 1000 };
            bWheel.motor = backControlMotor;
            fWheel.motor = frontControlMotor;
        }
        else
        { // not pressing up or down
            bWheel.useMotor = false;
            fWheel.useMotor = false;
        }

        if (rotate < 0)
        {
            GetComponent<Rigidbody2D>().AddTorque(rotate * rotationSpeed); // this affecting the acc body of this
        }
        else
        {
            GetComponent<Rigidbody2D>().AddTorque(rotate * rotationSpeed);
        }
    }

    void AirTime()
    {

        if (!Btouching && !Ftouching && !GameOver.isTouching && !inAir)
        {
            timer = timer + Time.deltaTime;
            seconds = timer % 60;
            //print("accumulated time: "+ accumulatedAirTime);
            //print("seconds " + seconds);
        }
        else
        {
            accumulatedAirTime += seconds;
            seconds = 0;
            timer = 0;
            currentAirPoints = 0;
        }

        if (seconds > 1.3)
        {
            print(currentAirPoints);

            accumulatedAirPoints += 5;
            currentAirPoints += 5;

            gameMaster.GetComponent<AirTimeUI>().EnableAirTime(currentAirPoints);

            save.IncrementScore(5);
        }
        else
        {
            gameMaster.GetComponent<AirTimeUI>().DisabelAirTime();
        }

    }

    void OnTriggerEnter2D(Collider2D other) // maybe put this into a coins 
    {
        if (other.gameObject.tag == "Coin") // if coin collides with player set coin as inactive
        {
            save.IncrementScore(coinValue);
            //iTween.MoveTo(other.gameObject, iTween.Hash("position", coinGoTo.transform.position, "time", 2.5f, "easetype", iTween.EaseType.easeInOutQuad));
            other.gameObject.SetActive(false);
            levelCoins += coinValue;
            print("level coins " + levelCoins);
            gameMaster.GetComponent<GameOver>().UpdateLevelScore(levelCoins);
        }

        if (other.gameObject.tag == "Fuel")
        {
            gameMaster.GetComponent<Fuel>().addFuel();
            other.gameObject.SetActive(false);
            gameMaster.gameObject.GetComponent<GameOver>().AirTimeUI(Mathf.RoundToInt(accumulatedAirTime), accumulatedAirPoints);
        }

        if (other.gameObject.tag == "Flag")
        {
            PlayerPrefs.SetInt("levelReached", 2);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            print("SECOND TIME LUCKY??");
            levelCompletePanel.GetComponent<LevelCompleteUI>().PrintSeconds();
            levelCompletePanel.GetComponent<LevelCompleteUI>().PrintAirPoints();
            levelCompletePanel.GetComponent<LevelCompleteUI>().PrintlevelPoints();
            this.gameObject.SetActive(false);
            levelCompletePanel.gameObject.SetActive(true);
            gameEnded = true;
        }
        if (other.gameObject.tag == "fire")
        {
            if (!gameEnded)
            {
                gameMaster.gameObject.GetComponent<GameOver>().endGame();
                gameMaster.gameObject.GetComponent<GameOver>().AirTimeUI(Mathf.RoundToInt(accumulatedAirTime), accumulatedAirPoints);
                Destroy(other.gameObject);
            }
        }

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Map")
        {
            inAir = false;
        }
        inAir = true;
    }

    void RegisterAirTime()
    {
        RaycastHit2D backWheelHit = Physics2D.Raycast(BfirePoint.transform.position, BfirePoint.transform.forward * 9, 10, detectionLayer);
        RaycastHit2D frontWheelHit = Physics2D.Raycast(FfirePoint.transform.position, FfirePoint.transform.forward * 9, 10, detectionLayer);

        if (frontWheelHit)
        {
            if (frontWheelHit.collider.CompareTag("Map"))
            {
                Ftouching = true;
                print("touching front");
            }
        }
        else
        {
            Ftouching = false;
        }
        Debug.DrawRay(FfirePoint.transform.position, FfirePoint.transform.forward * 12, Color.red);

        if (backWheelHit)
        {
            if (backWheelHit.collider.CompareTag("Map"))
            {
                Btouching = true;
                print("touching back");
            }
        }
        else
        {
            Btouching = false;
            print("NOT touching back");
        }
        Debug.DrawRay(BfirePoint.transform.position, BfirePoint.transform.forward * 12, Color.red, 10);
    }

    public int getLevelCoins()
    {
        return levelCoins;
    }

    public bool hasEnded()
    {
        return gameEnded;
    }

}