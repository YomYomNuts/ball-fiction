using UnityEngine;
using System.Collections;
/// <summary>
/// Script de comportement de l'aggrandissement de la bille
/// </summary>
public class ChangeSizeScript : ElementScript {
	/// <summary>
	/// La bille
	/// </summary>
	public GameObject _theBall;
	
	/// <summary>
	/// Le coefficient par lequel le scale est multiplié
	/// </summary>
	public float _coeff = 2f;
	
	/// <summary>
	/// Le scale de base de la bille
	/// </summary>
	private Vector3 _normalScale;
	
	/// <summary>
	/// Permet de savoir si la taille de la bille a déjà été changé
	/// </summary>
	/// <value>
	/// <c>true</c> si la taille de la bille a déjà été changée, <c>false</c> sinon.
	/// </value>
	public bool _isChanged = false;
	
	// Use this for initialization
	void Start () {
		if(this._theBall == null) {
			Debug.LogWarning("There is no ball assigned to a ChangeSizeScript");
		} else {
			this._normalScale = this._theBall.transform.localScale; // on enregistre la taille normale
		}
	}
	
	// Trigger pour activer le changement de taille
	void OnTriggerEnter(Collider collision) {
		if(this._theBall != null) {
			// On vérifie que le bouton n'a pas encore été activé et que la taille n'a pas encore été changée
			if(!this._isButtonActivated && !this._isChanged) {
				this._theBall.transform.localScale *= this._coeff; // On change la taille
				this._isChanged = true; // On enregistre le fait que la taille a changé
				this._isButtonActivated = true;
			}
		}
	}
	// Update is called once per frame
	void Update() {
		base.UpdateState(); // Mise à jour du statut avec la méthode du parent
		if(this._theBall != null) {
			// Le bouton se désactive à la fin de l'animation (voir Element Script)
			if(!this._isButtonActivated && this._isChanged) {
				this._theBall.transform.localScale = this._normalScale;
				this._isChanged = false;
			}
		}
	}
}
