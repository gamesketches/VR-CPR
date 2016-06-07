using UnityEngine;
using System.Collections;

public class InputScript : MonoBehaviour {

	Animator theAnimator;
	private int compressionsDone;
	int counter;
	public int marginOfError = 3;
	public int beatsPerSecond;
	// Use this for initialization
	void Start () {
		theAnimator = GetComponent<Animator>();
		compressionsDone = 0;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(counter > 0) {
			counter++;
		}
		if(counter == beatsPerSecond) {
			Debug.Log("now");
		}
		if(counter > beatsPerSecond + marginOfError) {
			counter = 0;
			compressionsDone = 0;
			Debug.Log("bad timing");
		}
		else {
			if(Input.GetKeyDown(KeyCode.Space)){ 
				theAnimator.SetTrigger("Compression");
				if(counter > 0 && counter > beatsPerSecond - marginOfError) {
					compressionsDone++;
					if(compressionsDone >= 5) {
						Debug.Log("he's dead jim");
						}
				}
				else {
					counter = 1;
				}
			}
		}
	}
}
