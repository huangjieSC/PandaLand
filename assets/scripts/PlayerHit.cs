using UnityEngine;
using System.Collections;

public class PlayerHit : MonoBehaviour {
	public Transform target;
	public bool isHit;
	
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("MePlayer").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(isHit == true)
			target.GetComponent<PlayerHealth>().AdjustCurrentHealth(50);
	}
	
	void OnCollisionEnter(Collision colliInfo)
	{
		isHit = true;
		//target.GetComponent<PlayerHealth>.;
		 // transform.GetComponent<PlayerHealth>().AdjustCurrentHealth(50);
	}
	
	void OnCollisionExit(Collision colliInfo)
	{
		isHit = false;
	}
	
}
