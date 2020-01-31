using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touch_button : MonoBehaviour {
    public GameObject _control;
    public GameObject _panel;
    public GameObject _enabl;
    private Button _but;
    public int _costs;
	// Use this for initialization
	void Start () {
        if (_enabl.GetComponent<enab>()._bought)
        {
            this.gameObject.SetActive(false);
        }
        _but = this.GetComponent<Button>();
        this.GetComponent<Button>().enabled = false;
        _but.onClick.AddListener(OnClickTask);
    }
	
	// Update is called once per frame
	void Update () {
        if (_enabl.GetComponent<enab>()._bought)
        {
            this.gameObject.SetActive(false);
        }
        if (_control.GetComponent<g_controller>().cristals >= _panel.GetComponent<costs>().Count_of_cristals)
        {
            this.GetComponent<Button>().enabled = true;
        } else {
            this.GetComponent<Button>().enabled = false;
        }
	}

    void OnClickTask()
    {
        _control.GetComponent<g_controller>().cristals -= _panel.GetComponent<costs>().Count_of_cristals;
        _enabl.GetComponent<enab>()._bought = true;
    }
}
