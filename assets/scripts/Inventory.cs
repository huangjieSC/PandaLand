using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	public static int charge = 0;
	public AudioClip collectSound;
	public Texture2D[] hudCharge;
	public GUITexture chargeHudGUI;
	public Texture2D[] meterCharge;
	public Renderer meter;
	bool haveMatches = false;
	public GUITexture matchGUIprefab;
	public GUITexture shootHintGUIprefab;
	public GUITexture jumpHintGUIprefab;
	public GUITexture matchHintGUIprefab;
	public GUITexture bambooHintGUIprefab;
	public GUITexture houseHintGUIprefab;
	public GUITexture fireHintGUIprefab;
	public GUITexture treeHintGUIprefab;

	public GUIText textHints;
	GUITexture matchGUI;
	GUITexture bambooHintGUI;
	GUITexture shootHintGUI;
	GUITexture jumpHintGUI;
	GUITexture matchHintGUI;

	GUITexture houseHintGUI;
	GUITexture fireHintGUI;
	GUITexture treeHintGUI;

	bool fireIsLit = false;
	public GameObject winObj;
	// Use this for initialization
	void Start () {
		charge = 0;
		chargeHudGUI.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void CellPickup(){
		HUDon();
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		charge++;
		chargeHudGUI.texture = hudCharge[charge];
		meter.material.mainTexture = meterCharge[charge];

	}
	void HUDon(){
		Debug.Log(chargeHudGUI.enabled);
		if(!(chargeHudGUI.enabled))
		{
			chargeHudGUI.enabled = true;
					//	Debug.Log("inside true");
		}
	}
	void MatchPickup(){
		Debug.Log("MatchPickup is on\n");
		haveMatches = true;
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		GUITexture matchHUD = Instantiate(matchGUIprefab,new Vector3(0.15f, 0.1f, 0),transform.rotation) as GUITexture;
		matchGUI = matchHUD;
	}
	void OnControllerColliderHit(ControllerColliderHit col){
		Debug.Log("haveMatches: " + haveMatches +"\n");
		if(col.gameObject.name == "campfire"){
			if(haveMatches&& !fireIsLit){
				LightFire(col.gameObject);
				ShowFireHint();
			}else if(!haveMatches&& !fireIsLit){
				textHints.SendMessage("ShowHint","you can use this campfire to keep warm..if only I could light it..");
//				GUITexture shootHUD = Instantiate(shootHintGUIprefab,new Vector3(0.5f, 0.5f, 0),transform.rotation) as GUITexture;
//				shootHintGUI = shootHUD;
//				shootHintGUI.enabled = true;
			}
		}
	}
	
	void LightFire(GameObject campfire){
//		ParticleEmitter[] fireEmitters;
//		fireEmitters = campfire.GetComponentsInChildren<ParticleEmitter>();
//		foreach(ParticleEmitter emitter in fireEmitters){
//			emitter.emit = true;
//		}
		Debug.Log(campfire.name+"LightFire\n");
		ParticleSystem particlesystem = (ParticleSystem)campfire.GetComponentInChildren<ParticleSystem>();
		//particlesystem.enableEmission = true;
		particlesystem.Play();
		campfire.audio.Play();
		Destroy(matchGUI);
		haveMatches=false;
		fireIsLit=true;
		winObj.SendMessage("GameOver");
	}

	void ShowBambooHint(){
		GUITexture bambooHUD = Instantiate(bambooHintGUIprefab,new Vector3(0.92f, 0.87f, 0),transform.rotation) as GUITexture;
		bambooHintGUI = bambooHUD;
		Destroy (bambooHintGUI, 3);
	}

	void ShowMatchHint(){
		GUITexture matchHUD = Instantiate(matchHintGUIprefab,new Vector3(0.92f, 0.87f, 0),transform.rotation) as GUITexture;
		matchHintGUI = matchHUD;
		Destroy (matchHintGUI, 3);
	}

	void ShowJumpHint(){
		GUITexture jumpHUD = Instantiate(jumpHintGUIprefab,new Vector3(0.92f, 0.87f, 0),transform.rotation) as GUITexture;
		jumpHintGUI = jumpHUD;
		Destroy (jumpHintGUI, 3);
	}

	void ShowShootHint(){
		Debug.Log("ShowShootHint");
		GUITexture shootHUD = Instantiate(shootHintGUIprefab,new Vector3(0.92f, 0.87f, 0),transform.rotation) as GUITexture;
		shootHintGUI = shootHUD;
		Destroy(shootHintGUI, 3);
		Debug.Log("ShowShootHint ends");
	}
	
	void ShowHouseHint(){

		GUITexture houseHUD = Instantiate(houseHintGUIprefab,new Vector3(0.92f, 0.87f, 0),transform.rotation) as GUITexture;
		houseHintGUI = houseHUD;
		Destroy(houseHintGUI, 3);
	
	}

	void ShowTreeHint(){

		GUITexture treeHUD = Instantiate(treeHintGUIprefab,new Vector3(0.92f, 0.87f, 0),transform.rotation) as GUITexture;
		treeHintGUI = treeHUD;
		Destroy(treeHintGUI, 3);

	}

	void ShowFireHint(){
		
		GUITexture fireHUD = Instantiate(fireHintGUIprefab,new Vector3(0.92f, 0.87f, 0),transform.rotation) as GUITexture;
		fireHintGUI = fireHUD;
		Destroy(fireHintGUI, 3);
		
	}
}
