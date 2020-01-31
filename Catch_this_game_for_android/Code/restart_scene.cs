using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;
using UnityStandardAssets.ImageEffects;

public class restart_scene : MonoBehaviour {
    // Use this for initialization
    public GameObject _cam;
	void Start () {
        if(_cam.GetComponent<PostProcessingBehaviour>().enabled == true)
        {
            PlayerPrefs.SetInt("enable_post_proc", 1);
        } else
        {
            PlayerPrefs.SetInt("enable_post_proc", 0);
        }

        if (_cam.GetComponent<ColorCorrectionLookup>().enabled == true)
        {
            PlayerPrefs.SetInt("enable_color_correct", 1);
        } else {
            PlayerPrefs.SetInt("enable_color_correct", 0);
        }
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
