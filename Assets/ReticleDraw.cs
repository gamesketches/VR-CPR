using UnityEngine;
using System.Collections;

public class ReticleDraw : MonoBehaviour {

	public float rayLength = 100f;
	private GameObject compressionReticle;
	private Quaternion reticleRotation;
	// Use this for initialization
	void Start () {
		reticleRotation = Quaternion.Euler(90, 0, 0);
		compressionReticle = (GameObject)Instantiate(Resources.Load<GameObject>("CompressionReticle"), new Vector3(100, 100, 100), reticleRotation);
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = new Ray(transform.position, transform.forward);

		if(Physics.Raycast(ray, out hit, rayLength)){
			if(hit.collider.gameObject.tag == "torso") {
				compressionReticle.transform.position = hit.point;
			}
			else {
			Debug.Log(hit.collider.gameObject.tag);
				compressionReticle.transform.position = new Vector3(100, 100, 100);
			}
		}
		Debug.DrawRay(transform.position, transform.forward * rayLength);
	}
}
