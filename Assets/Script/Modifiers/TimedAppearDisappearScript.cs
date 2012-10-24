using UnityEngine;
using System.Collections;
/// <summary>
/// Script de comportement de l'aggrandissement de la bille
/// </summary>
public class TimedAppearDisappearScript : TimedButtonScript {
	// Permet de savoir si la bille est invisible
	private bool _isChanged = false;
	
	/// <summary>
	/// Permet de déterminer s'il s'agit d'un bouton pour aparaître (si false, c'est un bouton pour disparaître)
	/// </summary>
	public bool _isAppearButton = false;
	
	// Use this for initialization
	void Start () {
		if(this.TheBall == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
	}
	// Update is called once per frame
	void Update() {
		base.UpdateState(); // Mise à jour du statut avec la méthode du parent
		if(this.TheBall != null) {
			if(this.IsActivated && !this._isChanged) {
				this.TheBall.renderer.enabled = _isAppearButton;
				this._isChanged = true; // On enregistre le fait que la taille a changé
				// Le bouton se désactive à la fin de l'animation (voir TimedButtonScript)
			} else if(!this.IsActivated && this._isChanged) {
				this.TheBall.renderer.enabled = !_isAppearButton;
				this._isChanged = false;
			}
		}
	}
}
