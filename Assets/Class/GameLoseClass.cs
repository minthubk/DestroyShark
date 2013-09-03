using UnityEngine;
using System.Collections;

public class GameLoseClass : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void updateScoreBy(int deltaScore)
	{
		PlayerClass.score += deltaScore;
		if (PlayerClass.score > 3)
		{
			Application.LoadLevel("WinScene");
		}
		else if (PlayerClass.score < -3)
		{
			Application.LoadLevel("LoseScene");
		}
	}
}
