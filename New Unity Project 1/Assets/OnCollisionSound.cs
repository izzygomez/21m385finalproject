using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSound : MonoBehaviour {
    public float startTime;
    private AudioSource source;
    private float duration;
    public bool collided;
    private float default_volume;
    public GameObject ps;

    public RotatingRing RR_script;
    public InitDuplicate ID_script;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        duration = 1.875f;
        default_volume = 1;
    }

    public float getDuration ()
    {
        return duration;
    }

    public void setDuration (float d)
    {
        duration = d;
    }

    public float getVolume ()
    {
        return default_volume;
    }

    public void setVolume (float v)
    {
        // make sure to bound volume between 0 and 1
        default_volume = Mathf.Min(1, Mathf.Max(v, 0));
    }

    void OnTriggerEnter(Collider coll)
    {
        // Always play sound object when it collides with nowba
        if (coll.gameObject.tag == "NowBar") {
            Play();
        }

        // play sound when hit w controller only if 
        // (a) rings aren't spinning or (b) item is on spawn plane
        if (coll.gameObject.tag == "Controller")
        {
            if (!RR_script.spinning || !ID_script.hasBeenPickedUp)
            {
                Play();
            }
        }
    }

    void Play()
    {
        collided = true;
        source.volume = default_volume;
        source.Play();
        ps.SendMessage("Play");
        startTime = Time.time;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(.794f, .794f, .794f, 1.0f));
    }
 

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (Time.time - startTime >= duration && collided)
        {
            ps.SendMessage("Stop");
            collided = false;
            source.Stop();
            GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(.5f, .5f, .5f, .5f));
            source.volume = default_volume;
        }
        // Do we actually need this?
        /**
        if (duration > 4)
        {
            if (Time.time - startTime >= duration * 0.7f && collided)
            {
                Debug.Log(Time.time - startTime);
                Debug.Log(duration);
                source.volume = (duration - (Time.time - startTime)) * 0.3f;
            }
        }
        if (duration <= 4)
        {
            if (Time.time - startTime >= duration * 0.6f && collided)
            {
                Debug.Log(Time.time - startTime);
                Debug.Log(duration);
                source.volume = (duration - (Time.time - startTime)) * 0.8f;
            }
        }**/
        
    }
}
