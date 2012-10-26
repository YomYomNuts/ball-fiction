using UnityEngine;
using System.Collections;

/// <summary>
/// Script général de comportement d'un bouton qui est activé/désactivé quand on appuie dessus
/// </summary>
abstract public class PonctualButtonScript : MonoBehaviour {
	#region Attributes
	/// <summary>
	/// La bille
	/// </summary>
	public GameObject _theBall;
	/// <summary>
	/// Le bouton lié à celui-ci, il sera réactivable quand celui-ci sera activé
	/// Exemple : un bouton pour ouvrir une porte, l'autre pour la ferme
	/// 	Quand on ouvre la porte, on doit pouvoir la ferme
	/// 	Quand on ferme la porte, on doit pouvoir l'ouvrir
	/// 	On doit pouvoir faire cela plusieurs fois (pas une seule fois)
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
	/// La propriété est en virtual car ChangeScript en a besoin
	/// </summary>
	virtual public bool IsActivated {
		get {
			return this._isActivated;
		}
		protected set {
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
	/// Action appelée quand on appuie sur le bouton
	/// </summary>
	/// <param name='collider'>
	/// Le collider qui actionne le bouton
	/// </param>
	private void DoAction(Collider collider) {
		// On vérifie que le bouton n'est pas déjà activé et que c'est la bille qui l'active
		if(!this.IsActivated && this.TheBall == collider.gameObject) {
			this.IsActivated = true; // On l'active
			// On joue le son associé
			if(this.audio != null && this.audio.clip != null) {
				AudioSource.PlayClipAtPoint(this.audio.clip, Camera.main.transform.position);
			}
			this.ActionWhenActivated(); // On exécute les actions associées
			// S'il y a un bouton lié, on le désactive pour que la bille puisse le réactiver
			if(this._linkedButton != null) {
				PonctualButtonScript scriptOfTheLinkedButton = this._linkedButton.GetComponent<PonctualButtonScript>();
				if(scriptOfTheLinkedButton != null) {
					scriptOfTheLinkedButton.IsActivated = false;
				}
			}
		}
	}
	
	abstract protected void ActionWhenActivated();
	#endregion
}
