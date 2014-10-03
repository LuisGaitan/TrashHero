using UnityEngine;
using System.Collections;

public class IntroSplash : MonoBehaviour
{
	public float fadeSpeed;
	
	float opacity;
	bool start = true;
	
	
	// Use this for initialization
	void Start ()
	{
		Screen.SetResolution (573, 717, false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(start)
		{
			opacity = Mathf.Lerp (0f, 1f, fadeSpeed * Time.time);
		}
		if(!start)
		{
			opacity = Mathf.Lerp (1f, 0f, fadeSpeed * Time.time);
		}
		
		renderer.material.color = new Color(1, 1, 1, opacity);
		
		if(!start && opacity == 0)
		{
			Application.LoadLevel (1);
		}
	}
	
	void OnGUI()
	{
		if(opacity == 1)
		{
			if(GUI.Button (new Rect((Screen.width - 100) / 2, Screen.height - 100, 100, 25), "Coninue"))
			{
				start = false;
			}
		}
	}
}
