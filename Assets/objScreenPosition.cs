using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objScreenPosition : MonoBehaviour {

	public Transform target;
	public Camera[] cameraList;
	//public Camera cameraList2;
	Vector2[] screenPosList;
	int arrayLength;
	Vector2[] imgPosList;
	int imgLength;
	Transform canvasCheck;
	public int myScore=0;

	void Start() {
		//target = GameObject.Find ("Character").transform;
		//cameraList1 = GameObject.Find("Camera (5)").GetComponent <Camera>();
		//cameraList2 = GameObject.Find("Camera (1)").GetComponent <Camera>();
		arrayLength = cameraList.Length;
		screenPosList = new Vector2[arrayLength];
		canvasCheck = GameObject.Find ("Canvas").transform;
	}

	void getScreenPos(Camera cam, int i){
		Vector3 screenPoint = cam.WorldToViewportPoint (target.position);
		bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.y > 0 && screenPoint.x < 1 && screenPoint.y < 1;
		if (onScreen) {
			Vector3 screenPos = cam.WorldToScreenPoint (target.position);
			screenPosList [i] = new Vector2(screenPos.x, screenPos.y);
			//Debug.Log ("target screen position is " + screenPosList [i]);
			for (int j = 0; j < imgLength; j++) {
				if (Mathf.Abs ((imgPosList [j] - screenPosList [i]).magnitude)< 100f) {
					Destroy (canvasCheck.GetChild(j).gameObject);
					myScore++;

				}
				//Debug.Log (Mathf.Abs ((imgPosList [j] - screenPosList [i]).magnitude));
			}
		} else {
			screenPosList [i] = new Vector2(-1,-1);
			//Debug.Log ("Not on screen");
		}
	}

	void getImgPosList(){
		imgLength = canvasCheck.childCount;
		imgPosList = new Vector2[imgLength];
		for (int i = 0; i < imgLength; i++) {
			imgPosList [i] = canvasCheck.GetChild (i).GetComponent<objGUIMovement>().imgScrPos;
		}
	}

	void Update() {
		getImgPosList ();
		for (int i=0; i<arrayLength; i++){
			getScreenPos (cameraList[i], i);
		}

		//getScreenPos (cameraList[1], 1);
		//Debug.Log (screenPosList.Length);
		//marginX = new Vector2(cameraList.rect.xMin*Screen.currentResolution.width, cameraList.rect.xMax*Screen.currentResolution.width);
		//Debug.Log(cameraList.rect.x);
		//Debug.Log(Screen.currentResolution);
	}
}