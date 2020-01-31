using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class g_controller : MonoBehaviour {
    public int can_vibrate;
    public bool lose;
    public bool start_game;
    public bool end_time;
    public int points = 0;
    public int cristals = 0;
    public int max_points;
    private bool _flag = false;

    //---------GUI------------------
    public GameObject _start_button;
    public GameObject _restart_button;
    public GameObject _score_output;
    public GameObject _high_score_output;
    public GameObject _crystals_output;
    public GameObject _logo;
    public GameObject _top;
    public GameObject _menu;
    public GameObject _close;
    public Toggle _toggle;


    //--------timer-----------------
    private bool can_upgrade_time = false;
    private int i = 0;
    private float _time;
    private float time_pause = 1.0f;

	//---------- Use this for initialization ----------------
	void Start () {
        if (PlayerPrefs.GetInt("vibration_was_enabled") == 0)
        {
            PlayerPrefs.SetInt("vibration", 1);
            PlayerPrefs.SetInt("vibration_was_enabled", 1);
        }
        can_vibrate = PlayerPrefs.GetInt("vibration");
        if (can_vibrate == 1)
        {
            _toggle.isOn = true;
        } else {
            _toggle.isOn = false;
        }
        QualitySettings.SetQualityLevel(0, true);
        Time.timeScale = 1.0f;
        lose = false;
        start_game = false;
        _time = time_pause;
        max_points = PlayerPrefs.GetInt("score");
        //PlayerPrefs.SetInt("cristals", 10000);
        cristals = PlayerPrefs.GetInt("cristals");
	}
	
	//-------------------- Update is called once per frame -------------------
	void Update () {
        if(start_game && !_flag)
        {
            i = 1;
            _flag = true;
        }
        if(lose)
        {
            _score_output.SetActive(true);
            _start_button.SetActive(false);
            _restart_button.SetActive(true);
            _top.SetActive(false);
            _menu.SetActive(false);
            _close.SetActive(false);
            _logo.SetActive(false);
            _high_score_output.SetActive(true);
            _crystals_output.SetActive(true);
        }
        PlayerPrefs.SetInt("vibration", can_vibrate);
        PlayerPrefs.SetInt("cristals", cristals);
        PlayerPrefs.Save();
        if (Input.GetKeyDown(KeyCode.L))
        {
            max_points = 0;
            PlayerPrefs.SetInt("score", max_points);
            PlayerPrefs.Save();
        }

        if(max_points < points)
        {
            max_points = points;
            PlayerPrefs.SetInt("score", max_points);
            PlayerPrefs.Save();
        }
        if (can_upgrade_time && !lose)
        {
            //Time.timeScale += 0.01f;
            can_upgrade_time = false;
            i = 1;
            _time = time_pause;
        }
        if ((i == 1) && (!can_upgrade_time))
        {
            if (_time > 0)
                _time -= Time.deltaTime;
            if (_time < 0)
            {
                i = 0;
                can_upgrade_time = true;
            }
        }
        if (_toggle.isOn)
        {
            can_vibrate = 1;
        } else {
            can_vibrate = 0;
        }
    }
}
