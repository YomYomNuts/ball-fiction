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
	public bool IsActivated {
		get {
			return this._isActivated;
		}
		private set {
			this._isActivated = value;
		}
	}

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}
	
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
		if(this._theBall == collider.gameObject) {
			this.IsActivated = !this.IsActivated;
			if(this.IsActivated) {
				this.ActionWhenActivated();
			} else {
				this.ActionWhenNonActivated();
			}
		}
	}
	
	abstract protected void ActionWhenActivated();
	
	abstract protected void ActionWhenNonActivated();
}
