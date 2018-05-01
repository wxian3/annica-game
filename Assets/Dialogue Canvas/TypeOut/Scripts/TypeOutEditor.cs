using UnityEngine;  
using UnityEditor;  
using UnityEditorInternal;
using System;

[CustomEditor(typeof(TypeOutScript))]
public class TypeOutEditor : Editor {  

	private string ontxt = "Turn On";

	private SerializedObject TOS;
	private SerializedProperty finalText;
	private SerializedProperty On;
	private SerializedProperty Reset;
	private SerializedProperty TotalTypeTime;
	private SerializedProperty TypeRate;
	private SerializedProperty RandomCharacterChangeRate;

	enum TimeModes {TotalTime = 0, TypeRate =1};
	TimeModes TM = TimeModes.TotalTime;
	private float Time = 0.5f;
	private float RCCR = 0.1f;

	public void OnEnable()
	{
		if (target == null)
		{
			return;
		}

		TOS = new SerializedObject(target);
		finalText = TOS.FindProperty("FinalText");
		On = TOS.FindProperty("On");
		Reset = TOS.FindProperty("reset");
		TotalTypeTime = TOS.FindProperty("TotalTypeTime");
		TypeRate = TOS.FindProperty("TypeRate");
		RandomCharacterChangeRate = TOS.FindProperty("RandomCharacterChangeRate");
	}


	public override void OnInspectorGUI() 
	{
		TOS.Update();

		finalText.stringValue = ParseNewline(finalText.stringValue.Trim());

//		EditorGUILayout.PropertyField(On);
//		EditorGUILayout.PropertyField(Reset);

		EditorGUILayout.BeginHorizontal ();

		if(GUILayout.Button(ontxt))
		{
			if (On.boolValue == true)
			{
				On.boolValue = false;
				ontxt = "Turn On";
			}
			else
			{
				On.boolValue = true;
				ontxt = "Turn Off";
			}
		}

		if (On.boolValue == true)
		{
			ontxt = "Turn Off";
		}
		else
		{
			ontxt = "Turn On";
		}

		if(GUILayout.Button("Reset"))
		{
			Reset.boolValue = true;
		}

		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.Space();

//		GUI.Label(new Rect(0, 40, 100, 40), GUI.tooltip);
		EditorGUILayout.LabelField("FinalText:");
		EditorGUILayout.LabelField("note: '\\n' for new line");
		EditorGUILayout.PropertyField(finalText, GUIContent.none,GUILayout.Height(50));

		EditorGUILayout.Space();

		EditorGUILayout.BeginHorizontal ();

		TM = (TimeModes) EditorGUILayout.EnumPopup(TM);

		if (TM == TimeModes.TotalTime)
		{
			Time = EditorGUILayout.Slider(Time,0f, 10f);
			TotalTypeTime.floatValue = Time;
		}
		else
		{
			Time = EditorGUILayout.Slider(Time,0f, 1f);
			TotalTypeTime.floatValue = -1f;
			TypeRate.floatValue = Time;
		}
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.Space();

		EditorGUILayout.LabelField("Random Character Change Rate");

		RCCR = EditorGUILayout.Slider(RCCR,0f, 1f);
		RandomCharacterChangeRate.floatValue = RCCR;

		TOS.ApplyModifiedProperties();

	}

	private string ParseNewline(string s)
	{
		s = s.Replace("\\n","|");
		
		string[] SS = s.Split('|');
		
		string ReturnString = "";
		
		foreach (string rp in SS)
		{
			ReturnString = ReturnString + rp + "\n";
		}
		
		return ReturnString;
	}
}

