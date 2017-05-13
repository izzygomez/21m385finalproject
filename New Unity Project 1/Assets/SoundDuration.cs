using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundDuration : MonoBehaviour {

    public float duration;
    public float volume;
    private float d_step_size = 0.46875f;
    private float v_step_size = 0.05f;
    private int MAX_DURATION = 16;
    private int MIN_DURATION = 1;
    private int MAX_VOLUME = 1;
    private int MIN_VOLUME = 0;

    public Sprite beat_1;
    public Sprite beat_2;
    public Sprite beat_3;
    public Sprite beat_4;
    public Sprite beat_5;
    public Sprite beat_6;
    public Sprite beat_7;
    public Sprite beat_8;
    public Sprite beat_9;
    public Sprite beat_10;
    public Sprite beat_11;
    public Sprite beat_12;
    public Sprite beat_13;
    public Sprite beat_14;
    public Sprite beat_15;
    public Sprite beat_16;
    public Sprite[] beats;

    private Text duration_text;
    private Image note_image;
    public OnCollisionSound script;
    public float hue;

	// Use this for initialization
	void Start () {
        beats = new Sprite[16] { beat_1, beat_2, beat_3, beat_4, beat_5, beat_6, beat_7, beat_8, beat_9, beat_10, beat_11, beat_12, beat_13, beat_14, beat_15, beat_16 };
        note_image = GetComponentInChildren<Canvas>().GetComponentInChildren<Image>();
        duration = script.getDuration();
        volume = script.getVolume();
        note_image.GetComponent<Image>().sprite = getNewSprite((int) (duration / d_step_size));
    }

    public void incrementDuration ()
    {
        duration = Mathf.Min(MAX_DURATION*d_step_size, duration + d_step_size);
        note_image.GetComponent<Image>().sprite = getNewSprite((int) (duration / d_step_size));

        script.setDuration(duration);
    }

    public void decrementDuration()
    {
        duration = Mathf.Max(MIN_DURATION*d_step_size, duration - d_step_size);
        note_image.GetComponent<Image>().sprite = getNewSprite((int)(duration / d_step_size));

        script.setDuration(duration);
    }

    public void incrementVolume ()
    {

        volume = Mathf.Min(MAX_VOLUME, volume + v_step_size);
        // TODO change alpha
    
        Color new_color = Color.HSVToRGB(hue,volume*0.8f+.2f,1f);
  
    

        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color",new_color);
        script.setVolume(volume);
    }

    public void decrementVolume ()
    {

        volume = Mathf.Max(MIN_VOLUME, volume - v_step_size);
        Color new_color = Color.HSVToRGB(hue, volume * 0.8f + .2f, 1f);
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", new_color);
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

    Sprite getNewSprite(int sprite_number)
    {
        int i = Mathf.Max(Mathf.Min(MAX_DURATION, sprite_number), MIN_DURATION);
        return beats[i-1];
    }
}
