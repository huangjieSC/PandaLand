using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public Transform target;
	
	public float maxHealth = 500;
	public float currHealth = 500;
	public float decreHealth = 2;
	public bool dead = false;
	
	public bool isHit; // 1011 new add
	
	public float healthBarLength;

	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width/2;
		target = GameObject.FindGameObjectWithTag("MyEnemy").transform;
	}
	
	// Update is called once per frame
	void Update () {
		AdjustCurrentHealth(0);
		
	}
	
	void OnGUI(){
		GUI.contentColor = Color.yellow;
		GUI.backgroundColor = Color.yellow;
		
		GUI.Box(new Rect(0, 0, healthBarLength, 20), "My Health: " + currHealth + "/" + maxHealth);
		if(healthBarLength < 20)
		{
			GUI.backgroundColor = Color.red;
		}
		
		
		if(GUI.Button(new Rect(Screen.width-150, 0,150,20), "Back to Main Menu")){
			GUI.contentColor = Color.green;
			Application.LoadLevel(0);//1005 newly added
		}
		if(GUI.Button(new Rect(Screen.width-150,40,150,20), "Exit")){
			GUI.contentColor = Color.red;
			Application.Quit(); //1005 newly added
		}
		
		if(dead == true)
			Dead();
	}
	
	public void AdjustCurrentHealth(int h){
		if(currHealth < 0){
			currHealth = 0;
			dead = true;
		}
		
		if(currHealth > maxHealth)
			currHealth = maxHealth;
		
		// if(isHit == true)
			currHealth -= h;
		
		// if(target != null && Vector3.Distance(transform.position, target.position) < 2) // 10/04 add target != null
		//if(target != null && isHit == true)
		//if(target != null)
		//{
		//		currHealth -= decreHealth;
		//}
		
		
		healthBarLength = (Screen.width/2) * (currHealth / (float)maxHealth);
	}
	
	void Dead(){
		if(GUI.Button(new Rect(0,0,300,20), "Player dead!")){
		}	
	}
	
	// 1011 new add
	/*
	void OnCollisionEnter(Collision colliInfo)
	{
		isHit = true;
		// transform.GetComponent<EnemyHealth>().AdjustCurrentHealth(50);
		// AdjustCurrentHealth(50);
	}
	
	void OnCollisionExit(Collision colliInfo)
	{
		isHit = false;
	}
	*/
	
	
	
}
