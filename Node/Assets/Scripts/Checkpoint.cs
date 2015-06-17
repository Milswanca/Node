using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum action {MOVE};

public class Checkpoint : MonoBehaviour {
	[System.Serializable]
	public class ActionEntry
	{
		public action Action;
		public GameObject GameObject;
		public Vector3 Position;
	}

	public ActionEntry[] Actions;

	void OnTriggerStay(Collider other) 
	{
		if (other.gameObject.tag == "Player") 
		{
			DoActions();
		}
	}

	void DoActions()
	{
		foreach(ActionEntry i in Actions)
		{
			if(i.Action == action.MOVE)
			{
				i.GameObject.transform.position = Vector3.Lerp(i.GameObject.transform.position, i.Position, Time.deltaTime);
			}
		}
	}
}
