using UnityEngine;
using System.Collections;

public class RiverZone : MonoBehaviour {
private string input = "please input a tool";
private bool inZone = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log("RiverZone\n");
//		if(inZone)
//		{
//			ByRiverHint();
//		}
	}
	
	void OnGUI()
	{
		if(inZone == true)
		{
			GUI.Label(new Rect(Screen.width/2, Screen.height/2, 200, 50), "Input a tool can get you over this river.");
			
			input = GUI.TextField(new Rect(Screen.width/2, Screen.height/2 + 40, 200, 50), input, 200);
			Debug.Log(input);
			Debug.Log(PlayerPrefs.GetString(input));
			if(PlayerPrefs.GetString(input)!="")
			{
				PlayerPrefs.SetString("boat","tree");// tree refers to the resource 
				//Debug.Log("you've passed chanllenge: "+PlayerPrefs.GetString("shu"));
				GUI.Label(new Rect(Screen.width/2,Screen.height/2 - 100, 150,50),"you've passed the chanllenge using "+PlayerPrefs.GetString("boat"));
			}
		}
	}
	
//	void OnCollisionEnter(Collision collinfo)
//	{
//		Debug.Log("OnCollisionEnter");
//		//if(col.gameObject.tag == "MePlayer")
//		{
//			print ("Player entered.");
//			inZone = true;
//		}
//	}
//	
//	void OnCollisionExit(Collision collinfo)
//	{
//		//if(col.gameObject.tag == "MePlayer")
//		{
//			print ("Player exited.");
//			inZone = false;
//		}
//	}
	
	void OnTriggerEnter(Collider col)
	{
		Debug.Log("OnTriggerEnter");
		if(col.gameObject.tag == "MePlayer")
		{
			print ("Player entered.");
			inZone = true;
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag == "MePlayer")
		{
			print ("Player exited.");
			inZone = false;
		}
	}

}
