using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement de la bille
/// </summary>
public class TextActivatorScript : MonoBehaviour {
	/// <summary>
	/// Le texte à activer, si null, active le parent
	/// </summary>
	public GameObject _textToActivate;
	/// <summary>
	/// True si l'entrée dans le trigger doit activer le texte, false si ça doit le désactiver
	/// </summary>
	public bool _isActivator = true;
	
	// Use this for initialization
	void Start () {
		if(this._textToActivate == null && this.transform.parent == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("text", this.GetType().ToString(), this.gameObject.name);
		}
	}
	
	void OnTriggerEnter (Collider collider) {
		if(this._textToActivate == null) {
			Transform parentObject = this.transform.parent;
			Debug.Log(parentObject);
			if(parentObject != null) {
				parentObject.gameObject.SetActiveRecursively(this._isActivator);
			}
		} else {
			this._textToActivate.SetActiveRecursively(this._isActivator);
		}
	}
}
