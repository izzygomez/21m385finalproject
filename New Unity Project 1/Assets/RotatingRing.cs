using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRing : MonoBehaviour {

    bool spin = false;
    public GameObject snap;
    bool snapped = false; //dictionary of snaps? need one per...or put it into the cube itself??

    public AudioClip clarity_cut;

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {}
	
	// Update is called once per frame
	void Update () {
        if (spin) {
            transform.Rotate(new Vector3(0, 0, 96) * Time.deltaTime);
        }
      }

    void toggle() {
        spin = !spin;
        if (spin) {
            source.Play();
        } else {
            source.Pause();
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        Debug.Log("snap");
        float? mindist=null;
        Transform minChild=this.transform;

        if (coll.gameObject.tag == "SoundObject" && !snapped) {
            //coll.gameObject.transform.position = new Vector3(snap.transform.position.x,snap.transform.position.y+.25f, snap.transform.position.z);
            foreach (Transform child in transform) {
                if (child.tag == "Snap") {
                    float distance = Vector3.Distance(child.position, coll.gameObject.transform.position);
                    if (mindist == null || distance<mindist) {
                        mindist = distance;
                        minChild = child;
                    }
                }
            }
            coll.gameObject.transform.position = new Vector3(minChild.position.x, minChild.position.y + .05f, minChild.position.z);
            //Debug.Log("Current rotation: " + coll.gameObject.transform.rotation.ToString());
            coll.gameObject.transform.rotation =  minChild.rotation;
            snapped = true;
            StartCoroutine(debounce());
        }
    }

    IEnumerator debounce() {
        yield return new WaitForSeconds(.5f);
        snapped = false;
    }



}
