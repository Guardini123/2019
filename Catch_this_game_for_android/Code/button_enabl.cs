using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_enabl : MonoBehaviour {
    private Button _but;
    public GameObject _enabl;
    
    // Use this for initialization
    void Start () {
        _but = this.GetComponent<Button>();
        _but.onClick.AddListener(OnClickTask);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnClickTask()
    {
        if (_enabl.GetComponent<enab>()._bought)
        {
            _enabl.GetComponent<enab>()._enable = true;
        }
    }
}
