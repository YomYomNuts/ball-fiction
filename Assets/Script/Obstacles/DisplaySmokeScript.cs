using UnityEngine;
using System.Collections;
/// <summary>
/// Script du bouton qui fait apparaître de la fumée
/// </summary>
public class DisplaySmokeScript : ElementScript {
	/// <summary>
	/// La fumée à faire apparaître
	/// </summary>
	public GameObject _theSmoke;
	
	// Trigger pour activer le changement de taille
	void OnTriggerEnter(Collider collision) {
		if(this._theSmoke != null) {
			// On vérifie que le bouton n'a pas encore été activé et que la taille n'a pas encore été changée
			if(!this._isButtonActivated && !this._theSmoke.active) {
				this._theSmoke.SetActiveRecursively(true);
				this._isButtonActivated = true;
			}
		}
	}
	
	// Use this for initialization
	void Start() {
		if(this._theSmoke == null) {
			Debug.LogWarning("There is no smoke assigned to a DisplaySmokeScript");
		}
	}
	// Update is called once per frame
	void Update() {
		if(this._theSmoke != null) {
			base.UpdateState(); // Mise à jour du statut avec la méthode du parent
			// Le bouton se désactive à la fin de l'animation (voir Element Script)
			if(!this._isButtonActivated && this._theSmoke.active) {
				this._theSmoke.SetActiveRecursively(false);
			}
		}
	}
}
