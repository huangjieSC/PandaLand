using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour {
public float moveSpeed = 20;
	public float jumpForce = 500;
	bool isTouchingGround;
	
	// Use this for initialization, do not use constructors. important: polymorphism
	void Start () {
		isTouchingGround = false;
	}
	
	// Update is called once per frame， game loop
	void Update () {
	
	}
	
	void KeyMovement(){
		//move at that direction at that speed with that delta time
//		Vector3 moveVect = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//		moveVect *= (moveSpeed*Time.deltaTime); //always adjust Time.deltaTime whenever you have movements in your game
//		transform.Translate(moveVect); //rotate, move, scale: use transform 
		
		if(Input.GetKey(KeyCode.Space) && isTouchingGround)
		{
			rigidbody.AddForce(Vector3.up*jumpForce);	
		}
	}
	
	void OnCollisionEnter(Collision colliInfo){
		if(colliInfo.gameObject.tag == "Ground")
		{
			isTouchingGround = true;	
		}
	}
	
	void OnCollisionExit(Collision colliInfo){
		if(colliInfo.gameObject.tag == "Ground")
		{
			isTouchingGround = false;	
		}
	}
}
