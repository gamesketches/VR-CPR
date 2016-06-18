﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputScript : MonoBehaviour {

	Animator theAnimator;
	private int compressionsDone;
	int counter;
	AudioSource audio;
	bool success;
	public Text compressionCounter;
	public int marginOfError = 3;
	public int beatsPerSecond;

	// Use this for initialization
	void Start () {
		theAnimator = GetComponent<Animator>();
		audio = GetComponent<AudioSource>();
		compressionsDone = 0;
		counter = 0;
		success = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;
		if(counter == beatsPerSecond) {
			audio.Play();
		}
		if(counter > beatsPerSecond + marginOfError) {
			counter = 0;
			if(success) {
				compressionsDone++;
				if(compressionsDone >= 30) {
						Debug.Log("he's dead jim");
						}
			}
			else {
				compressionsDone = 0;
				Debug.Log("too late!");
			}
			success = false;
			compressionCounter.text = compressionsDone > 9 ? compressionsDone.ToString() : " " + compressionsDone.ToString();
		}
		else {
			if(Input.GetKeyDown(KeyCode.Space)){ 
				theAnimator.SetTrigger("Compression");
				if(counter > beatsPerSecond - marginOfError) {
					Debug.Log("nice");
					success = true;
				}
				else {
					Debug.Log("too early");
				}
			}
		}
	}
}
