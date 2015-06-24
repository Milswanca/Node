using UnityEngine;
using System.Collections;

public class BtnPlay : MonoBehaviour 
{
	private Player player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	public void Clicked()
	{
		player.traversing = true;
	}

	void Update()
	{
		if (player.traversing) 
		{
			//function = stop
		} 
		else 
		{
			//function = traverse
		}
	}
}
