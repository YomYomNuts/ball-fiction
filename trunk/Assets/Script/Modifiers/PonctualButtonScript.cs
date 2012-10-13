using UnityEngine;
using System.Collections;

/// <summary>
/// Script général de comportement d'un bouton qui est activé/désactivé quand on appuie dessus
/// </summary>
abstract public class PonctualButtonScript : MonoBehaviour {
	/// <summary>
	/// True si on veut que l'activation se déroule OnEnter, false si on veut OnExit
	/// </summary>
    public bool _onEnter = true;
	
	// Permet de savoir si le bouton est activé ou désactivé
	private bool _isActivated = false;
	
	/// <summary>
	/// Propriété liée à l'activation ou non du bouton
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
	void OnTriggerEnter(Collider collision) {
		if(this._onEnter) {
			this.DoAction();
		}
	}
	
	// Trigger pour activer le boutton
	void OnTriggerExit(Collider collision) {
		if(! this._onEnter) {
			this.DoAction();
		}
	}
	
	public void DoAction() {
		this.IsActivated = !this.IsActivated;
		if(this.IsActivated) {
			this.ActionWhenActivated();
		} else {
			this.ActionWhenNonActivated();
		}
	}
	
	abstract protected void ActionWhenActivated();
	
	abstract protected void ActionWhenNonActivated();
}
