using UnityEngine;
using System.Collections;

public class MenuPlay : MonoBehaviour {
	
	// Use this for initialization
	public void Start () {
		
	}
	
	// Update is called once per frame
	public void Clicked()
	{
		Application.LoadLevel ("LevelSelect");
	}
}
