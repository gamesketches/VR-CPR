using UnityEngine;
using System.Collections;

public class ReticleTriggerCheck : MonoBehaviour {

	public bool CorrectCompressionPoint;
	// Use this for initialization
	void Start () {
		CorrectCompressionPoint = false;
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "reticle")
		{
			CorrectCompressionPoint = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "reticle") {
			CorrectCompressionPoint = false;
		}
	}

}
