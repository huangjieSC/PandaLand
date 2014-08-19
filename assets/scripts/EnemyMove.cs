using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	
	public float moveSpeed = 5;
	GameObject player;
	public float health = 500;
	public float decreHealth = 10;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void GoTowardsPlayer(){
		transform.LookAt(player.transform);
		Vector3 tempEulerAngles = transform.eulerAngles;
		tempEulerAngles.x = 0;
		tempEulerAngles.z = 0;
		transform.eulerAngles = tempEulerAngles;
		
		transform.Translate(moveSpeed*transform.forward*Time.deltaTime, Space.World);
	}	
	
	void OnCollisionEnter(Collision colliInfo){
		if(colliInfo.gameObject.tag == "Ball")
		{
			health -= decreHealth;
		}
	}
	
	
}
