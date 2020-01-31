using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_sound : MonoBehaviour {
    private AudioSource _audio;
    public Button[] _mas_buttons;
	// Use this for initialization
	void Start () {
        _audio = GameObject.Find("Canvas").GetComponent<AudioSource>();
        foreach (Button _but in _mas_buttons)
        {
            _but.onClick.AddListener(OnClickTask);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClickTask() {
        _audio.Play();
    }
}
