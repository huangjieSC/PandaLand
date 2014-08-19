using UnityEngine;
using System.Collections;

public class ThrowObj : MonoBehaviour {
	
	public float throwPower = 5000;
	// public GameObject cameraObj; // 1011
	public GameObject throwObj;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ThrowObject();
	}
	
	void ThrowObject(){
		if(Input.GetMouseButtonDown(0))
		{
			GameObject newObj = Instantiate(throwObj, 
								transform.forward*2 + transform.position, Quaternion.identity) as GameObject;
			// newObj.rigidbody.AddForce(cameraObj.transform.forward*throwPower); //1011
			newObj.rigidbody.AddForce(transform.forward*throwPower);
		}
	}
}
