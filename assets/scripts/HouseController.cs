using UnityEngine;
using System.Collections;

public class HouseController : MonoBehaviour {

	public Transform target;
	//public GameObject tree;
	
	// add tag for extention
	public string Key;
	public string Value;
	// add tag for extention
	
	public GameObject treeText = null;
	private bool enterPressed = false; 
	private bool releaseed = false; 
	private string input = "come on"; 
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("MePlayer").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null)
		{	
			float distance = Vector3.Distance(target.transform.position, transform.position);
			Vector3 trans = new  Vector3(0,10, -10);
			trans = trans + transform.position;
			
			if(distance < 20)
			{	
				Instantiate(treeText, trans, transform.rotation);
			}
			//GUI.TextArea(trans, "Please input the Chinese character\n");
//			else
//			{
//				
//			}	
		}
		if(Input.GetKey(KeyCode.KeypadEnter)&&enterPressed == false)
		{
			enterPressed = true;
		}
		if(Input.GetKey(KeyCode.CapsLock))
		{
			enterPressed = false; 
		}
	}
	
	void OnGUI()
	{
		
		if(enterPressed == true)
		{
			Debug.Log(Screen.height + " " + Screen.width);
			GUI.Label(new Rect(Screen.width/2,Screen.height/2 - 50, 150,25), "Please input the Chinese character");
			input = GUI.TextField(new Rect(Screen.width/2,Screen.height/2 , 150,25), input, 200);
			Debug.Log(input);
			if(input == Key) //extension
			{
				PlayerPrefs.SetString(Key,Value);// tree refers to the resource 
				Debug.Log("You've collected a word: "+PlayerPrefs.GetString(Key));
			}
		}
	}
}
