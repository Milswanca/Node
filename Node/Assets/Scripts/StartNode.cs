using UnityEngine;
using System.Collections;

public class StartNode : MonoBehaviour {

	public GameObject PlayerPrefab;

	// Use this for initialization
	void Awake () {
		Instantiate (PlayerPrefab, this.transform.position, new Quaternion ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
