using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;
    public int levelIndex;

	// Use this for initialization
	void Start () {
		
	}

    public void LevelToFade(int level)
    {
        animator.SetTrigger("fadeout");
        levelIndex = level;
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelIndex);
    }
}
