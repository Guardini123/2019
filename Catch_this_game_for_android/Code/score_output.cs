using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_output : MonoBehaviour {
    public GameObject control;
    public GameObject _high;
    public GameObject _score;
    public GameObject _cristals;
    public GameObject _cristals_zwei;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (control.GetComponent<g_controller>().start_game)
        {
            _score.GetComponent<Text>().text = control.GetComponent<g_controller>().points.ToString();
        }
        _high.GetComponent<Text>().text = "High score\n" + control.GetComponent<g_controller>().max_points.ToString();
        _cristals.GetComponent<Text>().text = control.GetComponent<g_controller>().cristals.ToString();
        _cristals_zwei.GetComponent<Text>().text = control.GetComponent<g_controller>().cristals.ToString();
    }
}
