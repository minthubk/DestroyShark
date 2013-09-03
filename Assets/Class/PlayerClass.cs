using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {
	
	public static int score = 0;
	
	public float speed;
	public GameObject bombPrefab;
	
	public GameObject mainCamera;
	public GameObject gameBackground;
	public float nextZ = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.x > 18)
		{
			// get new speed.
			speed = Random.Range(8f, 12f);
			transform.position = new Vector3(-18f, transform.position.y, transform.position.z);
		}
		transform.Translate(0, 0, speed * Time.deltaTime);
		
		/**
		 * Input.anyKeyDown is true when a key is pressed, this happens only once 
		 * – i.e. when the button was first pressed; then Input.anyKeyDown is false again until another key is pressed. 
		 * anyKeyDown is actually a handy abstraction – it actually is true when a mouse button was clicked, keyboard 
		 * key was pressed or (!) a tap on the iPhone’s screen was received
		 */
		if (Input.anyKeyDown)
		{
			GameObject bombObject = (GameObject)Instantiate(bombPrefab);
			bombObject.transform.position = this.gameObject.transform.position;
			
			BombClass bomb = (BombClass)bombObject.GetComponent("BombClass");
			bomb.player = this;
		}
		
		if (nextZ > mainCamera.transform.position.z)
		{
			mainCamera.gameObject.transform.Translate(
				3 * Mathf.Sin(transform.position.z / 2) * Time.deltaTime,
				0,
				-Mathf.Sin(transform.position.z / 2) * Time.deltaTime * 0.3f
				);
			// Vector3.up -> Vector3 (0f, 1f, 0f); Rotate by the y axis.
			mainCamera.gameObject.transform.RotateAroundLocal(Vector3.up, Time.deltaTime * 0.1f);
			gameBackground.gameObject.transform.RotateAroundLocal(Vector3.up, Time.deltaTime * 0.1f);
		}
	}
	
	// This event handler “OnGUI” is getting called on every frame on the GUI layer. 
	// So, you draw everything you need on the GUI in here.
	void OnGUI()
	{
		GUIStyle style = new GUIStyle();
		style.fontSize = 20;
		GUI.Label(new Rect(10, 10, 100, 20), "Score: " + PlayerClass.score, style);
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
		
		if (PlayerClass.score > 0)
		{
			nextZ = PlayerClass.score * 2.5f;
		}
	}
}
