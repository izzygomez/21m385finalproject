using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTrigger : MonoBehaviour {

    public GameObject ring4;
    public GameObject ring8;
    public GameObject ring16;
    public string message;
    public GameObject warp_drive;

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
            ring4.GetComponent<RotatingRingNoAudio>().SendMessage(message);
            ring8.GetComponent<RotatingRing>().SendMessage(message);
            ring16.GetComponent<RotatingRingNoAudio>().SendMessage(message);
            if (message == "toggleOn")
            {
                warp_drive.SetActive(true);
            }
            if (message == "toggleOff")
            {
                warp_drive.SetActive(false);
            }
        }
    }
}
