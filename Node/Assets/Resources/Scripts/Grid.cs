using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour 
{
	public static Vector2 PosToGrid(Vector3 pos, float gridSize)
	{
		Vector2 grid = new Vector2 ();

		grid.x = Mathf.Round(pos.x / gridSize)  * gridSize;
		grid.y = Mathf.Round(pos.z / gridSize)  * gridSize;

		return grid;
	}

	public static Vector3 GridToPos(Vector2 grid, float gridSize)
	{
		Vector3 pos = new Vector3 ();
		pos.x = grid.x * gridSize;
		pos.y = 0;
		pos.z = grid.y * gridSize;

		return pos;
	}

	public static Vector3 SnapToGrid(Vector3 pos, float gridSize)
	{
		Vector3 position = pos;

		position.x = Mathf.Round(position.x / gridSize)  * gridSize;
		position.y = 0;
		position.z = Mathf.Round(position.z / gridSize)  * gridSize;

		return position;
	}
}
