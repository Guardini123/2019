using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggle_sound : MonoBehaviour {
    private AudioSource _audio;
    public Toggle[] _mas_toggles;
    // Use this for initialization
    void Start () {
        _audio = GameObject.Find("EventSystem").GetComponent<AudioSource>();
        foreach (Toggle _tog in _mas_toggles)
        {
            _tog.onValueChanged.AddListener(delegate { toggleValueChanged(_tog); });
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void toggleValueChanged(Toggle changed)
    {
        _audio.Play();
    }
}
