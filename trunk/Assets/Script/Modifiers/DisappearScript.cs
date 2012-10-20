using UnityEngine;
using System.Collections;
/// <summary>
/// Script de comportement de l'aggrandissement de la bille
/// </summary>
public class DisappearScript : TimedButtonScript {
	/// <summary>
	/// Permet de savoir si la bille est invisible
	/// </summary>
	public bool _isInvisible = false;
	
	// Use this for initialization
	void Start () {
		if(this._theBall == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
	}
	// Update is called once per frame
	void Update() {
		base.UpdateState(); // Mise à jour du statut avec la méthode du parent
		if(this._theBall != null) {
			if(this.IsActivated && !this._isInvisible) {
				this._theBall.renderer.enabled = false;
				this._isInvisible = true; // On enregistre le fait que la taille a changé
				// Le bouton se désactive à la fin de l'animation (voir TimedButtonScript)
			} else if(!this.IsActivated && this._isInvisible) {
				this._theBall.renderer.enabled = true;
				this._isInvisible = false;
			}
		}
	}
}
