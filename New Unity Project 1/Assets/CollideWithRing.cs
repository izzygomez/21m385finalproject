using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(SteamVR_TrackedObject))]

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
        //Debug.Log("SoundObject unCollided with " + coll.gameObject.name);
        if (coll.gameObject.tag == "SoundRing" &&
            !this.GetComponent<InitDuplicate>().currentlyPickedUpByController)
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
        if (hasParent && Time.time - startTime >= 10.0 && this.gameObject.transform.parent.gameObject.tag=="Ground")
        {
            Destroy(gameObject);
        } 
    }
}
