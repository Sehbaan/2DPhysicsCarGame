using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedOmetre : MonoBehaviour {

    private float velocity;
    private float fraction;

    public float minAngle = (float)74.7;
    public float maxAngle = (float)-161.2;

    private GameObject save;
    private GameObject car;

    // Use this for initialization
    void Start () {
        //pointer.transform.rotation = rotation;
        car = GameObject.FindGameObjectWithTag("CarTag");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        CalculateVelocity();
        MovePointer();
    }

    void CalculateVelocity()
    {
        velocity = car.transform.GetComponent<Rigidbody2D>().velocity.sqrMagnitude;
        //print(velocity);
        if (velocity > 48000)
        {
            velocity = 48000;
        }
        fraction = velocity / 48000;
    }

    void MovePointer()
    {
        float angle = Mathf.Lerp(minAngle, maxAngle, fraction);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
