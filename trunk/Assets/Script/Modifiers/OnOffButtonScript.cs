using UnityEngine;
using System.Collections;

/// <summary>
/// Script général de comportement d'un bouton qui est activé/désactivé quand on appuie dessus
/// </summary>
abstract public class OnOffButtonScript : MonoBehaviour {
	#region Attributes
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
	/// <summary>
	/// Propriété liée à la bille
	/// </summary>
	public GameObject TheBall {
		get {
			// S'il n'y a aucune bille disponible, on prend la "bille par défaut" (singleton de BallScript)
			if(this._theBall == null) {
				this._theBall = BallScript.Instance.gameObject;
			}
			return this._theBall;
		}
	}
	#endregion
	
	#region Unity Methods
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
	#endregion
	
	#region Methods
	/// <summary>
	/// Action appelée quand on appuie sur le bouton (pour l'activer ou le désactiver)
	/// </summary>
	/// <param name='collider'>
	/// Le collider qui actionne le bouton
	/// </param>
	private void DoAction(Collider collider) {
		if(this.TheBall == collider.gameObject) { // On vérifie que c'est la bille qui actionne le bouton
			this.IsActivated = !this.IsActivated; // On l'active ou le désactive
			// On joue le son associé
			if(this.audio != null && this.audio.clip != null) {
				AudioSource.PlayClipAtPoint(this.audio.clip, Camera.main.transform.position);
			}
			// On exécute l'action selon l'état du bouton
			if(this.IsActivated) {
				this.ActionWhenActivated();
			} else {
				this.ActionWhenNonActivated();
			}
		}
	}
	// Les actions effectuées lors de l'activation ou de la désactivation doivent être définies dans les classes filles
	abstract protected void ActionWhenActivated();
	abstract protected void ActionWhenNonActivated();
	#endregion
}
