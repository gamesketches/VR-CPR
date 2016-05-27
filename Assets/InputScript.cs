using UnityEngine;
using System.Collections;

public class InputScript : MonoBehaviour {

	Animator theAnimator;
	// Use this for initialization
	void Start () {
		theAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){ 
			theAnimator.SetTrigger("Compression");
			Debug.Log("compression!");
		}
	}
}
