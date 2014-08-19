using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour {
	public List<GameObject> target;
	public GameObject curTarget;
	public double Timer = 0.5;
	public int bullets = 500;
	
	// new 1004
	public float throwPower = 8000;
	public GameObject cameraObj;
	public GameObject throwObj;
	
	//public float attackTimer;
	public float coolDown;
	
	public bool isHit;
	
	// Use this for initialization
	void Start () {
		//attackTimer = 0;
		coolDown = 0.5f;
		
		target = new List<GameObject>();
		GameObject[] go = GameObject.FindGameObjectsWithTag("MyEnemy");
		
		for(int i = 0; i < go.Length; i++){
			target.Add(go[i]);	
		}
	}
	
	// Update is called once per frame
	void Update () {
		// int j = 0;
		
		if(Input.GetKey(KeyCode.Tab)){
			/*if(curTarget == null)
			{	while(curTarget == null)
				{
					curTarget = target[j];
					j++;
			}	
			}*/
			if(curTarget == null) // 1004 add target[0] != null
				curTarget = target[0];
			if(curTarget == target[target.Count - 1])
				curTarget = target[0];
			else
				curTarget = target[target.IndexOf(curTarget)+1];
		}
		
		if(Timer > 0){
			Timer -= Time.deltaTime;
		}
		if(Timer < 0){
			Timer = 0;
		}
		
		if(Input.GetKey(KeyCode.F) && Timer == 0 && bullets != 0 && (!transform.GetComponent<PlayerHealth>().dead)){
			Attack();
			Timer = coolDown;
		/*	curTarget.transform.GetComponent<EnemyHealth>().AdjustCurrentHealth(50);
		*/	
			bullets--;
			//Timer = 1;
		}	
	}
	
	private void Attack(){
		if(curTarget != null)
		{	
			float distance = Vector3.Distance(curTarget.transform.position, transform.position);
			Vector3 dir = (curTarget.transform.position - transform.position).normalized;
			float direction = Vector3.Dot(dir,transform.forward);
		
			Debug.Log(direction);
			
			ThrowObject(); // 1011 new
			/*
			if(distance < 100)
			{	if(direction > 0)
				{
					//Debug.DrawLine(curTarget.transform.position, transform.position,Color.yellow); // target at enemy
					ThrowObject();
					//curTarget.transform.GetComponent<EnemyHealth>().AdjustCurrentHealth(50);
				}
			}
			*/ // 1011
		}
	}
	
	
	void ThrowObject(){
		
		
			GameObject newObj = Instantiate(throwObj, 
								transform.forward*3 + transform.position, Quaternion.identity) as GameObject;
			newObj.rigidbody.AddForce(cameraObj.transform.forward*throwPower);
		
	}
	
	// 1011 new add
	
	void OnCollisionEnter(Collision colliInfo)
	{
		isHit = true;
		//AdjustCurrentHealth(50);
		 transform.GetComponent<PlayerHealth>().AdjustCurrentHealth(25);
	}
	
	void OnCollisionExit(Collision colliInfo)
	{
		isHit = false;
	}
	
}













