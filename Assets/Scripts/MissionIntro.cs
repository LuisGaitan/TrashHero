using UnityEngine;
using System.Collections;

public class MissionIntro : MonoBehaviour
{
	public float offset;
	public Texture[] tips;
	public Texture DYK;
	
	Rect tipRect;
	Rect btnRect;
	bool showTip = true;
	int tipNum = 0;

	TrashSpawn trashSpawn;
	
	// Use this for initialization
	void Start ()
	{
		trashSpawn = GameObject.Find ("[Master]").GetComponent<TrashSpawn>();

		tipRect = new Rect (-12, (Screen.height - 200) / 2, Screen.width + 24, 200);
		btnRect = new Rect ((Screen.width - 100) / 2, Screen.height - 100, 100, 25);
		Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI()
	{
		if(showTip)
		{
			string btnTxt = "Next";

			if(tipNum == tips.Length - 1)
				btnTxt = "Start";
			else
				btnTxt = "Next";

			GUI.Box (new Rect(0, 0, Screen.width, Screen.height), "");
			GUI.Box (new Rect(0, 0, Screen.width, Screen.height), "");
			GUI.DrawTexture (tipRect, tips[tipNum]);

			if(GUI.Button (btnRect, btnTxt))
			{
				if(tipNum < tips.Length - 1)
				{
					tipNum++;
				}
				else
				{
					showTip = false;
					trashSpawn.Spawn ();
					GetComponent<ScoreKeeper>().enabled = true;
				}
			}
		}
		if(ScoreKeeper.endLevel)
		{
			GUI.Box (new Rect(0, 0, Screen.width, Screen.height), "");
			GUI.Box (new Rect(0, 0, Screen.width, Screen.height), "");
			GUI.DrawTexture (tipRect, DYK);

			if(GUI.Button (btnRect, "Next"))
			{
				ScoreKeeper.endLevel = false;
				Application.LoadLevelAsync (Application.loadedLevel + 1);
			}
		}
	}
}
