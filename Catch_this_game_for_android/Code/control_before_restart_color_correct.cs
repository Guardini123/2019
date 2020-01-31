using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control_before_restart_color_correct : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("enable_color_correct") == 1)
        {
            this.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            this.GetComponent<Toggle>().isOn = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
