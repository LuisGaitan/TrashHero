using UnityEngine;
using System.Collections;

public class GlobeControl : MonoBehaviour
{
	public float speed = 1;
	public string[] level;
	public Vector3[] areaRotation;
	
	int stage = 0;
	
	void Start ()
	{
		transform.eulerAngles = areaRotation[0];
	}
	
	void Update ()
	{
		Rotate ();
	}
	
	void OnGUI()
	{
		if(stage < areaRotation.Length - 1)
		{
			if(GUI.Button (new Rect(Screen.width - 110, Screen.height - 45, 100, 25), "Next"))
			{
				stage += 1;
			}
		}
		if(stage > 0)
		{
			if(GUI.Button (new Rect(10, Screen.height - 45, 100, 25), "Prev"))
			{
				stage -= 1;
			}

			if(GUI.Button (new Rect((Screen.width - 100 )/2, Screen.height - 80, 100, 25), "Play"))
			{
				Debug.Log (stage);
				Application.LoadLevel (stage + 1);
			}

			GUI.Box (new Rect((Screen.width - 200 )/2, 50, 200, 25), level[stage - 1]);
		}
	}
	
	void Rotate()
	{
		transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, areaRotation[stage], speed);
	}
}
