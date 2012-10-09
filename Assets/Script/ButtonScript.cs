using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement d'un bouton
/// </summary>
public class ButtonScript : MonoBehaviour {
	/// <summary>
	/// True si on veut que l'actionnement se déroule OnEnter, false si on veut OnExit
	/// </summary>
    public bool _onEnter = true;
	
	/// <summary>
	/// L'element que le bouton actionne
	/// </summary>
    public GameObject _Element;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	// Collision pour activer/désactiver le boutton
	void OnTriggerEnter(Collider collision) {
		if(this._onEnter) {
			this._Element.GetComponent<ElementScript>()._isButtonActivated = true;
		}
	}
	
	// Collision pour activer/désactiver le boutton
	void OnTriggerExit(Collider collision) {
		if(! this._onEnter) {
			this._Element.GetComponent<ElementScript>()._isButtonActivated = true;
		}
	}
}
