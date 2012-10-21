using UnityEngine;
using System.Collections;
/// <summary>
/// Script de comportement de l'aggrandissement de la bille
/// </summary>
public class PonctualAppearDisappearScript : PonctualButtonScript {
	/// <summary>
	/// Permet de déterminer s'il s'agit d'un bouton pour aparaître (si false, c'est un bouton pour disparaître)
	/// </summary>
	public bool _isAppearButton = false;
	
	// Use this for initialization
	void Start () {
		if(this._theBall == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
	}
	// Update is called once per frame
	override protected void ActionWhenActivated() {
		if(this._theBall != null) {
			if(this.IsActivated) {
				this._theBall.renderer.enabled = _isAppearButton;
			}
		}
	}
}
