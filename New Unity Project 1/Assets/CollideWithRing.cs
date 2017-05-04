using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class CollideWithRing : MonoBehaviour {

    public GameObject snap;
    bool snapped;

    void OnCollisionEnter(Collision coll)
    {
# Debug.Log("SoundObject Collided with " + coll.gameObject.name);
        if (coll.gameObject.tag == "SoundRing" &&
            !this.GetComponent<InitDuplicate>().currentlyPickedUpByController)
        {
            this.gameObject.transform.SetParent(coll.gameObject.transform);
            this.GetComponent<Rigidbody>().isKinematic = false;
          

        } else if (coll.gameObject.tag == "Ground" &&
         !this.GetComponent<InitDuplicate>().currentlyPickedUpByController)
        {
            this.gameObject.transform.SetParent(coll.gameObject.transform);
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void OnCollisionExit(Collision coll)
    {
# Debug.Log("SoundObject unCollided with " + coll.gameObject.name);
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
		
	}
}
