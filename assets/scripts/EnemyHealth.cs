using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public Transform target;
	
	public float maxHealth = 500;
	public float currHealth = 500;
	public float decreHealth = 2;
	public bool dead = false;
	
	public float healthBarLength;

	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width/2;
		target = GameObject.FindGameObjectWithTag("MePlayer").transform;
	}
	
	// Update is called once per frame
	void Update () {
		AdjustCurrentHealth(0);
		
	}
	
	void OnGUI(){
		GUI.contentColor = Color.yellow;
		GUI.Box(new Rect(0, 40, healthBarLength, 20), "Enemy Health: " + currHealth+"/"+maxHealth);
		if(healthBarLength < 20)
		{
			GUI.backgroundColor = Color.red;
		}
		GUI.backgroundColor = Color.yellow;
		
		
		if(dead == true)
			Dead();
	}
	
	public void AdjustCurrentHealth(int h){
		if(currHealth <= 0){
			currHealth = 0;
			dead = true;
		}
		
		if(currHealth > maxHealth)
			currHealth = maxHealth;
		
		
	/*	if(Vector3.Distance(transform.position, target.position) < 25)
		{
				currHealth -= decreHealth;
		}
	*/	
		currHealth -= h; // new add 0924 because of player attack need to update enemy health bar
		healthBarLength = (Screen.width/2) * (currHealth / (float)maxHealth);
	}
	
	void Dead(){
		if(GUI.Button(new Rect(0,40,Screen.width/2,20), "Enemy dead!")){
			
		}
	}
}
