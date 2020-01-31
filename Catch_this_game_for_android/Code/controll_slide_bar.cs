using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controll_slide_bar : MonoBehaviour {
    private float _user_value;
	// Use this for initialization
	void Start () {
        this.GetComponent<Slider>().value = PlayerPrefs.GetFloat("user_ratio_ball_speed");
        _user_value = this.GetComponent<Slider>().value;
	}
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetFloat("user_ratio_ball_speed", _user_value);
        PlayerPrefs.Save();
        _user_value = this.GetComponent<Slider>().value;
    }
}
