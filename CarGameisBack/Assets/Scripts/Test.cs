using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public static void main(string[] args)
    {

    }
	// Use this for initialization
	void Hello()
    {
        try
        {
            string hello = "sehbaan";
        }
        catch (FileNotFoundException e)
        {
            print("hello");
        }
    }
}
