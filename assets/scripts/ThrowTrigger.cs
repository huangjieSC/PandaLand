using UnityEngine;
using System.Collections;

public class ThrowTrigger : MonoBehaviour {
	public GUITexture crosshair;
	public GUIText textHints;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			CoconutThrower.canThrow=true;
			crosshair.enabled=true;
			if(!CoconutWin.haveWon){
				textHints.SendMessage("ShowHint", "\n\n\n\n\n There's a power cell hidden, \nYou can win it if you knock down all the targets...");
//				textHints.SendMessage("ShowShootHint");
			}
		}
	}
	void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "Player"){
			CoconutThrower.canThrow=false;
			crosshair.enabled=false;
		}
	}
}
