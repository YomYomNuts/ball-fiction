using UnityEngine;
using System.Collections;
/// <summary>
/// Script de comportement de l'aggrandissement de la bille (ponctuel)
/// </summary>
public class PonctualChangeSizeScript : PonctualButtonScript {
	// Le scale de base de la bille
	private Vector3 _normalScale;
	
	/// <summary>
	/// Le coefficient par lequel le scale est multiplié
	/// </summary>
	public float _coeff = 2f;
	/// <summary>
	/// Permet de savoir si la taille de la bille a déjà été changé
	/// </summary>
	/// <value>
	/// <c>true</c> si la taille de la bille a déjà été changée, <c>false</c> sinon.
	/// </value>
	public bool _isChanged = false;
	/// <summary>
	/// True = le calcul de la nouvelle taille se fait en fonction de la taille normale, pas de la taille courante
	/// </summary>
	public bool _isBasedOnNormalScale = false;
	
	override public bool IsActivated {
		get {
			return base.IsActivated;
		}
		protected set {
			base.IsActivated = value;
			if(!this.IsActivated) {
				this._isChanged = false; // Si le bouton est passé à false, on peut rechanger la taille
			}
		}
	}
	
	// Use this for initialization
	void Start () {
		if(this._theBall == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._normalScale = this._theBall.transform.localScale; // on enregistre la taille normale
		}
	}
	
	// Update is called once per frame
	override protected void ActionWhenActivated() {
		if(this._theBall != null) {
			if(this.IsActivated) {
				if(!this._isChanged) {
					if(this._isBasedOnNormalScale) {
						this._theBall.transform.localScale = this._normalScale * this._coeff; // On change la taille
					} else {
						this._theBall.transform.localScale *= this._coeff; // On change la taille
					}
					if(this._theBall.transform.localScale == this._normalScale*this._coeff) {
						this._isChanged = true; // On enregistre le fait que la taille a changé
					} else {
						this.IsActivated = false;
					}
				}
			} else {
				this._isChanged = false; // Si le bouton est passé à false, on peut re
			}
		}
	}
}
