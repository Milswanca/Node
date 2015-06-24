using UnityEngine;
using System.Collections;

public class End : MonoBehaviour 
{
	private Player player;
	private Scorer scorer;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		scorer = GameObject.FindGameObjectWithTag ("Manager").GetComponent<Scorer> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			scorer.LocallySaveScore();
			scorer.SaveHighScores();
			player.WinGame();
		}
	}
}
