using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour
{
	public float levelLengthInSeconds = 30f;
	public float timeRemain;
	public int score = 0;

	public static bool endLevel = false;

	float counter;
	float timeSinceStart;
	bool started = false;
	
	// Use this for initialization
	void Start ()
	{
		timeSinceStart = Time.time;
		Invoke ("EndLevel", levelLengthInSeconds);
		timeRemain = levelLengthInSeconds;
		started = true;
		Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(started)
		{
			timeRemain = levelLengthInSeconds - Time.time + timeSinceStart;
			timeRemain = Mathf.Round (timeRemain);
		}
	}
	
	void EndLevel()
	{
		Time.timeScale = 0f;
		ScoreKeeper.endLevel = true;
	}
	
	void OnGUI()
	{
		GUI.Label (new Rect(0, 0, 100, 25), "Time: " + timeRemain);
		GUI.Label (new Rect(0, 25, 100, 25), "Score: " + score);
	}
}
