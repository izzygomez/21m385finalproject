using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRingNoAudio : MonoBehaviour
{

    bool spin = false;
    bool snapped = false;
    public float rpm;


    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (spin)
        {
            transform.Rotate(new Vector3(0, 0, rpm) * Time.deltaTime);
        }
    }

    void toggleOn()
    {
        spin = true;
    }

    void toggleOff()
    {
        spin = false;
    }

    void OnCollisionEnter(Collision coll)
    {
        Debug.Log("snap");
        float? mindist = null;
        Transform minChild = this.transform;

        if (coll.gameObject.tag == "SoundObject" && !snapped)
        {
            foreach (Transform child in transform)
            {
                if (child.tag == "Snap")
                {
                    float distance = Vector3.Distance(child.position, coll.gameObject.transform.position);
                    if (mindist == null || distance < mindist)
                    {
                        mindist = distance;
                        minChild = child;
                    }
                }
            }
            coll.gameObject.transform.position = new Vector3(minChild.position.x, minChild.position.y + .05f, minChild.position.z);
            coll.gameObject.transform.rotation = minChild.rotation;
            snapped = true;
            StartCoroutine(debounce());
        }
    }

    IEnumerator debounce()
    {
        yield return new WaitForSeconds(.5f);
        snapped = false;
    }



}
