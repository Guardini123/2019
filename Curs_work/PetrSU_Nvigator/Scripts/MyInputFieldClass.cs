using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyInputFieldClass : MonoBehaviour
{
	public GameObject[] objectToSwitch;
	public GameObject keyObject;
	public bool[] stateForSwitch;

	private Text childrenText;

	public GameController gameController;

	public GameObject[] buttonsSearchResults = new GameObject[3];

	public string text;

	// Start is called before the first frame update
	void Start()
    {
		childrenText = this.transform.GetChild(0).gameObject.GetComponent<Text>();
		TouchScreenKeyboard.hideInput = true;
	}

	// Update is called once per frame
	void Update()
    {
		if (keyObject.activeSelf == true) {
			if (text.Length == 0)
			{
				for (int i = 0; i < objectToSwitch.Length; i++)
				{
					objectToSwitch[i].SetActive(stateForSwitch[i]);
				}
			}
			if (text.Length != 0)
			{
				for (int i = 0; i < objectToSwitch.Length; i++)
				{
					objectToSwitch[i].SetActive(!stateForSwitch[i]);
				}
			}
		}
	}

	public void StartSearch()
	{
		if (!text.Equals(""))
		{
			gameController.SetKeyForSearch(text);
			gameController.FindMarker();
		}
	}

	public void AfterSearch()
	{
		if(gameController.findedMarkersFromSearch[0] != null)
		{
			buttonsSearchResults[0].SetActive(true);
			buttonsSearchResults[0].transform.GetChild(0).gameObject.GetComponent<Text>().text = text;
			buttonsSearchResults[0].GetComponent<ButtonResultSearchClass>().SetMarkerResult(gameController.findedMarkersFromSearch[0]);
		}
		else
		{
			buttonsSearchResults[0].SetActive(false);
		}
	}

	public void OnValueChanged()
	{
		//Debug.Log("InputField : OnValueChanged");
		childrenText.text = text;
		StartSearch();
	}
}
