using UnityEngine;
using System.Collections;

public class RunAway : MonoBehaviour {

	public bool male;
	private bool started;
	float runAwayTime = 30f;
	// Use this for initialization
	void Start () {
		started = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartRunning() {
		if(!started) {
			transform.Rotate(new Vector3(0, 180, 0));
			GetComponent<Animator>().SetBool("Male", male);
			GetComponent<Animator>().SetTrigger("omw");
			StartCoroutine(RanSoFarAway());
		}
	}

	IEnumerator RanSoFarAway() {
		while(runAwayTime > 0) {
			transform.Translate(Vector3.forward * Time.deltaTime);
			runAwayTime -= Time.fixedDeltaTime;
			yield return null;
			}
	}
}
