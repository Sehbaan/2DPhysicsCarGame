using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    public GameObject SelectedCar;
    private GameObject gameMaster;
    public GameObject levelCompletePanel;

    public void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("CarTag"))
        {
            //PlayerPrefs.SetInt("levelReached",2);
            print("IT DOESNT ???????");
            //print("HELLOOOOOOOOO " + PlayerPrefs.GetInt("levelReached"));
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            levelCompletePanel.gameObject.SetActive(true);
        }
    }
}