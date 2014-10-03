using UnityEngine;
using System.Collections;

public class EndExit : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 1f;
		Invoke ("Exit", 5f);
	}
	
	// Update is called once per frame
	void Exit ()
	{
		Application.Quit ();
	}
}
