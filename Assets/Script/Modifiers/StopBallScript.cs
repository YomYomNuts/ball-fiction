using UnityEngine;
using System.Collections;

/// <summary>
/// Script général de comportement d'un bouton qui est activé/désactivé quand on appuie dessus
/// </summary>
public class StopBallScript : OnOffButtonScript {
	#region Unity Methods
	// Use this for initialization
	void Start () {
		if(this.TheBall == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
	}
	#endregion
	
	// Actions à effectuées lorsque le bouton est activé
	override protected void ActionWhenActivated() {
		if(this.TheBall != null) {
			// On met la vitesse d'avance et de rotation à 0
			this.TheBall.rigidbody.velocity = Vector3.zero;
			this.TheBall.rigidbody.angularVelocity = Vector3.zero;
		}
	}
	
	// Actions à effectuées lorsque le bouton est desactivé
	override protected void ActionWhenNonActivated() {
		this.ActionWhenActivated();
	}
}
