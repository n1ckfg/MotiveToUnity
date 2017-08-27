using UnityEngine;
using System.Collections;

public class Calibrator : MonoBehaviour {

	public OptitrackRigidBody optitrackRigidBody;

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyUp(KeyCode.C)) {
			Vector3 rot = optitrackRigidBody.GetRotationEuler();
		}
	}
}
