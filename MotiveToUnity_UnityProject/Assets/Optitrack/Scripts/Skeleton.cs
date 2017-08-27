/*
0. Bone393217 = hips
1. Bone393218 = spine1
2. Bone393219 = spine2
3. Bone393220 = neck
4. Bone393221 = head
5. Bone393222 = l_clavicle
6. Bone393223 = l_shoulder
7. Bone393224 = l_elbow
8. Bone393225 = l_hand
9. Bone393226 = r_clavicle
10. Bone393227 = r_shoulder
11. Bone393228 = r_elbow
12. Bone393229 = r_hand
13. Bone393230 = l_hip
14. Bone393231 = l_knee
15. Bone393232 = l_foot
16. Bone393233 = l_toe
17. Bone393234 = r_hip
18. Bone393235 = r_knee
19. Bone393236 = r_foot
20. Bone393237 = r_toe
*/

using UnityEngine;
using System.Collections;

public class Skeleton : MonoBehaviour {

	public OptitrackRigidBodyManager optitrackRigidBodyManager;
	public bool debug = true;
	public int startNumber = 1;
	public bool rootMotion = true;
	public int rootJoint = 1;
	public float floor = 1f;
	public OptitrackRigidBody[] target;
	public Transform[] retarget;

	// Use this for initialization
	void Start() {
		showCubesHandler(debug);

		for (int i=0; i<target.Length; i++) {
			if (target[i] != null) target[i].ID = startNumber + i;
		}
	}
	
	// Update is called once per frame
	void Update() {
		if (debug) {
			if (optitrackRigidBodyManager != null) {
				for (int i=0; i<optitrackRigidBodyManager.rigidBodyIDs.Length; i++) {
					Debug.Log(optitrackRigidBodyManager.rigidBodyIDs[i]);
				}
			}
		}

		for (int i=0; i<retarget.Length; i++) {
			if (retarget[i] != null) {
				if (i==rootJoint) retarget[i].position = new Vector3(target[i].transform.position.x, target[i].transform.position.y + floor, target[i].transform.position.z);
				retarget[i].rotation = target[i].transform.rotation;
			}
		}
	}

	void showCubesHandler(bool _b) {
		for (int i=0; i<target.Length; i++) {
			target[i].GetComponent<Renderer>().enabled = _b;
		}
	}

}
