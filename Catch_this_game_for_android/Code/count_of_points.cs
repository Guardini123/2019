using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class count_of_points : MonoBehaviour {
    private GameObject game_control;
    private GameObject spere;
    private GameObject particles;
    private Vector3 sphere_positions;
    private float delta_x = 999.0f;
    private float delta_y = 999.0f;
    private float delta_z = 999.0f;
    private AudioSource _audio;
    private AudioSource _audio_end;


    // Use this for initialization
    void Start () {
        game_control = GameObject.Find("Game_controller");
        spere = GameObject.Find("my_sphere_1");
        particles = GameObject.Find("Particle System");
        _audio = GameObject.Find("Directional Light").GetComponent<AudioSource>();
        _audio_end = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        sphere_positions = spere.transform.position;
        delta_z = transform.position.z - sphere_positions.z;
        if(delta_z < 0)
        {
            delta_x = Mathf.Abs(transform.position.x - sphere_positions.x);
            delta_y = Mathf.Abs(transform.position.y - sphere_positions.y);
            if ((delta_x < 0.8f) && (delta_y < 0.8f))
            {
                game_control.GetComponent<g_controller>().points += 1;
                _audio.Play();
            } else {
                if ((delta_x < 2.0f) && (delta_y < 2.0f))
                {
                    particles.GetComponent<sphere_dead>().dead_by_tor = true;
                }
                _audio_end.Play();
                game_control.GetComponent<g_controller>().lose = true;
                game_control.GetComponent<g_controller>().start_game = false;
            }
            this.enabled = false;
        }
    }
}
