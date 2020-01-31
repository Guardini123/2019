using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control_before_restart_sound : MonoBehaviour {
    public Toggle _tog;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("enable_sound") == 1)
        {
            _tog.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            _tog.GetComponent<Toggle>().isOn = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
