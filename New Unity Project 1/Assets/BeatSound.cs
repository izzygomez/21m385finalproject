using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSound : MonoBehaviour {

    public float volume;
    private float v_step_size = 0.05f;
    private int MAX_VOLUME = 1;
    private int MIN_VOLUME = 0;

    public OnCollisionSound script;
    public GameObject sphere;
    public float hue;

    // Use this for initialization
    void Start()
    {
        volume = script.getVolume();
        script.setDuration(0.46875f);
    }


    public void incrementVolume()
    {

        volume = Mathf.Min(MAX_VOLUME, volume + v_step_size);
        // TODO change alpha

        Color new_color = Color.HSVToRGB(hue, volume * 0.8f + .2f, 1f);

        sphere.GetComponent<Renderer>().material.SetColor("_Color", new_color);
        script.setVolume(volume);
    }

    public void decrementVolume()
    {

        volume = Mathf.Max(MIN_VOLUME, volume - v_step_size);
        Color new_color = Color.HSVToRGB(hue, volume * 0.8f + .2f, 1f);
        sphere.GetComponent<Renderer>().material.SetColor("_Color", new_color);
        script.setVolume(volume);
    }

    public float getVolume()
    {
        return volume;
    }

    // Update is called once per frame
    void Update()
    {
    }

  
}
