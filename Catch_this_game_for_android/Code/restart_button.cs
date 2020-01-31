using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart_button : MonoBehaviour
{
    public GameObject button;

    // Use this for initialization
    void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<g_controller>().lose)
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
        }
    }
}
