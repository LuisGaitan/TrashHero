using UnityEngine;
using System.Collections;

public class TrashSpawn : MonoBehaviour
{
	//public GameObject spawn;
	public Camera cam;
	public GameObject[] trash;
	public float minTime;
	public float maxTime;
	public static bool spawn = false;

	float maxWidth;
	Vector3 targetSize;

//	GameObject obj;
	
	// Use this for initialization
	void Start ()
	{
		if (cam == null)
			cam = Camera.main;
//		obj = ObjectPooler.current.GetPooledObject ();
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0f);
		targetSize = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targetSize.x - .07f;

//		Spawn ();
	}

	public void Spawn()
	{
		if(!spawn)
			spawn = true;

		Debug.Log ("Spawn");
		float time = Random.Range (minTime, maxTime);
		int spawnType = Random.Range (0, trash.Length);
		float randX = Random.Range (-maxWidth, maxWidth);

		Instantiate (trash[spawnType], new Vector3(randX, 5f, 0f), Quaternion.identity);
		Invoke ("Spawn", time);
	}
}
