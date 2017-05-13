using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticles : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Play()
    {
        var exp = GetComponent<ParticleSystem>();
        exp.Play();
    }

    void Stop()
    {
        var exp = GetComponent<ParticleSystem>();
        exp.Stop();
    }
}
