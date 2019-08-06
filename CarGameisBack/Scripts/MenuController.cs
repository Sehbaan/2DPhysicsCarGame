using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    // Use this for initialization
    public GameObject upgradePanel;
    public GameObject menuPanel;
    private LevelSaveData save;
    private GameObject loadLevel;
    void Start () {
        loadLevel = GameObject.FindGameObjectWithTag("switch");
        save = LevelSaveData.instance;
	}

    public void NavigateToUpgrade()
    {
        menuPanel.SetActive(false);
        upgradePanel.SetActive(true);
    }

    public void PlayGame()
    {
        if(LevelSaveData.instance!=null){
            loadLevel.GetComponent<LevelChanger>().LevelToFade(save.getCurrentIndex());
        } else {
            loadLevel.GetComponent<LevelChanger>().LevelToFade(0);
        }

    }

    public void LevelScreen()
    {
        loadLevel.GetComponent<LevelChanger>().LevelToFade(2);
    }
}
