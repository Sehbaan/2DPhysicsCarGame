using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireBall : MonoBehaviour {

    public GameObject[] fireBall;
    public GameObject[] fireballPos;
    public GameObject fireBallPos;
    int index = 0;
    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", 3.0f, 3.0f);
    }

    public void Spawn()
    {
        GameObject instance = Instantiate(fireBall[index],fireballPos[index].transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));

        if(index == fireBall.Length-1)
        {
            index = 0;
        }
        index++;
        StartCoroutine("Delay", instance);
    }

    public IEnumerator Delay(GameObject instance)
    {
        yield return new WaitForSeconds(13f);
        Destroy(instance);
    }
}
