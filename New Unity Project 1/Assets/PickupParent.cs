using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class PickupParent : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
    bool holdingObject = false;
    public GameObject stationary_obj;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }


    void OnTriggerStay (Collider coll)
    {   
        device = SteamVR_Controller.Input((int)trackedObj.index);

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
        {
            Debug.Log("dropping "+this.holdingObject);
            this.holdingObject = false;
            coll.gameObject.GetComponent<InitDuplicate>().currentlyPickedUpByController = false;
            // Debug.Log("You have released Touch while colliding with " + coll.name);
            coll.gameObject.transform.SetParent(stationary_obj.transform);
            coll.attachedRigidbody.isKinematic = false;
        }

        // Changing duration of object
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && coll.gameObject.tag == "SoundObject" && this.holdingObject) {
            // Debug.Log("Pressed down the touchpad. x = " + device.GetAxis().x + ", y = " + device.GetAxis().y);
            float x = device.GetAxis().x;
            float y = device.GetAxis().y;

            // Check if volume is to be adjusted
            if (y > 0.7)
            {
                coll.gameObject.GetComponent<SoundDuration>().incrementVolume();
                return;
            }
            if (y < -0.7)
            {
                coll.gameObject.GetComponent<SoundDuration>().decrementVolume();
                return;
            }

            // Else, check if duration is to be adjusted
            if (x < 0)
            {
                coll.gameObject.GetComponent<SoundDuration>().decrementDuration();
            }
            if (x >= 0)
            {
                coll.gameObject.GetComponent<SoundDuration>().incrementDuration();
            }
        }
    }
}
