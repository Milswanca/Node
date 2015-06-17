using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextHighScore : MonoBehaviour {

	private Scorer scorer;
	private Text text;
	
	// Use this for initialization
	void Start () {
		scorer = GameObject.FindGameObjectWithTag ("Manager").GetComponent<Scorer>();
		text = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "HighScore: " + scorer.HighScores[scorer.CurrentLevel].score;
	}
}
