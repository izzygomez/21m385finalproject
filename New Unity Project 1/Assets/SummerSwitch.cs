﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerSwitch : MonoBehaviour {

    public GameObject camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "ToggleTrigger")
        {
            camera.transform.position = new Vector3(200f, 0f, 0f);
        }
    }
}
