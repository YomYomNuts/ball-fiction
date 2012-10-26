using UnityEngine;
using System.Collections;

/// <summary>
/// Script permettant d'avoir un gameover
/// </summary>
public class ExitZoneScript : MonoBehaviour {
	
	#region Methods
	// Collision pour le GameOver
	void OnTriggerEnter(Collider collider) {
		GameClasseScript.Instance.LevelLost();
	}
	#endregion
}
