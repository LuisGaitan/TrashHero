using UnityEngine;
using System.Collections;

public class TrashController : MonoBehaviour
{
	public Camera cam;
	GameObject trash;
	public bool hold = false;
//	public float l1Speed = 0.5f, l2Speed = 1f;
	public float[] levelSpeed;
	float moveSpeed = 0.5f;
	public float destroyTime = 0.5f;
	
	private float maxWidth;
	private float maxHeight;
	
	float trashWidth;
	float trashHeiight;
	Vector3 targetSize;
	int level;
	
	ScoreKeeper scoreKeeper;
	
	
	void Start ()
	{
		if (cam == null)
			cam = Camera.main;
		
		scoreKeeper = GameObject.Find ("[Master]").GetComponent<ScoreKeeper> ();
		
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0f);
		targetSize = cam.ScreenToWorldPoint (upperCorner);
		trashWidth = renderer.bounds.extents.x;
		trashHeiight = renderer.bounds.extents.y;

		level = Application.loadedLevel;
		Debug.Log (level);
		moveSpeed = levelSpeed[level - 2];
		
//		if (Application.loadedLevel == 1)
//			moveSpeed = l1Speed;
//		else if (Application.loadedLevel == 2)
//			moveSpeed = l2Speed;
		
	}
	
	void Update()
	{
		if(Input.GetMouseButtonUp(0))
		{
			hold = false;
		}
	}
	
	void OnMouseDown()
	{
		hold = true;
	}
	void OnMouseUp()
	{
		hold = false;
	}
	
	void FixedUpdate ()
	{
		if(hold)
		{
			maxWidth = targetSize.x - trashWidth;
			maxHeight = targetSize.y - trashHeiight;
			Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
			Vector3 targetPosition = new Vector3 (rawPosition.x, rawPosition.y, 0);
			float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
			float targetHeight = Mathf.Clamp (targetPosition.y, -maxHeight, maxHeight);
			
			targetPosition = new Vector3 (targetWidth, targetHeight, targetPosition.z);
			//			trash.rigidbody.MovePosition (targetPosition);
			rigidbody.MovePosition (targetPosition);
		}
		else
		{
			transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "TrashCan")
		{
			Destroy (gameObject, destroyTime);
		}
		else if(collision.gameObject.tag == "Ground")
		{
			Destroy (gameObject, destroyTime);
			scoreKeeper.score -= 2;
		}
	}
}
