using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_time_test_version : MonoBehaviour {
    public float timer;
	// Use this for initialization
	void Start () {
        timer = PlayerPrefs.GetFloat("time_game");
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
        PlayerPrefs.SetFloat("time_game", timer);
        PlayerPrefs.Save();
        if(Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.E))
        {
            timer = 0.0f;
            PlayerPrefs.SetFloat("time_game", timer);
            PlayerPrefs.Save();
        }
	}
}
