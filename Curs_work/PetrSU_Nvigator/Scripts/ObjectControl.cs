using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectControl : MonoBehaviour
{
	public float speed;

	public float ratio;

	public float multiplierX;
	public float multiplierY;

	public float delay;

	private Vector2 startPos;
	private Camera cam;

	public float targetPosX;
	public float targetPosY;

	public Vector2 bordersX;
	public Vector2 bordersY;

	void Start()
	{
		cam = GetComponent<Camera>();
		targetPosX = transform.position.x;
		targetPosY = transform.position.y;
	}
	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			startPos = cam.ScreenToViewportPoint(Input.mousePosition);
		}
		else if (Input.GetMouseButton(0))
		{
			float posX = cam.ScreenToViewportPoint(Input.mousePosition).x - startPos.x;
			posX *= ratio;
			targetPosX = Mathf.Clamp(transform.position.x + posX, bordersX.x, bordersX.y);
			float posY = cam.ScreenToViewportPoint(Input.mousePosition).y - startPos.y;
			posY *= ratio;
			targetPosY = Mathf.Clamp(transform.position.y + posY, bordersY.x, bordersY.y);

			StartCoroutine(ExampleCoroutine());
		}

		transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPosX, speed * multiplierX * Time.deltaTime), Mathf.Lerp(transform.position.y, targetPosY, speed * multiplierY * Time.deltaTime), transform.position.z );
	}

	IEnumerator ExampleCoroutine()
	{
		yield return new WaitForSeconds(delay);

		startPos = cam.ScreenToViewportPoint(Input.mousePosition);
	}

	public void SetTarget(float x, float y)
	{
		targetPosX += x;
		targetPosY += y;
	}
}