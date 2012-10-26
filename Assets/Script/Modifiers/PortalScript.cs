using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Script de comportement d'un portail
/// </summary>
public class PortalScript : MonoBehaviour{
	#region Attributes
	/// <summary>
	/// L 'autre extremité du téléport
	/// </summary>
	public GameObject _otherEnd;
	/// <summary>
	/// True si le portail est actif
	/// </summary>
    public bool _isActivated = true;
	/// <summary>
	/// Permet de savoir s'il faut activer le portail quand on en sort
	/// Si on met false, cela produit un portail à sens unique
	/// </summary>
	public bool _hasToBeReactivated = true;
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	void Start () {
		if(this._otherEnd == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("other end", this.GetType().ToString(), this.gameObject.name);
		}
	}
	// Trigger pour modifier la position de la bille
	void OnTriggerEnter(Collider collider) {
		if(this._otherEnd != null) {
			if(this._isActivated) {
				// On joue le son associé
				if(this.audio != null && this.audio.clip != null) {
					AudioSource.PlayClipAtPoint(this.audio.clip, Camera.main.transform.position);
				}
				Vector3 newPosition = this._otherEnd.gameObject.transform.position;
				// Changement de la position de la bille avec le delta
				collider.gameObject.transform.position = newPosition;
				
				// Vérification si l'autre extremité est un portail
				if(this._otherEnd.GetComponent<PortalScript>() != null) {
					// Permet d'éviter les téléports infinis
					this._otherEnd.GetComponent<PortalScript>()._isActivated = false;
				}
			}
		}
	}
	// Trigger pour modifier l'état du portail
	void OnTriggerExit(Collider collider) {
		if(this._hasToBeReactivated) {
			this._isActivated = true;
		}
	}
	#endregion
}
