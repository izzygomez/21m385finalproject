using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class PickupParent : MonoBehaviour {

    SteamVR_TrackedObject trackedObj;
    bool holdingObject = false;

	void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>(); 
	}

    void OnTriggerStay (Collider coll)
    {
        //Debug.Log("   You have collided with " + coll.name + " and activated OnTriggerStay.");
        
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);

        // Grabbing an object
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && coll.gameObject.tag == "SoundObject" && !this.holdingObject)
        {
            Debug.Log("grabbing");
            // Logic so that we only hold one object at a time
            this.holdingObject = true;
            coll.gameObject.GetComponent<InitDuplicate>().currentlyPickedUpByController = true;

            // Debug.Log("You have collided with " + coll.name + " while holding down touch.");
            // Check if duplication should happen
            if (!coll.gameObject.GetComponent<InitDuplicate>().pickedUp)
            {
                coll.gameObject.GetComponent<InitDuplicate>().Duplicate();
            }
            coll.attachedRigidbody.isKinematic = true;
            coll.gameObject.transform.SetParent(this.gameObject.transform);
        }

        // Letting go of an object on TriggerUp
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger) && coll.gameObject.tag == "SoundObject" && this.holdingObject)
        // if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("dropping "+this.holdingObject);
            this.holdingObject = false;
            coll.gameObject.GetComponent<InitDuplicate>().currentlyPickedUpByController = false;
            // Debug.Log("You have released Touch while colliding with " + coll.name);
            coll.gameObject.transform.SetParent(null);
            coll.attachedRigidbody.isKinematic = false;
        }
    }
    /**
    void OnTriggerExit(Collider coll)
    {
   
            Debug.Log("ontriggerexit " + this.holdingObject);
            this.holdingObject = false;
            // Debug.Log("You have released Touch while colliding with " + coll.name);
           
 
    }**/
}
