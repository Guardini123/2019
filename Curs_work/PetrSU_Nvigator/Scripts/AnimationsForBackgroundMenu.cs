using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsForBackgroundMenu : MonoBehaviour
{
	private Animation backgroundAnimationComponent;

	// Start is called before the first frame update
	void Start()
	{
		backgroundAnimationComponent = this.GetComponent<Animation>();
	}

	public void OpenSideMenu()
	{
		backgroundAnimationComponent.Play("OpeningBackgroundMenu");
	}

	public void CloseSideMenu()
	{
		backgroundAnimationComponent.Play("ClosingBackgroundMenu");
	}
}
