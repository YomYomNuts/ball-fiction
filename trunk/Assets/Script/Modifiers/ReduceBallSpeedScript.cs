using UnityEngine;
using System.Collections;

/// <summary>
/// Script général de comportement d'un bouton qui est activé/désactivé quand on appuie dessus
/// </summary>
public class ReduceBallSpeedScript : OnOffButtonScript {
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
			// On met la vitesse à 0, la rotation de la bille la fera avancer lentement
			this.TheBall.rigidbody.velocity = Vector3.zero;
		}
	}
	// Actions à effectuées lorsque le bouton est désactivé
	override protected void ActionWhenNonActivated() {
		this.ActionWhenActivated();
	}
}
