using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	public string OnTxt = "Stop";
	public string ResetTxt = "Reset";

	public TypeOutScript TOS;

	void OnGUI()
	{

		if (GUI.Button(new Rect(20, 40, 100, 25), OnTxt))
		{
			if (TOS.On == true)
			{
				TOS.On = false;
				OnTxt = "Play";
			}
			else
			{
				TOS.On = true;
				OnTxt = "Stop";
			}
		}

		if (TOS.On == true)
		{
			OnTxt = "Stop";
		}
		else
		{
			OnTxt = "Play";
		}

		if (GUI.Button(new Rect(20, 70, 100, 25), ResetTxt))
		{
			TOS.reset = true;
		}

		GUI.Label(new Rect(20, 100, 100, 25),"Time");
		TOS.TotalTypeTime = GUI.HorizontalSlider(new Rect(20, 130, 100, 25), TOS.TotalTypeTime, 0.1F, 10F);

	}
}
