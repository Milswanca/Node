using UnityEngine;
using System.Collections;

public class BtnStop : MonoBehaviour {
	
	private Player player;
	
	public void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
	}
	
	public void Clicked()
	{ 
		player.Reset ();
	}
}
