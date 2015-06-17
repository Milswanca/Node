using UnityEngine;
using System.Collections;

public class BtnNodes : MonoBehaviour {
	
	private Editor editor;
	public GameObject WaypointPrefab;
	
	public void Start()
	{
		editor = GameObject.FindGameObjectWithTag ("Player").GetComponent<Editor> ();
	}
	
	public void Clicked()
	{
		editor.Tool = new ToolNode(editor, WaypointPrefab);
	}
}
