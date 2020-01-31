using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move_shop : MonoBehaviour {
    public Camera _cam;
    private Vector2 startPos;
    private float targetPos;
    public float _speed;
	// Use this for initialization
	void Start () {
        targetPos = transform.position.x;		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) startPos = _cam.ScreenToViewportPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            float pos = _cam.ScreenToViewportPoint(Input.mousePosition).x - startPos.x;
            targetPos = Mathf.Clamp(transform.position.x - pos * 50 * (-1), -1200.0f, 600.0f);
        }
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPos, _speed * Time.deltaTime * 100), transform.position.y, transform.position.z);
	}
}
