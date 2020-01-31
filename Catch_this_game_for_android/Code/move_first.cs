using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_first : MonoBehaviour {
    public float speed_dvich;
    private GameObject game_controle;

    // Use this for initialization
    void Start () {
        game_controle = GameObject.Find("Game_controller");
    }
	
	// Update is called once per frame
	void Update () {
        if ((game_controle.GetComponent<g_controller>().start_game) && (!game_controle.GetComponent<g_controller>().lose))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed_dvich * Time.deltaTime * 2);
        }
        if (transform.position.z < -10.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
