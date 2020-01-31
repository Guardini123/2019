using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound_controller : MonoBehaviour {
    public Toggle _toggle;
	// Use this for initialization
	void Start () {
        if(PlayerPrefs.GetInt("sound_was_enabled") == 0)
        {
            PlayerPrefs.SetInt("enable_sound", 1);
            PlayerPrefs.SetInt("sound_was_enabled", 1);
        }
        if (PlayerPrefs.GetInt("enable_sound") == 1)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(_toggle.isOn)
        {
            PlayerPrefs.SetInt("enable_sound", 1);
            AudioListener.volume = 1;
        } else {
            PlayerPrefs.SetInt("enable_sound", 0);
            AudioListener.volume = 0;
        }
        //PlayerPrefs.Save();
    }
}
