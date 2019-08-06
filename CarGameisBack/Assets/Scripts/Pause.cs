using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public GameObject pausePanel;
    private GameObject loadLevel;
    // Use this for initialization
    void Start () {
        loadLevel = GameObject.FindGameObjectWithTag("switch");
    }

    public void PauseGame()
    {

        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Time.timeScale = 1;
        loadLevel.GetComponent<LevelChanger>().LevelToFade(4);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
