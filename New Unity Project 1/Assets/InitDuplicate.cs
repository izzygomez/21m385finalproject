using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class InitDuplicate : MonoBehaviour {

    public bool hasBeenPickedUp = false;
    public bool currentlyPickedUpByController = false;
    private Vector3 location;
    
    // Use this for initialization
    void Start() {
        location = this.transform.position;
    }

    public void Duplicate()
    {
        Instantiate(this, location, transform.rotation);
        this.hasBeenPickedUp = true;
        // now that this cube has been picked up for the first time, turn off all constraints
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
