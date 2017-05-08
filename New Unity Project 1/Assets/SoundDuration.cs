using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundDuration : MonoBehaviour {

    public float duration;
    public float volume;
    private float d_step_size = 0.25f;
    private float v_step_size = 0.05f;
    private int MAX_DURATION = 10;
    private int MIN_DURATION = 0;
    private int MAX_VOLUME = 1;
    private int MIN_VOLUME = 0;

    private Text duration_text;
    public OnCollisionSound script;

	// Use this for initialization
	void Start () {
        duration_text = GetComponentInChildren<Canvas>().GetComponentInChildren<Text>();
        duration = script.getDuration();
        volume = script.getVolume();
        duration_text.text = "Duration: " + Mathf.Round(script.getDuration() * 10) / 10
                                + "\nVolume: " + script.getVolume() ;
    }

    public void incrementDuration ()
    {
        duration = Mathf.Min(MAX_DURATION, duration + d_step_size);
        duration_text.text = "Duration: " + Mathf.Round(duration * 10) / 10 + "\nVolume: " + Mathf.Round(volume * 100) / 100;
        script.setDuration(duration);
    }

    public void decrementDuration()
    {
        duration = Mathf.Max(MIN_DURATION, duration - d_step_size);
        duration_text.text = "Duration: " + Mathf.Round(duration * 10) / 10 + "\nVolume: " + Mathf.Round(volume * 100) / 100;
        script.setDuration(duration);
    }

    public void incrementVolume ()
    {
        volume = Mathf.Min(MAX_VOLUME, volume + v_step_size);
        duration_text.text = "Duration: " + Mathf.Round(duration * 10) / 10 + "\nVolume: " + Mathf.Round(volume * 100) / 100;
        script.setVolume(volume);
    }

    public void decrementVolume ()
    {
        volume = Mathf.Max(MIN_VOLUME, volume - v_step_size);
        duration_text.text = "Duration: " + Mathf.Round(duration * 10) / 10 + "\nVolume: " + Mathf.Round(volume * 100) / 100;
        script.setVolume(volume);
    }

    public float getDuration()
    {
        return duration;
    }

    public float getVolume()
    {
        return volume;
    }

    // Update is called once per frame
    void Update () {
	}
}
