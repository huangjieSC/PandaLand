using UnityEngine;
using System.Collections;

public class TimeDeath : MonoBehaviour {
	
	public float lifeSpan = 10;
	float currLifeSpan;
	
	// Use this for initialization
	void Start () {
		currLifeSpan = lifeSpan;
	}
	
	// Update is called once per frame
	void Update () {
		currLifeSpan -= Time.deltaTime;
		if(currLifeSpan <= 0)
		{
			Destroy(gameObject); // call lowercase gameobject when you refer to yourself
		}
	}
}
