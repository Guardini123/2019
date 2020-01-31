using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere_dead : MonoBehaviour {
    public GameObject _controller;
    public GameObject _sphere;
    public GameObject _camera;
    public ParticleSystem _particls;
    private bool was_played = false;
    private bool was_impacted = false;
    public bool dead_by_tor;

    // Use this for initialization
    void Start () {
        _sphere.GetComponent<MeshRenderer>().enabled = true;
        dead_by_tor = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (_controller.GetComponent<g_controller>().lose)
        {
            if ((!was_played) && (dead_by_tor))
            {
                //_sphere.GetComponent<MeshRenderer>().enabled = false;
                //_particls.Play();
                was_played = true;
                _sphere.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z - 0.9f);
                _sphere.GetComponent<Rigidbody>().isKinematic = false;
            }
            if ((!dead_by_tor) && (!was_impacted))
            {
                _sphere.GetComponent<Rigidbody>().AddForce(transform.up * (-1) * 600.0f);
                was_impacted = true;
                _sphere.GetComponent<Rigidbody>().isKinematic = false;
            }
            if (_sphere.transform.position.y < -35.0f)
            {
                _sphere.GetComponent<Rigidbody>().isKinematic = true;
            }
            _camera.GetComponent<cam_control>().enabled = false;
            _sphere.GetComponent<sphere_control>().enabled = false;
        }
	}
}
