using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

	private int stage;
	private AudioClip[] instructions;
	AudioSource audioPlayer;
	public string currentTarget;
	private MicInput micInput;
	delegate void currentStageFunction();
	currentStageFunction[] stages;
	bool playerHasSpoken;
	// Use this for initialization
	void Start () {
		micInput = GetComponent<MicInput>();
		audioPlayer = GetComponent<AudioSource>();
		instructions = Resources.LoadAll<AudioClip>("Sounds");
		string currentTarget = null;
		stage = -1;
		stages = new currentStageFunction[] {stage0, stage1, stage2, stage3,
												stage4, stage5, stage6, stage7};
		nextStage();
	}
	
	// Update is called once per frame
	void Update () {
		stages[stage]();
	}

	void nextStage() {
		stage++;
		Debug.Log("Moving to stage " + stage.ToString());
		audioPlayer.clip = instructions[stage];
		audioPlayer.Play();
		playerHasSpoken = false;
	}

	void stage0() {
		if(micInput.MicLoudness > 1) {
			playerHasSpoken = true;
		}
		if(playerHasSpoken && micInput.MicLoudness < 0.5f) {
			nextStage();
		}
	}

	void stage1() {
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 100f)) {
			if(hit.collider.tag == "Bystander" && micInput.MicLoudness > 1) {
				playerHasSpoken = true;
				hit.collider.gameObject.GetComponent<RunAway>().StartRunning();
			}
		}
		if(playerHasSpoken && micInput.MicLoudness < 0.5f) {
			nextStage();
		}
	}

	void stage2() {
		if(currentTarget == "mouthTrigger"){
			nextStage();
		}
	}

	void stage3() {
		if(currentTarget == "mouthTrigger" && Input.GetAxis("Jump") != 0) {
			nextStage();
		}
	}
	void stage4() {
		if(currentTarget == "heartTrigger") {
			nextStage();
			// Begin metronome
		}
	}

	void stage5() {
		//if metronome.compressions > 30, next stage
	}

	void stage6() {
		// repeat last stage
	}

	void stage7() {
		// donezo
	}
}
