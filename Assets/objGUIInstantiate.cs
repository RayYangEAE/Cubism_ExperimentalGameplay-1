using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objGUIInstantiate : MonoBehaviour {

	public GameObject objGUI;

	void Start () {
		StartCoroutine(Instantiateobj());
	}

	IEnumerator Instantiateobj()
	{
		for (int i=0; i<100; i++){
			Instantiate (objGUI, transform);
			yield return new WaitForSeconds (Random.Range(1f,3f));
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
