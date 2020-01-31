using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerOnMapClass : MonoBehaviour
{
	public bool isCabinet;

	public string cabinet;
	public int layer;
	public string info;

	public GameObject marker;

	public Transform myCamera;
	public Transform parentForCabinetMarker;

	public float dx, dy;

	private void Start()
	{
		parentForCabinetMarker = GameObject.Find("Plane").transform;
		myCamera = GameObject.Find("Main Camera").transform;

		if (isCabinet)
		{
			marker = Resources.Load<GameObject>("Prefabs/markerCabinetMain");
		}
		else
		{
			marker = Resources.Load<GameObject>("Prefabs/markerAreaMain");
		}
	}

	public string GetCabinetName()
	{
		return cabinet;
	}

	public int GetCabinetLayer()
	{
		return layer;
	}

	public string GetCabinetInfo()
	{
		return info;
	}

	public bool IsCabinet()
	{
		return isCabinet;
	}

	public void TouchMarker()
	{
		GameObject markerCabinet = Instantiate(marker, this.transform.position, Quaternion.identity, parentForCabinetMarker);
		markerCabinet.transform.Rotate(90.0f, 0.0f, 180.0f, Space.Self);
		markerCabinet.transform.Translate(0.0f, 0.1f, 0.0f, Space.Self);
		markerCabinet.GetComponent<MarkerCabinetClass>().SetCabinetText(cabinet);

		//Debug.Log("myCamera.transform.position.x : " + myCamera.transform.position.x.ToString());
		//Debug.Log("marker.transform.position.x : " + this.transform.position.x.ToString());

		dx = myCamera.transform.position.x - this.transform.position.x;
		dy = myCamera.transform.position.y - this.transform.position.y;

		ObjectControl planeControlScript = parentForCabinetMarker.gameObject.GetComponent<ObjectControl>();
		//planeControlScript.enabled = false;
		parentForCabinetMarker.GetComponent<ObjectControl>().SetTarget(dx, dy);
		//planeControlScript.enabled = true;
	}
}
