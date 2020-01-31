using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instant_torus : MonoBehaviour {
	public Transform tor;

    public float timer_start;
    public float timer_in_game;
    int i = 0;

    public float time_of_pause;

    bool can_instant_next = true;
    public int _count = 0;
    float _dis = 24.0f;

    public bool player_lose;
    public bool start;
    public bool end_test_time;
    // Use this for initialization
    void Start () {
        can_instant_next = true;
        player_lose = this.GetComponent<g_controller>().lose;
        start = this.GetComponent<g_controller>().start_game;
        end_test_time = this.GetComponent<g_controller>().end_time;
        if (PlayerPrefs.GetInt("initial") == 0)
        {
            PlayerPrefs.SetInt("limit", 100);
            PlayerPrefs.SetInt("initial", 1);
            Debug.Log("initial_limit");
        }
    }
	
	// Update is called once per frame
	void Update () {
        player_lose = this.GetComponent<g_controller>().lose;
        start = this.GetComponent<g_controller>().start_game;
        end_test_time = this.GetComponent<g_controller>().end_time;

        if ((can_instant_next) && (_count < 2))
        {
            instant(timer_start);
        }

        if ((_count == 2) && (start))
        {
            can_instant_next = false;
            time_of_pause = timer_in_game;
            i = 1;
            _count++;
        }

        if((_count >= 3) && (can_instant_next) && (!player_lose) && (start) && (!end_test_time))
        {
            instant(timer_in_game);
        }

        if ((i == 1) && (!can_instant_next))
        {
            if (time_of_pause > 0)
                time_of_pause = time_of_pause - Time.deltaTime;
            if (time_of_pause < 0)
            {
                i = 0;
                can_instant_next = true;
            }
        }
    }

    void instant(float time)
    {
        if (this.GetComponent<g_controller>().points >= PlayerPrefs.GetInt("limit"))
        {
            Instantiate(tor, new Vector3(Random.Range(11.0f, 17.0f), 30.0f, _dis), Quaternion.identity);
            if (PlayerPrefs.GetInt("limit") < 240)
            {
                PlayerPrefs.SetInt("limit", PlayerPrefs.GetInt("limit") + Random.Range(20, 100));
            }
        } else {
            Instantiate(tor, new Vector3(Random.Range(-3.0f, 3.0f), 30.0f, _dis), Quaternion.identity);
        }
        _count++;
        if (_count < 2) { _dis += 7.0f; }
        //Debug.Log(_dis);
        can_instant_next = false;
        time_of_pause = time - this.GetComponent<g_controller>().points / 170.0f;
        i = 1;
    }
}
