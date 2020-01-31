using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour {
    private bool this_is_alive = false;
    private bool was_played = false;

    public GameObject game_control;
    public GameObject spere;
    private Vector3 sphere_positions;
    private float delta_x = 999.0f;
    private float delta_y = 999.0f;
    private float delta_z = 999.0f;
    // Use this for initialization
    void Start () {
        if (((Random.Range(0.0f, 5000.0f) > 4500.0f) || (Random.Range(0.0f, 5000.0f) < 500.0f)))
        {
            this_is_alive = true;
            game_control = GameObject.Find("Game_controller");
            spere = GameObject.Find("my_sphere_1");
        } else {
            this.gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (this_is_alive)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 40 * Time.timeScale, Space.Self);
            sphere_positions = spere.transform.position;
            delta_z = Mathf.Abs(transform.position.z - sphere_positions.z);
            if (delta_z < 0.2f)
            {
                delta_x = Mathf.Abs(transform.position.x - sphere_positions.x);
                delta_y = Mathf.Abs(transform.position.y - sphere_positions.y);
                if ((delta_x < 0.3f) && (delta_y < 0.6f))
                {
                    if (!was_played)
                    {
                        if (game_control.GetComponent<g_controller>().can_vibrate == 1)
                        {
                            Handheld.Vibrate();
                        }
                        game_control.GetComponent<g_controller>().cristals += 1;
                        this.GetComponent<ParticleSystem>().Play();
                        was_played = true;
                        this.GetComponent<Cone>().enabled = false;
                        this.GetComponent<MeshRenderer>().enabled = false;
                    }               
                }
            }
        }
    }
}
