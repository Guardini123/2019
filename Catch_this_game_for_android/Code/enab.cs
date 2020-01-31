using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enab : MonoBehaviour {
    public GameObject _image_close;
    public GameObject _text;
    public GameObject _image_bought;
    public bool _bought;
    public bool _enable;
    public Texture _texture;
    public Material _mat_sphere;
    public Material _mat_particles;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (_bought && _enable)
        {
            _mat_sphere.mainTexture = _texture;
            _mat_particles.mainTexture = _texture;
        }

        if(_bought)
        {
            _image_bought.SetActive(true);
            _image_close.SetActive(false);
            _text.SetActive(false);
        }

	}
}
