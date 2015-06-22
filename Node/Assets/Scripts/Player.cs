using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	//Traversing variables
	public float GridSize;
	public float Speed;
	public bool traversing;
	private Waypoint next;

	private Vector3 start;
	private Editor editor;

	private ParticleSystem[] particles;
	private Light playerLight;
	private Light mainLight;

	// Use this for initialization
	void Start () 
	{
		transform.position = Grid.SnapToGrid (transform.position, GridSize);
		next = this.GetComponent<Editor> ().Waypoints [0];

		start = transform.position;

		editor = GetComponent<Editor> ();

		particles = new ParticleSystem[2];
		particles[0] = transform.Find ("PartMain").GetComponent<ParticleSystem> ();
		particles[1] = transform.Find ("PartTail").GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (traversing) 
		{
			TraversePath();
		}
	}


	public void TraversePath()
	{
		if (next != null) 
		{
			Vector3 targetPos = next.GetComponent<Transform>().position;

			Vector3 move = targetPos - transform.position;
			move.Normalize ();

			transform.position += move * Speed * Time.deltaTime;

			if (Vector3.Distance (targetPos, this.transform.position) < 0.2) 
			{
				next = next.LinkedTo;
			}
		}
		else 
		{
			traversing = false;
		}
	}
		
	public void Reset()
	{
		transform.position = start;
		traversing = false;
		next = editor.GetWaypointAtGrid(Grid.PosToGrid(this.transform.position, 1.0f));
	}

	public void WinGame()
	{
		traversing = false;
		StartCoroutine (GoToRoom("LevelSelect"));
	}

	public void LoseGame()
	{
		traversing = false;
		StartCoroutine (GoToRoom("MainMenu"));
	}

	IEnumerator GoToRoom(string room)
	{
		particles [0].gravityModifier = -1;
		particles [1].gravityModifier = -1;
		yield return new WaitForSeconds(2);
		particles[0].Stop ();
		particles[1].Stop ();
		yield return new WaitForSeconds (3);
		Application.LoadLevel (room);
	}
}
