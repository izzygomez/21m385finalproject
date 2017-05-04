using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSound : MonoBehaviour {
    public AudioClip sound;
    public float startTime;
    private AudioSource source;
    private float velToVol = 0.2F;
    private float duration;
    public bool collided;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        sound = source.clip;
        duration = sound.length;
        Debug.Log(duration);
    }

    void OnTriggerEnter(Collider coll)
    {
        source.pitch = 1F;
        
        if (coll.gameObject.tag == "NowBar") {
            source.volume = 1;
            collided = true;
            startTime = Time.time;
            source.Play();

            GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(.794f, .794f, .794f, 1.0f));
            //StartCoroutine(playSound());
        }
    }
 
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "NowBar") {
            GetComponent<Renderer>().material.SetColor ("_EmissionColor", new Color(.5f, .5f, .5f, .5f));
        }

    }

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
        if (Time.time - startTime >= duration && collided)
        {
            collided = false;
        }
        if (Time.time - startTime >= duration * 0.7f && collided)
        {
            source.volume = (duration - (Time.time - startTime)) * 0.3f;
        }
    }
}
