using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSound : MonoBehaviour {
    public AudioClip sound;
    private AudioSource source;
    private float velToVol = 0.2F;
    private float duration;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        sound = source.clip;
        duration = sound.length;
        Debug.Log(duration);
    }

    void OnTriggerEnter(Collider coll)
    {
        source.pitch = 0.75F;
        
        if (coll.gameObject.tag == "NowBar") {
            float startTime = Time.time;
            source.Play();
            Debug.Log(startTime);
            Debug.Log(Time.time);
            /*
            while (Time.time - startTime < duration)
            {
                if (Time.time - startTime >= duration * 0.8f)
                {
                    source.volume = (duration - Time.time) * 0.5f;
                }
            }
            */
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
		
	}
}
