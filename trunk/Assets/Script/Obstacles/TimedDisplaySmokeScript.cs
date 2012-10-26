using UnityEngine;
using System.Collections;
/// <summary>
/// Script du bouton qui affiche la fumée
/// </summary>
public class TimedDisplaySmokeScript : TimedButtonScript {
	#region Attributes
	/// <summary>
	/// La fumée à faire apparaître. Cela peut être un objet qui affiche de la fumée ou le parent de plusieurs objets qui en affichent
	/// </summary>
	public GameObject _theSmoke;
	// Variable permettant de savoir si la fumée est affichée ou non
	public bool _isDisplayed = false;
	
	/// <summary>
	/// Propriété lié à l'affichage du brouillard, la modification permet d'afficher ou non la fumée
	/// </summary>
	public bool IsDisplayed {
		get {
			return this._isDisplayed;
		}
		private set {
			this._isDisplayed = value; // on modifie la variable
			// puis on affiche ou non la fumée.
			if(this._theSmoke.renderer) { // si l'objet Smoke n'a pas de renderer, on affiche ses enfants
				this._theSmoke.renderer.enabled = this.IsDisplayed;
			} else {
				foreach(Transform smoke in this._theSmoke.transform) {
					smoke.renderer.enabled = this.IsDisplayed;
				}
			}
		}
	}
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	void Start() {
		if(this.TheBall == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
		if(this._theSmoke == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("smoke", this.GetType().ToString(), this.gameObject.name);
		} else {
			// Mise à jour du renderer de la fumée en fonction de la valeur de this.IsDisplayed
			this.IsDisplayed = this.IsDisplayed;
		}
	}
	// Update is called once per frame
	void Update() {
		if(this._theSmoke != null) {
			base.UpdateState(); // Mise à jour du statut avec la méthode du parent
			if(this.IsActivated && !this.IsDisplayed) {
				this.IsDisplayed = true;
			// Le bouton se désactive à la fin de l'animation (voir TimedButtonScript)
			} else if(!this.IsActivated && this.IsDisplayed) {
				this.IsDisplayed = false;
			}
		}
	}
	#endregion
}
