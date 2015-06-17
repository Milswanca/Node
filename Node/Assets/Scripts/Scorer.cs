using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Scorer : MonoBehaviour {

	[System.Serializable]
	public class ScoreEntry
	{
		public int score;

		public ScoreEntry(int s)
		{
			score = s;
		}
	};

	public Dictionary<string, ScoreEntry> HighScores = new Dictionary<string, ScoreEntry>();
	public string CurrentLevel = "";
	public int CurrentScore = 0;

	void Awake() {
		//Keep this object persistant
		DontDestroyOnLoad(transform.gameObject);

		for (int i = 0; i < 20; ++i) {
			string levelName = "Level" + i;
			HighScores[levelName] = new ScoreEntry(0);
		}
	
		LoadHighScores ();
	}

	void Start()
	{

	}

	public void LocallySaveScore()
	{
		if(CurrentScore > HighScores[CurrentLevel].score)
			HighScores [CurrentLevel] = new ScoreEntry (CurrentScore);
	}

	public void LoadHighScores()
	{
		if (File.Exists ("/Highscores.dat")) 
		{
			var b = new BinaryFormatter();
			var f = File.Open("/Highscores.dat", FileMode.Open);

			HighScores = (Dictionary<string, ScoreEntry>)b.Deserialize(f);
			f.Close();
		}
	}

	public void SaveHighScores()
	{
		var b = new BinaryFormatter ();
		var f = File.Create ("/Highscores.dat");
		b.Serialize (f, HighScores);
		f.Close ();
	}
}
