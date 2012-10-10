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
	/// Delta vector afin d'éviter d'apparaître sous l'objet
	/// </summary>
	public Vector3 _teleportDelta = new Vector3(0.01f, 0.01f, 0.01f);
	/// <summary>
	/// Permet de savoir s'il faut activer le portail quand on en sort
	/// </summary>
	public bool _isReactivated = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		base.UpdateState();
	}
	
	// Collision pour faire bouger la bille
	void OnCollisionEnter(Collision collision) {
		if(this._isButtonActivated) {
			// Changement de la position de la bille avec le delta
			collision.gameObject.transform.position = this._otherEnd.gameObject.transform.position + this._teleportDelta;
			
			// Vérification si l'autre extremité est un portail
			if(this._otherEnd.GetComponent<PortalScript>() != null) {
				// Permet d'éviter les téléports infinis
				this._otherEnd.GetComponent<PortalScript>()._isButtonActivated = false;
			}
		}
	}
	
	// Collision pour modifier l'état du portail
	void OnTriggerExit(Collider collision) {
		if(this._isReactivated) {
			this._isButtonActivated = true;
		}
	}
}
