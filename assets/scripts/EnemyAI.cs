using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int turnSpeed;
	
	public bool isHit;
	public double Timer = 0.5;
	public int bullets = 500;
	public float coolDown;
	public GameObject throwObj;
	public float throwPower = 8000;
	
	private Transform myTransform;
	
	void Awake(){
		myTransform = transform;
	}
	
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("MePlayer").transform;
		
		isHit = false;
		coolDown = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.DrawLine(target.position, transform.position,Color.yellow);
		
		//look at target(player)
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), turnSpeed * Time.deltaTime);
		
		// if(Vector3.Distance(transform.position, target.position) > 3 && !transform.GetComponent<EnemyHealth>().dead)
		if(!transform.GetComponent<EnemyHealth>().dead)
		{
				// transform.position += transform.forward * moveSpeed * Time.deltaTime;
			GoTowardsPlayer();
			// 1011 new add
			if(Timer > 0){
				Timer -= Time.deltaTime;
			}
			if(Timer < 0){
				Timer = 0;
			}
			 // 1011 new add
			if(Timer == 0 && bullets != 0){
			Attack();
			Timer = coolDown;
		/*	curTarget.transform.GetComponent<EnemyHealth>().AdjustCurrentHealth(50);
		*/	
			bullets--;
			//Timer = 1;
		}	
		}
		
		if(transform.GetComponent<EnemyHealth>().dead) // new code 10/04
			Destroy(gameObject, 5); // destroy enemy object 5 sec after it is dead
	
	}
	
	void GoTowardsPlayer(){
		transform.LookAt(target.transform);
		Vector3 tempEulerAngles = transform.eulerAngles;
		tempEulerAngles.x = 0;
		tempEulerAngles.z = 0;
		transform.eulerAngles = tempEulerAngles;
		
		transform.Translate(moveSpeed*transform.forward*Time.deltaTime, Space.World);
	}	
	
	void OnCollisionEnter(Collision colliInfo)
	{
		isHit = true;
		transform.GetComponent<EnemyHealth>().AdjustCurrentHealth(25);
	}
	
	void OnCollisionExit(Collision colliInfo)
	{
		isHit = false;
	}
	
	
	private void Attack(){
		if(target != null)
		{	
			float distance = Vector3.Distance(target.transform.position, transform.position);
			Vector3 dir = (target.transform.position - transform.position).normalized;
			float direction = Vector3.Dot(dir,transform.forward);
		
			Debug.Log(direction);
			if(distance < 100)
			{	if(direction > 0)
				{
					//Debug.DrawLine(curTarget.transform.position, transform.position,Color.yellow); // target at enemy
					ThrowObject();
					//curTarget.transform.GetComponent<EnemyHealth>().AdjustCurrentHealth(50);
				}
			}
		}
	}
	
	
	void ThrowObject(){
		
		
			GameObject newObj = Instantiate(throwObj, 
								transform.forward*3 + transform.position, Quaternion.identity) as GameObject;
			newObj.rigidbody.AddForce(transform.forward*throwPower);
		
	}
	
}
