using UnityEngine;
using System.Collections;

public class ExitZoneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	// Collision pour GameOver
	void OnTriggerEnter(Collider collision) {
		Application.LoadLevel(Utils.SceneLevelAbandoned);
	}
}
