using UnityEngine;
using System.Collections;

public class TrashCanControll : MonoBehaviour
{
	public GameObject lid;
	public string acceptTag;
	public float time;

	bool played = false;

	ScoreKeeper scoreKeeper;

	// Use this for initialization
	void Start ()
	{
		scoreKeeper = GameObject.Find ("[Master]").GetComponent<ScoreKeeper> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(TrashSpawn.spawn && !played)
		{
			lid.animation.Play ();
			played = true;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == acceptTag)
		{
			scoreKeeper.score += 5;
		}
		else
		{
			scoreKeeper.score -= 2;
		}
	}
}
