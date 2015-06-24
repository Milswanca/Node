using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour 
{
	public bool isMovable;
	public bool isHidden;
	public Waypoint LinkedTo;
	public Vector2 GridPos;

	void Start()
	{
		GridPos = Grid.PosToGrid (this.transform.position, 1.0f);
		if (isHidden) {
			gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
	}

	void Update()
	{
		this.transform.position = Grid.GridToPos (GridPos, 1.0f);
	}
}
