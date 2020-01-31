using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class on_tor : MonoBehaviour {
    private float targetPos;

    public float speed_init;
    public float speed_dv;

    public GameObject game_control;

	// Use this for initialization
	void Start () {
        targetPos = Random.Range(-2.0f, 2.0f);
        game_control = GameObject.Find("Game_controller");
    }
	
	// Update is called once per frame
	void Update () {
        if (!game_control.GetComponent<g_controller>().lose)
        {
            if (transform.position.y > targetPos + 0.5f)
            {
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, targetPos, speed_init * Time.deltaTime), transform.position.z);
            } else {
                if (game_control.GetComponent<g_controller>().start_game)
                {
                    transform.Translate(0, 0, -speed_dv * Time.deltaTime - game_control.GetComponent<g_controller>().points / 500.0f);
                    //Debug.Log(game_control.GetComponent<g_controller>().points / 10);
                }
            }
        }

        if (transform.position.z < -6.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
