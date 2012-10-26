using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement de l'activateur de texte (pour le tutorial)
/// </summary>
public class TextActivatorScript : MonoBehaviour {
	#region Attributes
	/// <summary>
	/// Le texte à activer, si null, active le parent
	/// </summary>
	public GameObject _textToActivate;
	/// <summary>
	/// True si l'entrée dans le trigger doit activer le texte, false si ça doit le désactiver
	/// </summary>
	public bool _isActivator = true;
	#endregion
	
	#region unity Methods
	// Use this for initialization
	void Start () {
		if(this._textToActivate == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("text", this.GetType().ToString(), this.gameObject.name);
		}
	}
	
	// Collision pour afficher ou cacher le texte
	void OnTriggerEnter (Collider collider) {
		if(this._textToActivate != null) {
			this._textToActivate.SetActiveRecursively(this._isActivator);
		}
	}
	#endregion
}
