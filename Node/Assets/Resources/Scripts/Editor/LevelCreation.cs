using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	private EditorObject[] level;
	
	private int width, height;
	private Dictionary<string, GameObject> resources;
	
	public void OnEnable()
	{
		width = height = 10;
		level = new EditorObject[width * height];
		for(int i = 0; i < width * height; i++)
		{
			level[i] = new EditorObject("", null);
		}
	
		resources = new Dictionary<string, GameObject>();
		
		resources.Add("Waypoint", (Resources.Load("Prefabs/Waypoint")) as GameObject);
		resources.Add("Wall", 	  (Resources.Load("Prefabs/Walls/Wall")) as GameObject);
		resources.Add("Start", 	  (Resources.Load("Prefabs/Start")) as GameObject);
		resources.Add("End", 	  (Resources.Load("Prefabs/End")) as GameObject);
		
		currentObj = new EditorObject("Wall", resources["Wall"]);
	}
	
	public void Update()
	{
		Repaint ();
	}
	
	public void OnGUI()
	{
		var evt = Event.current;
		
		GUILayout.BeginHorizontal();
			string key = "Wall";
			if(GUILayout.Button (key)) { currentObj = new EditorObject(key, resources[key]); }
			key = "Waypoint";
			if(GUILayout.Button (key)) { currentObj = new EditorObject(key, resources[key]); }
			key = "Start";
			if(GUILayout.Button (key)) { currentObj = new EditorObject(key, resources[key]); }
			key = "End";	
			if(GUILayout.Button (key)) { currentObj = new EditorObject(key, resources[key]); }
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
					level[j + width * i] = currentObj;
				}
				GUI.Box (rect, level[j + width * i].Name);
			}
			GUILayout.EndVertical();
		}
		GUILayout.EndHorizontal();
		
		if (GUILayout.Button("Export To Scene")) { ExportMap(); }
	}
	
	public void ClearScene()
	{
		object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
		foreach (object o in obj)
		{
			GameObject g = (GameObject) o;
			DestroyImmediate (g);
		}
	}
	
	public void ExportMap()
	{
		ClearScene(); 
		
		for(int i = 0; i < width; i++)
		{
			for(int j = 0; j < height; j++)
			{
				if(level[i * width + j] != null && level[i * width + j].Item != null)
					Instantiate (level[i * width + j].Item, new Vector3(i, 0, j), new Quaternion());
			}
		}
	}
}

//Enum of all placable objects
public class EditorObject 
{
	public string Name;
	public GameObject Item;
	
	public EditorObject()
	{
		Name = "";
		Item = null;
	}
	
	public EditorObject(string _name, GameObject _item)
	{
		Name = _name;
		Item = _item;
	}	
};