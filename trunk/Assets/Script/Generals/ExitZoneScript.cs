using UnityEngine;
using System.Collections;

/// <summary>
/// Script permettant d'avoir un gameover
/// </summary>
public class ExitZoneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	// Collision pour le GameOver
	void OnTriggerEnter(Collider collider) {
		GameClasse.Instance.LevelLost();
	}
}
