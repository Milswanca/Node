using UnityEngine;
using System.Collections;

public class Tool 
{
	protected int floorMask;
	protected Editor editor;
	protected GameObject waypointPrefab;
	protected Scorer scorer;

	protected RaycastHit floorHit;

	public Tool(Editor _editor, GameObject _waypointPrefab)
	{
		editor = _editor;
		waypointPrefab = _waypointPrefab;
		floorMask = LayerMask.GetMask ("Floor");
		scorer = GameObject.FindGameObjectWithTag ("Manager").GetComponent<Scorer> ();
	}

	public void Update()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			OnClickPressed ();
		} 
		else if (Input.GetButton ("Fire1")) 
		{
			OnClickHeld ();
		}
		else if (Input.GetButtonUp   ("Fire1")) 
		{ 
			OnClickUp(); 
		}
	}

	public virtual void OnClickPressed()
	{

	}

	public virtual void OnClickHeld()
	{

	}

	public virtual void OnClickUp()
	{

	}

	public bool CastToFloor()
	{
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		// Perform the raycast and if it hits something on the floor layer...
		return (Physics.Raycast (camRay, out floorHit, 100.0f, floorMask));
	}
}

public class ToolNode : Tool
{
	private Waypoint selected;

	public ToolNode(Editor _editor, GameObject _waypointPrefab) : base(_editor, _waypointPrefab)
	{

	}

	public override void OnClickUp()
	{
		if(CastToFloor())
		{
			Vector2 grid = Grid.PosToGrid(floorHit.point, 1.0f);

			selected = editor.GetWaypointAtGrid(grid);

			if(selected == null)
			{
				Waypoint newWaypoint = (GameObject.Instantiate(waypointPrefab, floorHit.point, new Quaternion()) as GameObject).GetComponent<Waypoint>(); 
				newWaypoint.isMovable = true;
				newWaypoint.isHidden = false;
				editor.Waypoints.Add (newWaypoint);

				selected = newWaypoint;

				scorer.CurrentScore -= 100;
			}
		}
	}

	public override void OnClickHeld()
	{
		/*
		if (selected != null) 
		{
			if(CastToFloor())
			{
				if(editor.GetWaypointAtGrid(Grid.PosToGrid(floorHit.point, 1.0f)) == null)
				{
					if(selected.isMovable == true)
						selected.GridPos = Grid.PosToGrid(floorHit.point, 1.0f);
				}
			}
		}
		*/
	}
}

public class ToolLine : Tool
{
	Waypoint start; 
	Vector3 end;

	bool isValid;

	public ToolLine(Editor _editor, GameObject _waypointPrefab) : base(_editor, _waypointPrefab)
	{
		
	}

	public override void OnClickPressed()
	{
		if(CastToFloor())
		{
			start = editor.GetWaypointAtGrid(Grid.PosToGrid(floorHit.point, 1.0f));
		}
	}
	
	public override void OnClickHeld()
	{
		if (start != null) 
		{
			if(CastToFloor())
			{
				end = floorHit.point;
				isValid = !Physics.Linecast(start.transform.position, end, LayerMask.GetMask("Collision"));

				if(isValid)
					Debug.DrawLine(start.transform.position, end, Color.green);
				else
					Debug.DrawLine(start.transform.position, end, Color.red);
			}
		}
	}
	
	public override void OnClickUp()
	{
		if (start != null) 
		{
			if(CastToFloor() && isValid)
			{
				Waypoint atMouse = editor.GetWaypointAtGrid(Grid.PosToGrid(floorHit.point, 1.0f));
				if(atMouse != null)
				{
					start.LinkedTo = atMouse;
				}
			}
		}
	}
}

public class ToolDelete : Tool
{
	public ToolDelete(Editor _editor, GameObject _waypointPrefab) : base(_editor, _waypointPrefab)
	{

	}

	public override void OnClickPressed()
	{
		if(CastToFloor())
		{
			Waypoint toDelete = editor.GetWaypointAtGrid(Grid.PosToGrid(floorHit.point, 1.0f));

			if(toDelete != null && toDelete.gameObject.tag != "Start" && toDelete.gameObject.tag != "End")
			{
				editor.DeleteNode(toDelete);
				scorer.CurrentScore += 100;
			}
		}
	}
}