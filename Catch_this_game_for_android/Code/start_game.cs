using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_game : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<g_controller>().start_game = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
