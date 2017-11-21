using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	//Public movement vars
	public float speed = 10;
	public float jumpForce = 10;
	public float castDist;
	//Behind the scenes movement/input vars
	private float hInput;
	private float vInput;
	private Vector3 movement;
	private bool jumpInput;
	private bool hasControl = false;
	//Declare references
	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		StartCoroutine (DisableControlForSeconds (2));
	}

	void Update(){
		//Debug.DrawRay (transform.position, Vector2.down, Color.green);
		if(Input.GetButtonDown("Jump") && hasControl){
			if (Physics.Raycast (transform.position, Vector3.down, castDist)) {
				jumpInput = true;
			}
		}
	}
		
	void FixedUpdate(){
		hInput = Input.GetAxisRaw ("Horizontal");
		vInput = Input.GetAxisRaw ("Vertical");
		movement = new Vector3 (hInput, 0, vInput).normalized;

		if (hasControl) {
			rb.AddForce (movement * speed);
		}

		if (jumpInput) {
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			jumpInput = false;
		}
	}

	IEnumerator DisableControlForSeconds(int seconds){
		hasControl = false;
		yield return new WaitForSeconds (seconds);
		hasControl = true;
	}

}
