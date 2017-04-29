using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSound : MonoBehaviour {
    public AudioClip glass;

    private AudioSource source;
    private float velToVol = 0.2F;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider coll)
    {
        source.pitch = 0.75F;
        
        if (coll.gameObject.tag == "NowBar")
        {
            StartCoroutine(playSound());

        }
    }
    /**
    void OnCollisionEnter(Collision coll)
    {
        Debug.Log("OnCollisionEnter entered.");
        Transform tf = gameObject.GetComponent<Transform>();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = false;
        tf.SetParent(coll.collider.gameObject.GetComponent<Transform>());
            
    }**/

	// Use this for initialization
	void Start () {
    }
    
    IEnumerator playSound()  
    {
        source.Play();
        // TODO figure out if we need this 
        yield return new WaitForSeconds(2);
        // source.Stop();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
