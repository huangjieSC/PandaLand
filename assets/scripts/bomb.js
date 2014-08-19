#pragma strict

function Start () {
	
}

var moveSpeed:float = 10.0;
var turnSpeed:float = 10.0;
var jumpSpeed:float = 10.0;
 
function Update () {
	/*
	if(Input.GetButtonDown("Jump"))
	{
		transform.position.z += 1.0;
	}
	
	*/
	if(Input.GetButton("forward"))
	{
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}
	
	if(Input.GetButton("backward"))
	{
		transform.position += -transform.forward * moveSpeed * Time.deltaTime;
	}
	if(Input.GetButton("left"))
	{
		transform.eulerAngles.y += -turnSpeed * Time.deltaTime;
	}
	if(Input.GetButton("right"))
	{
		transform.eulerAngles.y += turnSpeed * Time.deltaTime;
	}
	
	/*
	if(Input.GetButton("jump1"))
	{
		 transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
	}
	*/
}

	function OnCollisionStay(collision : Collision) {
		// Check if the collider we hit has a rigidbody
		// Then apply the force
		if (collision.rigidbody) {
			collision.rigidbody.AddForce (Vector3.up * 15);
		}
	}
	
