using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement d'un portail
/// </summary>
public class PortalScript : MonoBehaviour{
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

	// Use this for initialization
	void Start () {
		if(this._otherEnd == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("other end", this.GetType().ToString(), this.gameObject.name);
		}
	}
	
	// Collision pour faire bouger la bille
	void OnTriggerEnter(Collider collision) {
		if(this._otherEnd != null) {
			if(this._isActivated) {
				Vector3 newPosition = this._otherEnd.gameObject.transform.position;
				newPosition.y = collision.gameObject.transform.position.y;
				// Changement de la position de la bille avec le delta
				collision.gameObject.transform.position = newPosition;
				
				// Vérification si l'autre extremité est un portail
				if(this._otherEnd.GetComponent<PortalScript>() != null) {
					// Permet d'éviter les téléports infinis
					this._otherEnd.GetComponent<PortalScript>()._isActivated = false;
				}
			}
		}
	}
	
	// Trigger pour modifier l'état du portail
	void OnTriggerExit(Collider collision) {
		if(this._hasToBeReactivated) {
			this._isActivated = true;
		}
	}
}
