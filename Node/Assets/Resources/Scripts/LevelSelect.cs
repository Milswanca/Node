using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

	public string GoTo;
	public int StartScore;
	public int MaxScore;
		
	private Text text;
	private Scorer scorer;

	// Use this for initialization
	void Start () {
		text = transform.FindChild("Score").GetComponent<Text>();
		scorer = GameObject.FindGameObjectWithTag ("Manager").GetComponent<Scorer>();

		text.text = scorer.HighScores [GoTo].score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Clicked()
	{
		scorer.CurrentLevel = GoTo;
		scorer.CurrentScore = StartScore;
		Application.LoadLevel (GoTo);
	}
}
