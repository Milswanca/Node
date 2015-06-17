using UnityEngine;
using System.Collections;

public class BtnLines : MonoBehaviour {

	private Editor editor;
	public GameObject WaypointPrefab;

	public void Start()
	{
		editor = GameObject.FindGameObjectWithTag ("Player").GetComponent<Editor> ();
	}

	public void Clicked()
	{
		editor.Tool = new ToolLine(editor, WaypointPrefab);
	}
}
