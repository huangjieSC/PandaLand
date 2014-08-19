using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class MainMenuGUI : MonoBehaviour {
	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect playButton;
	public Rect instructionsButton;
	public Rect quitButton;
	Rect menuAreaNormalized;
	string menuPage = "main";
	public Rect instructions;
	void Start(){
		menuAreaNormalized = new Rect(0.5f * Screen.width - (menuArea.width * 0.5f), 0.5f * Screen.height - (menuArea.height * 0.5f), menuArea.width, menuArea.height);
	}
	void OnGUI(){
		GUI.skin = menuSkin;
		GUI.BeginGroup (menuAreaNormalized);
		if(menuPage == "main"){
			if(GUI.Button(new Rect(playButton), "Play")){
				StartCoroutine("ButtonAction", "Island");
			}
			if(GUI.Button(new Rect(instructionsButton), "Instructions")){
				menuPage="instructions";
				audio.PlayOneShot(beep);
			}
			if(GUI.Button(new Rect(quitButton), "Quit")){
				StartCoroutine("ButtonAction", "quit");
			}
			GUI.EndGroup();
		}
		else if(menuPage == "instructions"){
			GUI.Label(new Rect(instructions), "You awake on puzzle land...Find a way to signal for help or face certain doom!");
			if(GUI.Button(new Rect(quitButton), "Back"))
			{
					audio.PlayOneShot(beep);
					menuPage="main";
			}
		}
	}
	IEnumerator ButtonAction(string levelName){
		audio.PlayOneShot(beep);
		yield return new WaitForSeconds(0.35f);
		if(levelName != "quit"){
			Application.LoadLevel(levelName);
		}
		else{
			Application.Quit();
			Debug.Log("Have Quit");
		}
	}
}