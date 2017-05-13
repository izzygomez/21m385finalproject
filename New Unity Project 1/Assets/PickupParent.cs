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
            // Logic so that we only hold one object at a time
            this.holdingObject = true;
            coll.gameObject.GetComponent<InitDuplicate>().currentlyPickedUpByController = true;

            // Check if duplication should happen
            if (!coll.gameObject.GetComponent<InitDuplicate>().hasBeenPickedUp)
            {
                coll.gameObject.GetComponent<InitDuplicate>().Duplicate();
            }

            // Logic to remove constraints (in case object was just on ring)
            coll.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            coll.attachedRigidbody.isKinematic = true;
            coll.gameObject.transform.SetParent(this.gameObject.transform);
        }

        // Letting go of an object on TriggerUp
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger) && coll.gameObject.tag == "SoundObject" && this.holdingObject)
        {
            // Debug.Log("dropping "+this.holdingObject);
            this.holdingObject = false;
            coll.gameObject.GetComponent<InitDuplicate>().currentlyPickedUpByController = false;
            // Debug.Log("You have released Touch while colliding with " + coll.name);
            coll.gameObject.transform.SetParent(stationary_obj.transform);
            coll.attachedRigidbody.isKinematic = false;
        }

        // Changing volume & duration of object
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && coll.gameObject.tag == "SoundObject" && this.holdingObject) {
            // Debug.Log("Pressed down the touchpad. x = " + device.GetAxis().x + ", y = " + device.GetAxis().y);
            float x = device.GetAxis().x;
            float y = device.GetAxis().y;

            // Check if volume is to be adjusted
            /** Do we still want to do this? How are we going to show volume control on the UI?
            if (y > 0.7)
            {
                coll.gameObject.GetComponent<SoundDuration>().incrementVolume();
                return;
            }
            if (y < -0.7)
            {
                coll.gameObject.GetComponent<SoundDuration>().decrementVolume();
                return;
            }**/

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
