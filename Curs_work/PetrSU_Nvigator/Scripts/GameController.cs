using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private GameObject previousMarker;

	private GameObject[] markers;

	public GameObject[] findedMarkersFromSearch = new GameObject[3];

	public string key = "";

	public MyInputFieldClass myInputFieldClass;

	void Awake()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 30;
	}

	private void Start()
	{
		markers = GameObject.FindGameObjectsWithTag("marker");
	}

	public void RemovePreviousMarker()
	{
		previousMarker.GetComponent<MarkerCabinetClass>().DestroyThisObject();
	}

	public void SetPreviousMarker(GameObject marker)
	{
		previousMarker = marker;
	}

	public bool HasPreviousMarker()
	{
		if(previousMarker == null)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	public void SetKeyForSearch(string input)
	{
		key = input;
	}

	public void ClearKeyForSearch()
	{
		key = "";
		findedMarkersFromSearch[0] = null;
		myInputFieldClass.AfterSearch();
	}

	public void FindMarker()
	{
		int i = 0;
		//Debug.Log("Merkers count : " + markers.Length.ToString());
		while ((i < markers.Length) && (!markers[i].GetComponent<MarkerOnMapClass>().cabinet.ToUpper().Equals(key.ToUpper())))
		{
			i++;
			//Debug.Log("i : " + i.ToString());
		}
		//Debug.Log("Search ended!");
		if (i != markers.Length)
		{
			findedMarkersFromSearch[0] = markers[i];
		}
		else
		{
			findedMarkersFromSearch[0] = null;
		}
		myInputFieldClass.AfterSearch();
	}
}
