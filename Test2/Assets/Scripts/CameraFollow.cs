using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is attached to a camera and follows the target player, which must be assigned in editor.
public class CameraFollow : MonoBehaviour {
	public Transform target;
	private Vector3 velocity = Vector3.zero;
	private CameraOffsets offsets;

	void Start(){
		offsets.baseOffset = new Vector3(0, 10, -15);
		offsets.topDownOffset = new Vector3 (0, 20, 0);
		offsets.closeUpOffset = new Vector3 (0, 0, -10);
		transform.position = target.position + offsets.topDownOffset;

	}


	//Player is being moved in the PlayerController FixedUpdate(), so the camera must be moved in FixedUpdate() as well.
	void FixedUpdate(){
		if (Time.timeSinceLevelLoad >= 2){
			transform.position = Vector3.SmoothDamp (transform.position, target.position + offsets.baseOffset, ref velocity, .3f);
		}
			
		transform.LookAt (target.position);
	}

	//This struct holds all offsets used by the camera in relation to the player object.
	private struct CameraOffsets{
		public Vector3 baseOffset;
		public Vector3 topDownOffset;
		public Vector3 closeUpOffset;
	}
		
}
