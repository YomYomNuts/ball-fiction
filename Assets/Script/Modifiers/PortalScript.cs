using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement d'un portail
/// </summary>
public class PortalScript : ElementScript {
	/// <summary>
	/// L 'autre extremité du téléport
	/// </summary>
	public GameObject _otherEnd;
	/// <summary>
	/// Permet de savoir s'il faut activer le portail quand on en sort
	/// Si on met false, cela produit un portail à sens unique
	/// </summary>
	public bool _hasToBeReactivated = true;

	// Use this for initialization
	void Start () {
		if(this._otherEnd == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("other end", this.GetType().ToString(), this.gameObject.name);
		}
	}
	
	// Update is called once per frame
	void Update () {
		base.UpdateState();
	}
	
	// Collision pour faire bouger la bille
	void OnCollisionEnter(Collision collision) {
		if(this._otherEnd != null) {
			if(this._isButtonActivated) {
				// Changement de la position de la bille avec le delta
				collision.gameObject.transform.position = this._otherEnd.gameObject.transform.position;
				
				// Vérification si l'autre extremité est un portail
				if(this._otherEnd.GetComponent<PortalScript>() != null) {
					// Permet d'éviter les téléports infinis
					this._otherEnd.GetComponent<PortalScript>()._isButtonActivated = false;
				}
			}
		}
	}
	
	// Trigger pour modifier l'état du portail
	void OnTriggerExit(Collider collision) {
		if(this._hasToBeReactivated) {
			this._isButtonActivated = true;
		}
	}
}
