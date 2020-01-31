using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop_controller : MonoBehaviour {
    public GameObject[] _enabl;

	// Use this for initialization
	void Start () {
        //--------------------------------------------------------------------------------------
        
        if (PlayerPrefs.GetInt("bought_0") == 1)
        {
            _enabl[0].GetComponent<enab>()._bought = true;
        }
        if (PlayerPrefs.GetInt("bought_1") == 1)
        {
            _enabl[1].GetComponent<enab>()._bought = true;
        }
        if (PlayerPrefs.GetInt("bought_2") == 1)
        {
            _enabl[2].GetComponent<enab>()._bought = true;
        }
        if (PlayerPrefs.GetInt("bought_3") == 1)
        {
            _enabl[3].GetComponent<enab>()._bought = true;
        }
        if (PlayerPrefs.GetInt("bought_4") == 1)
        {
            _enabl[4].GetComponent<enab>()._bought = true;
        }
        if (PlayerPrefs.GetInt("bought_5") == 1)
        {
            _enabl[5].GetComponent<enab>()._bought = true;
        }
        if (PlayerPrefs.GetInt("bought_6") == 1)
        {
            _enabl[6].GetComponent<enab>()._bought = true;
        }
        if (PlayerPrefs.GetInt("bought_7") == 1)
        {
            _enabl[7].GetComponent<enab>()._bought = true;
        }
        if (PlayerPrefs.GetInt("bought_8") == 1)
        {
            _enabl[8].GetComponent<enab>()._bought = true;
        }
        if (PlayerPrefs.GetInt("bought_9") == 1)
        {
            _enabl[9].GetComponent<enab>()._bought = true;
        }
        if (PlayerPrefs.GetInt("bought_10") == 1)
        {
            _enabl[10].GetComponent<enab>()._bought = true;
        }
        if (PlayerPrefs.GetInt("bought_11") == 1)
        {
            _enabl[11].GetComponent<enab>()._bought = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

        //--------------------------------------------------------------------------------------
        if (_enabl[0].GetComponent<enab>()._bought)
        {
            PlayerPrefs.SetInt("bought_0", 1);
        } else {
            PlayerPrefs.SetInt("bought_0", 0);
        }

        if (_enabl[1].GetComponent<enab>()._bought)
        {
            PlayerPrefs.SetInt("bought_1", 1);
        } else {
            PlayerPrefs.SetInt("bought_1", 0);
        }

        if (_enabl[2].GetComponent<enab>()._bought)
        {
            PlayerPrefs.SetInt("bought_2", 1);
        } else {
            PlayerPrefs.SetInt("bought_2", 0);
        }

        if (_enabl[3].GetComponent<enab>()._bought)
        {
            PlayerPrefs.SetInt("bought_3", 1);
        } else {
            PlayerPrefs.SetInt("bought_3", 0);
        }

        if (_enabl[4].GetComponent<enab>()._bought)
        {
            PlayerPrefs.SetInt("bought_4", 1);
        } else {
            PlayerPrefs.SetInt("bought_4", 0);
        }

        if (_enabl[5].GetComponent<enab>()._bought)
        {
            PlayerPrefs.SetInt("bought_5", 1);
        } else {
            PlayerPrefs.SetInt("bought_5", 0);
        }

        if (_enabl[6].GetComponent<enab>()._bought)
        {
            PlayerPrefs.SetInt("bought_6", 1);
        } else {
            PlayerPrefs.SetInt("bought_6", 0);
        }

        if (_enabl[7].GetComponent<enab>()._bought)
        {
            PlayerPrefs.SetInt("bought_7", 1);
        } else {
            PlayerPrefs.SetInt("bought_7", 0);
        }

        if (_enabl[8].GetComponent<enab>()._bought)
        {
            PlayerPrefs.SetInt("bought_8", 1);
        } else {
            PlayerPrefs.SetInt("bought_8", 0);
        }

        if (_enabl[9].GetComponent<enab>()._bought)
        {
            PlayerPrefs.SetInt("bought_9", 1);
        } else {
            PlayerPrefs.SetInt("bought_9", 0);
        }

        if (_enabl[10].GetComponent<enab>()._bought)
        {
            PlayerPrefs.SetInt("bought_10", 1);
        } else {
            PlayerPrefs.SetInt("bought_10", 0);
        }

        if (_enabl[11].GetComponent<enab>()._bought)
        {
            PlayerPrefs.SetInt("bought_11", 1);
        } else {
            PlayerPrefs.SetInt("bought_11", 0);
        }

        //--------------------------------------------------------------------------------------

        if (_enabl[0].GetComponent<enab>()._enable)
        {
            PlayerPrefs.SetInt("enabled_0", 1);
        } else {
            PlayerPrefs.SetInt("enabled_0", 0);
        }

        if (_enabl[1].GetComponent<enab>()._enable)
        {
            PlayerPrefs.SetInt("enabled_1", 1);
        } else {
            PlayerPrefs.SetInt("enabled_1", 0);
        }

        if (_enabl[2].GetComponent<enab>()._enable)
        {
            PlayerPrefs.SetInt("enabled_2", 1);
        } else {
            PlayerPrefs.SetInt("enabled_2", 0);
        }

        if (_enabl[3].GetComponent<enab>()._enable)
        {
            PlayerPrefs.SetInt("enabled_3", 1);
        } else {
            PlayerPrefs.SetInt("enabled_3", 0);
        }

        if (_enabl[4].GetComponent<enab>()._enable)
        {
            PlayerPrefs.SetInt("enabled_4", 1);
        } else {
            PlayerPrefs.SetInt("enabled_4", 0);
        }

        if (_enabl[5].GetComponent<enab>()._enable)
        {
            PlayerPrefs.SetInt("enabled_5", 1);
        } else {
            PlayerPrefs.SetInt("enabled_5", 0);
        }

        if (_enabl[6].GetComponent<enab>()._enable)
        {
            PlayerPrefs.SetInt("enabled_6", 1);
        } else {
            PlayerPrefs.SetInt("enabled_6", 0);
        }

        if (_enabl[7].GetComponent<enab>()._enable)
        {
            PlayerPrefs.SetInt("enabled_7", 1);
        } else {
            PlayerPrefs.SetInt("enabled_7", 0);
        }

        if (_enabl[8].GetComponent<enab>()._enable)
        {
            PlayerPrefs.SetInt("enabled_8", 1);
        } else {
            PlayerPrefs.SetInt("enabled_8", 0);
        }

        if (_enabl[9].GetComponent<enab>()._enable)
        {
            PlayerPrefs.SetInt("enabled_9", 1);
        } else {
            PlayerPrefs.SetInt("enabled_9", 0);
        }

        if (_enabl[10].GetComponent<enab>()._enable)
        {
            PlayerPrefs.SetInt("enabled_10", 1);
        } else {
            PlayerPrefs.SetInt("enabled_10", 0);
        }

        if (_enabl[11].GetComponent<enab>()._enable)
        {
            PlayerPrefs.SetInt("enabled_11", 1);
        } else {
            PlayerPrefs.SetInt("enabled_11", 0);
        }

        Debug.Log("10 - " + PlayerPrefs.GetInt("bought_10"));
        Debug.Log("11 - " + PlayerPrefs.GetInt("bought_11"));
        //--------------------------------------------------------------------------------------



        PlayerPrefs.Save();
    }
}
