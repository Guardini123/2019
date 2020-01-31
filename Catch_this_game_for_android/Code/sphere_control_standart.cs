using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere_control_standart : MonoBehaviour {
    private Vector2 startPos;
    public Camera _cam;

	// Use this for initialization
	void Start () {
        //_cam = GetComponent<Camera>();	
	}
	
	// Update is called once per frame
	private void Update () {
		if (Input.GetMouseButtonDown(0)) {
            startPos = _cam.ScreenToViewportPoint(Input.mousePosition);
        } else if (Input.GetMouseButton(0)) {
            float posX = _cam.ScreenToViewportPoint(Input.mousePosition).x - startPos.x;
            float posY = _cam.ScreenToViewportPoint(Input.mousePosition).y - startPos.y;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + posX, -10.0f, 10.0f), Mathf.Clamp(transform.position.y + posY, -10.0f, 10.0f), transform.position.z);
        }
	}
}
