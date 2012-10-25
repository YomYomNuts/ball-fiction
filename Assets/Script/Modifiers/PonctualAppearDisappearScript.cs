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
		if(this.TheBall == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
	}
	// Update is called once per frame
	override protected void ActionWhenActivated() {
		if(this.TheBall != null) {
			if(this.IsActivated) {
				this.TheBall.renderer.enabled = _isAppearButton;
				// On joue le son associé
				if(this.audio != null) {
					AudioSource.PlayClipAtPoint(this.audio.clip, Camera.main.transform.position);
				}
			}
		}
	}
}
