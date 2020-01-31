using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkerCabinetClass : MonoBehaviour
{
	public Text cabinetText;

	public GameController controller;

	private void Start()
	{
		controller = GameObject.Find("EventSystem").GetComponent<GameController>();
		if (controller.HasPreviousMarker())
		{
			controller.RemovePreviousMarker();
		}
		controller.SetPreviousMarker(this.gameObject);
	}

	public void SetCabinetText(string text)
	{
		cabinetText.text = text;
	}

	public void DestroyThisObject()
	{
		Destroy(this.gameObject);
	}
}
