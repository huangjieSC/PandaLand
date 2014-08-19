using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
	
	public float lookSpeed = 30;
	public GameObject cameraObj;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Look(){
		
		transform.Rotate(Vector3.up, lookSpeed*Time.deltaTime*Input.GetAxis("Mouse X"),Space.World);
		cameraObj.transform.Rotate(Vector3.right, -lookSpeed*Time.deltaTime*Input.GetAxis("Mouse Y"));				
	}
	
}

