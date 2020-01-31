using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonResultSearchClass : MonoBehaviour
{
	public GameObject markerResult;

	public void SetMarkerResult(GameObject marker)
	{
		markerResult = marker;
	}

	public void Search()
	{
		markerResult.GetComponent<MarkerOnMapClass>().TouchMarker();
	}
}
