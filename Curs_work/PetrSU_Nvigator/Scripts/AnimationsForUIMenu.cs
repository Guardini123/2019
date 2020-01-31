using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsForUIMenu : MonoBehaviour
{
	private Animation uiAnimationComponent;

	private bool weOpenSideMenu;

	public GameObject MainUI;
	public ObjectControl MapControl;

	// Start is called before the first frame update
	void Start()
    {
		uiAnimationComponent = this.GetComponent<Animation>();
		weOpenSideMenu = false;
	}

    // Update is called once per frame
    void Update()
    {
		if (!weOpenSideMenu && !uiAnimationComponent.isPlaying)
		{
			MainUI.SetActive(true);
			MapControl.enabled = true;
		}
    }

	public void OpenSideMenu()
	{
		weOpenSideMenu = true;
		uiAnimationComponent.Play("OpeningUIMenu");
	}

	public void CloseSideMenu()
	{
		uiAnimationComponent.Play("ClosingUIMenu");
		weOpenSideMenu = false;
	}
}
