using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class CollideWithRing : MonoBehaviour {

    private float startTime;
    private bool hasParent = false;

    void OnCollisionEnter(Collision coll)
    {
        
        if (coll.gameObject.tag == "SoundRing" &&
            !this.GetComponent<InitDuplicate>().currentlyPickedUpByController)
        {
            this.gameObject.transform.SetParent(coll.gameObject.transform);
            this.GetComponent<Rigidbody>().isKinematic = false;
            hasParent = true;

        } else if (coll.gameObject.tag == "Ground" &&
         !this.GetComponent<InitDuplicate>().currentlyPickedUpByController)
        {
            startTime = Time.time;
            hasParent = true;
            this.gameObject.transform.SetParent(coll.gameObject.transform);
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void OnCollisionExit(Collision coll)
    {
        startTime = Time.time; // HACK to make this cube not get destroyed when letting it go after 10s
        if (coll.gameObject.tag == "SoundRing" && !this.GetComponent<InitDuplicate>().currentlyPickedUpByController)
        {
            // this.gameObject.transform.SetParent(null);
            //this.GetComponent<Rigidbody>().isKinematic = false; ???
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // If the cube has been on the groun for more than 5 seconds, let it fall into the abyss >:)
        if (hasParent && Time.time - startTime >= 5.0 && this.gameObject.transform.parent.gameObject.tag=="Ground")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            if (Time.time - startTime >= 12.0)
            {
                // ...and then kill it to save our precious CPU 
                Destroy(gameObject);
            }
        } 
    }
}
