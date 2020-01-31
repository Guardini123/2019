using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enab_control_3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if ((PlayerPrefs.GetInt("enabled_0") == 0)
            && (PlayerPrefs.GetInt("enabled_1") == 0)
            && (PlayerPrefs.GetInt("enabled_2") == 0)
            && (PlayerPrefs.GetInt("enabled_3") == 1)
            && (PlayerPrefs.GetInt("enabled_4") == 0)
            && (PlayerPrefs.GetInt("enabled_5") == 0)
            && (PlayerPrefs.GetInt("enabled_6") == 0)
            && (PlayerPrefs.GetInt("enabled_7") == 0)
            && (PlayerPrefs.GetInt("enabled_8") == 0)
            && (PlayerPrefs.GetInt("enabled_9") == 0) 
            && (PlayerPrefs.GetInt("enabled_10") == 0)
            && (PlayerPrefs.GetInt("enabled_11") == 0))
        {
            this.GetComponent<enab>()._enable = true;
        }
        else
        {
            this.GetComponent<enab>()._enable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((PlayerPrefs.GetInt("enabled_3") == 1) && ((PlayerPrefs.GetInt("enabled_1") == 1)
            || (PlayerPrefs.GetInt("enabled_2") == 1)
            || (PlayerPrefs.GetInt("enabled_0") == 1)
            || (PlayerPrefs.GetInt("enabled_4") == 1)
            || (PlayerPrefs.GetInt("enabled_5") == 1)
            || (PlayerPrefs.GetInt("enabled_6") == 1)
            || (PlayerPrefs.GetInt("enabled_7") == 1)
            || (PlayerPrefs.GetInt("enabled_8") == 1)
            || (PlayerPrefs.GetInt("enabled_9") == 1)
            || (PlayerPrefs.GetInt("enabled_10") == 1)
            || (PlayerPrefs.GetInt("enabled_11") == 1)))
        {
            this.GetComponent<enab>()._enable = false;
        }
    }
}
