using UnityEngine;
using System.Collections;

public class BtnDelete : MonoBehaviour {

	private Editor editor;
	public GameObject WaypointPrefab;

	public void Start()
	{
		editor = GameObject.FindGameObjectWithTag ("Player").GetComponent<Editor> ();
	}

	public void Clicked()
	{
		editor.Tool = new ToolDelete(editor, WaypointPrefab);
	}
}
