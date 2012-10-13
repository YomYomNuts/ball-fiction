using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement d'une porte
/// </summary>
public class DoorScript : ElementScript {
	//TODO ajouter une hauteur limite pour la porte.
	
	/// <summary>
	/// La position Y, afin de pouvoir refermer la porte comme il faut
	/// </summary>
	private float _savedPositionY;
	
	// Use this for initialization
	void Start () {
		this._savedPositionY = this.gameObject.transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update () {
		base.UpdateState(); // Mise à jour du statut avec la méthode du parent
		if(this._isButtonActivated) {
			// Pendant "l'anmitation" de ElementScript, on fait monter la porte
			this.gameObject.transform.localPosition += new Vector3(0, this._elementSpeed, 0);
		} else if(this._savedPositionY < this.gameObject.transform.position.y) {
			// A la fin de "l'anmitation" de ElementScript, on fait redescendre la porte
			this.gameObject.transform.localPosition += new Vector3(0, -this._elementSpeed, 0);
		}
	}
}
