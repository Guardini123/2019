using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_cam : MonoBehaviour {
    private float timeCount = 0.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(15, 90, 0), timeCount);
        timeCount += Time.deltaTime;
	}
}
