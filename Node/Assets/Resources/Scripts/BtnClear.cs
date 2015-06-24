using UnityEngine;
using System.Collections;

public class BtnClear : MonoBehaviour 
{
	private Editor editor;
	private Player player;
	
	void Start()
	{
		editor = GameObject.FindGameObjectWithTag ("Player").GetComponent<Editor> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
	
	public void Clicked()
	{
		editor.Reset();
		player.Reset();
	}
}
