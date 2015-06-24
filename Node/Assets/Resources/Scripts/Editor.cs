using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Editor : MonoBehaviour 
{
	public Tool Tool;

	public List<Waypoint> Waypoints;
	public GameObject WaypointPrefab;

	private Waypoint start, end;

	// Use this for initialization
	void Awake () 
	{
		Tool = new ToolNode(this, WaypointPrefab);

		Waypoints = new List<Waypoint> ();

		start = GameObject.FindGameObjectWithTag ("Start").GetComponent<Waypoint> ();
		end = GameObject.FindGameObjectWithTag ("End").GetComponent<Waypoint> ();

		Reset ();
	}

	void Update()
	{
		Tool.Update ();
	}

	public Waypoint GetWaypointAtGrid(Vector2 grid)
	{
		foreach (Waypoint i in Waypoints) 
		{
			if(i.GridPos == grid)
			{
				return i;
			}
		}

		return null;
	}

	public bool DeleteNode(Waypoint node)
	{
		foreach (Waypoint i in Waypoints) 
		{
			if(node == i)
			{
				Waypoints.Remove(node);
				GameObject temp = node.gameObject;
				Destroy (temp);
				return true;
			}
		}

		return false;
	}

	public void OnDrawGizmos()
	{
		foreach (Waypoint i in Waypoints) 
		{
			if(i.LinkedTo != null)
			{
				Gizmos.DrawLine(i.transform.position, i.LinkedTo.transform.position);
			}
		}
	}

	public void Reset()
	{
		foreach(Waypoint i in Waypoints)
		{
			i.LinkedTo = null;
			if(i.gameObject.tag != "Start" && i.gameObject.tag != "End")
				Destroy (i.gameObject);
		}

		Waypoints.Clear ();
		
		Waypoints.Add (start);
		Waypoints.Add (end);
	}
}