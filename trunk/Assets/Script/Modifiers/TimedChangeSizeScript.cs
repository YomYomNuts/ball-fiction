using UnityEngine;
using System.Collections;
/// <summary>
/// Script de comportement de l'aggrandissement de la bille
/// </summary>
public class TimedChangeSizeScript : TimedButtonScript {
	// Le scale de base de la bille
	private Vector3 _normalScale;
	
	/// <summary>
	/// Le coefficient par lequel le scale est multiplié
	/// </summary>
	public float _coeff = 2f;
	/// <summary>
	/// Permet de savoir si la taille de la bille a déjà été changé
	/// </summary>
	/// <value>
	/// <c>true</c> si la taille de la bille a déjà été changée, <c>false</c> sinon.
	/// </value>
	public bool _isChanged = false;
	
	// Use this for initialization
	void Start () {
		if(this.TheBall == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._normalScale = this.TheBall.transform.localScale; // on enregistre la taille normale
		}
	}
	// Update is called once per frame
	void Update() {
		base.UpdateState(); // Mise à jour du statut avec la méthode du parent
		if(this.TheBall != null) {
			if(this.IsActivated && !this._isChanged) {
				this.TheBall.transform.localScale *= this._coeff; // On change la taille
				this._isChanged = true; // On enregistre le fait que la taille a changé
				// On joue le son associé
				if(this.audio != null) {
					AudioSource.PlayClipAtPoint(this.audio.clip, Camera.main.transform.position);
				}
				// Le bouton se désactive à la fin de l'animation (voir TimedButtonScript)
			} else if(!this.IsActivated && this._isChanged) {
				this.TheBall.transform.localScale = this._normalScale;
				this._isChanged = false;
			}
		}
	}
}
