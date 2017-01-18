using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myScoreText : MonoBehaviour {

	objScreenPosition scrPosRef;

	void Start () {
		scrPosRef = GameObject.Find ("Character").gameObject.GetComponent<objScreenPosition> ();
	}

	void Update () {
		gameObject.GetComponent<Text>().text = "Score: "+ scrPosRef.myScore;
	}
}
