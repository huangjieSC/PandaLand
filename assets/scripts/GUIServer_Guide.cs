using UnityEngine;
using System.Collections;

public class GUIServer_Guide : MonoBehaviour {

		public bool isQuitButton = false;
	//public string ipAddress = "127.0.0.1";
	//public string portNumber = "22222";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	void OnGUI()
	{
		if(Application.loadedLevel == 0)
		{
			MainMenu();
		}
		if(Application.loadedLevel == 1)
		{
			GameMenu();	
		}
		
	}*/
	
	void OnMouseEnter(){
		if(isQuitButton)
		{
			renderer.material.color = Color.red;
		}
		else
		{
			renderer.material.color = Color.green;
		}
	}
	
	void OnMouseExit(){
		
		renderer.material.color = Color.white;
	}
	
	void OnMouseUp(){
		// are we dealing with a quit button
		if(isQuitButton)
		{
			//quit the game
			Application.Quit();
		}
		else{
			//load level
			//SendMessage("GoToNextScene");
			Application.LoadLevel(2);
		}
	}
	void MainMenu()
	{	
		//OnMouseEnter();
		
		/*
		float stdW = 100;
		float stdH = 20;
		float currY = Screen.width/4;
		if(GUI.Button(new Rect(Screen.width/3, currY,stdW,stdH),"Enter Game"))
		{
			// SendMessage("StartServer");
			SendMessage("GoToNextScene");
		}
		currY += stdH;
		
		
		*/
		//GUI.Label(new Rect(0,currY,stdW,stdH),"IP Address");		
		//currY += stdH;
		
		//ipAddress = GUI.TextArea(new Rect(0,currY,stdW,stdH),ipAddress);
		//currY += stdH;
		
		//portNumber = GUI.TextArea(new Rect(0,currY,stdW,stdH),portNumber);
		//currY += stdH;
		
		/*		
		if(GUI.Button(new Rect(0, currY,stdW,stdH),"Connect to Server"))
		{
			ConnectionInfo info = new ConnectionInfo();
			info.ipAddress = ipAddress;
			int iPortNum = 0;
			if(Int32.TryParse(portNumber,out iPortNum))
			{
				info.port = iPortNum;
			}

			SendMessage("ConnectToServer", info);			
			
		}*/
	}
	void GameMenu()
	{	/*
		if(GUI.Button(new Rect(0,0,Screen.width,Screen.height),"Start"))
		{
			SendMessage("SpawnPlayer",true);
			GameObject.Find("TempCamera").SetActive(false);
			enabled = false;
		}
		*/
	}
}