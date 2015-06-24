using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicAgent : MonoBehaviour {

	private int currentNode;
	private Vector3 facing;

	private Player player;

	public List<Transform> path;
	public float Speed;

	// Use this for initialization
	void Start () {
		currentNode = 0;
		facing = new Vector3 (1, 0, 0);

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.rotation = Quaternion.LookRotation (facing);

		if (this.path.Count > 0 && path[currentNode] != null) 
		{
			Vector3 move = path[currentNode].position - transform.position;
			move.Normalize();

			facing = move; 
			
			transform.position += move * Speed * Time.deltaTime;
			
			if(Vector3.Distance(this.path[currentNode].position, this.transform.position) < 0.2)
			{
				currentNode++;
			}

			if(currentNode > path.Count - 1)
				currentNode = 0;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			player.LoseGame();
			Speed = 0;
		}
	}
}
