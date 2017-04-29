using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRing : MonoBehaviour {

    bool spin = false;

    public AudioClip clarity_cut;

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
        if (spin)
        {
            transform.Rotate(new Vector3(0, 0, 96) * Time.deltaTime);
            
        }
        
      }

    void toggle()
    {
        spin = !spin;
        if (spin)
        {
            source.Play();
        }
        else
        {
            source.Pause();
        }
    }

}
