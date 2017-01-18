using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objGUIMovement : MonoBehaviour {

	public float speed = 100f;
	float randomX;
	float halfCanvasWidth;
	float halfCanvasHeight;
	public Vector2 imgScrPos;

	void Start()
	{
		halfCanvasWidth = Screen.currentResolution.width/2-50f;
		randomX = Random.Range(-halfCanvasWidth, halfCanvasWidth);
		halfCanvasHeight = Screen.currentResolution.height/2+50f; 
		transform.localPosition = new Vector3(randomX, halfCanvasHeight, 0);
		//Debug.Log (Screen.currentResolution.width);
	}



	void Update()
	{
		if (speed != 0)
		{
			float yPos = transform.localPosition.y - speed * Time.deltaTime;
			transform.localPosition = new Vector3(randomX, yPos, 0);
			imgScrPos = new Vector2 (randomX+halfCanvasWidth, yPos+halfCanvasHeight);

			//Debug.Log (transform.localPosition);

			if (transform.localPosition.y < -halfCanvasHeight)
			{
				Destroy(gameObject);
			}
		}
	}
}
