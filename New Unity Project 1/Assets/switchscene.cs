using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchscene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
       
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Change scene"))
        {
            transform.position = new Vector3 (200f,0f,0f);
        }

  
    }
}