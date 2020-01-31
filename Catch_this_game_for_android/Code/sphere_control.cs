using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sphere_control : MonoBehaviour {
    public float speed;

    private Vector2 startPos;
    private Camera cam;

    private float targetPosX;
    private float targetPosY;

    public GameObject _controller;
    public GameObject[] _enebled;

    void Start()
    {
        if (PlayerPrefs.GetInt("enabled_0") == 1) {
            _enebled[0].GetComponent<enab>()._mat_sphere.mainTexture = _enebled[0].GetComponent<enab>()._texture;
        } else if (PlayerPrefs.GetInt("enabled_1") == 1) {
            _enebled[1].GetComponent<enab>()._mat_sphere.mainTexture = _enebled[1].GetComponent<enab>()._texture;
        } else if (PlayerPrefs.GetInt("enabled_2") == 1) {
            _enebled[2].GetComponent<enab>()._mat_sphere.mainTexture = _enebled[2].GetComponent<enab>()._texture;
        } else if (PlayerPrefs.GetInt("enabled_3") == 1) {
            _enebled[3].GetComponent<enab>()._mat_sphere.mainTexture = _enebled[3].GetComponent<enab>()._texture;
        } else if (PlayerPrefs.GetInt("enabled_4") == 1) {
            _enebled[4].GetComponent<enab>()._mat_sphere.mainTexture = _enebled[4].GetComponent<enab>()._texture;
        } else if (PlayerPrefs.GetInt("enabled_5") == 1) {
            _enebled[5].GetComponent<enab>()._mat_sphere.mainTexture = _enebled[5].GetComponent<enab>()._texture;
        } else if (PlayerPrefs.GetInt("enabled_6") == 1) {
            _enebled[6].GetComponent<enab>()._mat_sphere.mainTexture = _enebled[6].GetComponent<enab>()._texture;
        } else if (PlayerPrefs.GetInt("enabled_7") == 1) {
            _enebled[7].GetComponent<enab>()._mat_sphere.mainTexture = _enebled[7].GetComponent<enab>()._texture;
        } else if (PlayerPrefs.GetInt("enabled_8") == 1) {
            _enebled[8].GetComponent<enab>()._mat_sphere.mainTexture = _enebled[8].GetComponent<enab>()._texture;
        } else if (PlayerPrefs.GetInt("enabled_9") == 1) {
            _enebled[9].GetComponent<enab>()._mat_sphere.mainTexture = _enebled[9].GetComponent<enab>()._texture;
        } else if (PlayerPrefs.GetInt("enabled_10") == 1) {
            _enebled[10].GetComponent<enab>()._mat_sphere.mainTexture = _enebled[10].GetComponent<enab>()._texture;
        } else if (PlayerPrefs.GetInt("enabled_11") == 1) {
            _enebled[11].GetComponent<enab>()._mat_sphere.mainTexture = _enebled[11].GetComponent<enab>()._texture;
        }

        cam = GetComponent<Camera>();
        targetPosX = transform.position.x;
        targetPosY = transform.position.y;
        speed = speed + 30.0f * PlayerPrefs.GetFloat("user_ratio_ball_speed");
    }
    // Update is called once per frame
    void Update()
    {
        if (_controller.GetComponent<g_controller>().start_game)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * 200, Space.Self);
            if (Input.GetMouseButtonDown(0))
            {
                startPos = cam.ScreenToViewportPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0))
            {
                float posX = cam.ScreenToViewportPoint(Input.mousePosition).x - startPos.x;
                targetPosX = Mathf.Clamp(transform.position.x + posX, -10, 10);
                float posY = cam.ScreenToViewportPoint(Input.mousePosition).y - startPos.y;
                targetPosY = Mathf.Clamp(transform.position.y + posY, -10, 10);
            }
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPosX, speed * Time.deltaTime), Mathf.Lerp(transform.position.y, targetPosY, speed * 5 * Time.deltaTime), transform.position.z);
        }
    }
}