using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class costs : MonoBehaviour {
    public int Count_of_cristals;
    public GameObject _text;
	// Use this for initialization
	void Start () {
        Count_of_cristals = int.Parse(_text.GetComponent<Text>().text);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
