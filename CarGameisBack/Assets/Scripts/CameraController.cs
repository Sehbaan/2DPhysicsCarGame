using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player; // target of camera
    //private Vector3 offset;
    public Vector3 offset;

    public bool boundaries;

    public Vector3 minCamPos;
    public Vector3 maxCamPos;

    void Start () {
        player = GameObject.FindGameObjectWithTag("CarTag");

        offset = transform.position; // takes cameras position
	}

    // Update is called once per frame
    void LateUpdate () // appropriate place for follow cameras procedural animations and gathering last known states
    { 
        transform.position = player.transform.position + offset; // assign camera to players position and then add an offset so we go a little higher, where the camera originally was
        //if (boundaries)
        //{
        //    transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x), Mathf.Clamp(transform.position.y, minCamPos.y, maxCamPos.y),
        //        Mathf.Clamp(transform.position.y, minCamPos.y, maxCamPos.y));
        //}
    }
}
