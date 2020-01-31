using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClearSearchClass : MonoBehaviour
{
	public MyInputFieldClass inputField;

	public void CleareSearch()
	{
		inputField.text = "";
		inputField.OnValueChanged();
	}
}
