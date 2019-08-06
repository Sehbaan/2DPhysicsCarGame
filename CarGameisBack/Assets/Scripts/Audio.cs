using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    public AudioClip music;
    public AudioSource musicSource;
	// Use this for initialization
	void Start () {
        musicSource.clip = music;
        musicSource.Play();
    }
	
	// Update is called once per frame
	//void Update () {


	//}
}
