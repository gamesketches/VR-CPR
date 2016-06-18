﻿using UnityEngine;
using System.Collections;

public class MicTest : MonoBehaviour {

	public static float MicLoudness;

	private string _device;

	private AudioClip _clipRecord = new AudioClip();
	int _sampleWindow = 128;

	bool _isInitialized;

	void InitMic() {
		if(_device == null) _device = Microphone.devices[0];
		_clipRecord = Microphone.Start(_device, true, 999, 44100);
	}

	void StopMicrophone() {
		Microphone.End(_device);
	}

	float LevelMax() {
		float levelMax = 0;
		float[] waveData = new float[_sampleWindow];
		int micPosition = Microphone.GetPosition(null)-(_sampleWindow+1);
		if(micPosition < 0) return 0;
		_clipRecord.GetData(waveData, micPosition);
		for(int i = 0; i < _sampleWindow; i++) {
			float wavePeak = waveData[i] * waveData[i];
			if(levelMax < wavePeak) {
				levelMax = wavePeak;
			}
		}
		return levelMax;
	}


	// Use this for initialization
	void Awake () {
		_isInitialized = false;
	}
	
	// Update is called once per frame
	void Update () {
		MicLoudness = LevelMax();
		Debug.Log(MicLoudness);
	}

	void OnApplicationFocus(bool focus) {
		if(focus) {
			if(!_isInitialized) {
				Debug.Log("initializing");
				InitMic();
				_isInitialized = true;
			}
		}
		if(!focus) {
			StopMicrophone();
			_isInitialized = false;
		}
	}
}
