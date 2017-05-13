using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnHover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Controller")
        {
            Debug.Log("controller hit");
            this.transform.parent.gameObject.SendMessage("Play");
        }
    }
}
