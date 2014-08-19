using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {
	
	bool doorIsOpen = false;
	float doorTimer = 0.0f;
	GameObject currentDoor;
	public float doorOpenTime = 3.0f;
	public AudioClip doorOpenSound;
	public AudioClip doorShutSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(doorIsOpen){
			doorTimer += Time.deltaTime/2;
		if(doorTimer > doorOpenTime){
			ShutDoor(currentDoor);
			doorTimer = 0.0f;
		}
}
	
	}
	void OnControllerColliderHit(ControllerColliderHit hit){
		if(hit.gameObject.tag == "playerDoor" && doorIsOpen == false){
			currentDoor = hit.gameObject;
			OpenDoor(currentDoor);
		}
	}
	
	void OpenDoor(GameObject door){
		doorIsOpen = true;
		
		door.transform.parent.animation.Play("doorshut");
		door.audio.PlayOneShot(doorOpenSound);
	}
	void ShutDoor(GameObject door){
		doorIsOpen = false;
		door.audio.PlayOneShot(doorShutSound);
		door.transform.parent.animation.Play("doorshut");
	}
}
