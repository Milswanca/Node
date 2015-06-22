using UnityEditor;
using UnityEngine;
using System.Collections;

public class LevelCreation : EditorWindow 
{
	[MenuItem ("Window/LevelEditor")]
	static void Init () 
	{
		var window = GetWindow<LevelCreation>();
		window.title = "LevelEditor";
	}
	
	//Currently Selected Object
	private EditorObject currentObj;
	private string[] level;
	
	private int width, height;
	
	public void OnEnable()
	{
		width = height = 10;
		level = new string[width * height];
		
		currentObj = new EditorObject("WALL");
	}
	
	public void Update()
	{
		Repaint ();
	}
	
	public void OnGUI()
	{
		var evt = Event.current;
		
		GUILayout.BeginHorizontal();
			if(GUILayout.Button ("Wall")) 	  { currentObj = new EditorObject("WALL"); }
			if(GUILayout.Button ("Waypoint")) { currentObj = new EditorObject("WAYPOINT"); }
			if(GUILayout.Button ("Start")) 	  { currentObj = new EditorObject("START"); }
			if(GUILayout.Button ("End")) 	  { currentObj = new EditorObject("END"); }
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		for(int i = 0; i < width; i++)
		{
			GUILayout.BeginVertical();
			for(int j = 0; j < height; j++)
			{
				var rect = GUILayoutUtility.GetRect (GUIContent.none, GUIStyle.none, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));	
				
				if((evt.type == EventType.MouseDown || evt.type == EventType.MouseDrag) && rect.Contains(evt.mousePosition))
				{
					level[j + width * i] = currentObj.Name;
				}
				GUI.Box (rect, level[j + width * i]);
			}
			GUILayout.EndVertical();
		}
		GUILayout.EndHorizontal();
	}
}

//Enum of all placable objects
public class EditorObject 
{
	public string Name;
	
	public EditorObject(string _name)
	{
		Name = _name;
	}	
};