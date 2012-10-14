using UnityEngine;
using System.Collections;
/// <summary>
/// Script du bouton qui fait apparaître de la fumée
/// </summary>
public class DisplaySmokeScript : TimedButtonScript {
	/// <summary>
	/// La fumée à faire apparaître
	/// </summary>
	public GameObject _theSmoke;
	
	// Use this for initialization
	void Start() {
		if(this._theSmoke == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("smoke", this.GetType().ToString(), this.gameObject.name);
		}
	}
	// Update is called once per frame
	void Update() {
		if(this._theSmoke != null) {
			base.UpdateState(); // Mise à jour du statut avec la méthode du parent
			if(this.IsActivated && !this._theSmoke.active) {
				this._theSmoke.SetActiveRecursively(true);
			// Le bouton se désactive à la fin de l'animation (voir TimedButtonScript)
			} else if(!this.IsActivated && this._theSmoke.active) {
				this._theSmoke.SetActiveRecursively(false);
			}
		}
	}
}
