using UnityEngine;
using System.Collections;

/// <summary>
/// Script général de comportement d'un bouton qui est activé/désactivé quand on appuie dessus
/// </summary>
abstract public class PonctualButtonScript : MonoBehaviour {
	/// <summary>
	/// La bille
	/// </summary>
	public GameObject _theBall;
	/// <summary>
	/// Le bouton lié à celui-ci, il sera réactivable quand celui-ci sera activé
	/// </summary>
	public GameObject _linkedButton;
	/// <summary>
	/// True si on veut que l'activation se déroule OnEnter, false si on veut OnExit
	/// </summary>
    public bool _onEnter = true;
	/// <summary>
	/// Permet de savoir si le bouton est activé ou désactivé
	/// </summary>
	public bool _isActivated = false;
	/// <summary>
	/// Propriété liée à l'activation du bouton
	/// </summary>
	virtual public bool IsActivated {
		get {
			return this._isActivated;
		}
		protected set {
			this._isActivated = value;
		}
	}
	
	// Trigger pour activer le boutton
	void OnTriggerEnter(Collider collider) {
		if(this._onEnter) {
			this.DoAction(collider);
		}
	}
	
	// Trigger pour activer le boutton
	void OnTriggerExit(Collider collider) {
		if(! this._onEnter) {
			this.DoAction(collider);
		}
	}
	
	private void DoAction(Collider collider) {
		if(!this.IsActivated && this._theBall == collider.gameObject) {
			this.IsActivated = true;
			this.ActionWhenActivated();
			if(this._linkedButton != null) {
				PonctualButtonScript scriptOfTheLinkedButton = this._linkedButton.GetComponent<PonctualButtonScript>();
				if(scriptOfTheLinkedButton != null) {
					scriptOfTheLinkedButton.IsActivated = false;
				}
			}
		}
	}
	
	abstract protected void ActionWhenActivated();
}
