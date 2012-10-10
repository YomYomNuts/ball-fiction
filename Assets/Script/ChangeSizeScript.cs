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
	/// Permet de savoir si le scale de la bille est normal ou pas (s'il n'est pas normal, c'est qu'elle est encore grande)
	/// </summary>
	/// <value>
	/// <c>true</c> si la bille a un scale normal, <c>false</c> sinon.
	/// </value>
	public bool HasNormalScale {
		get {
			return this._theBall.transform.localScale == this._normalScale;
		}
	}
	
	// Use this for initialization
	void Start () {
		this._normalScale = this._theBall.transform.localScale;
	}
	
	// Update is called once per frame
	void Update() {
		base.UpdateState(); // Mise à jour du statut avec la méthode du parent
		if (this._isButtonActivated && this.HasNormalScale) {
			this._theBall.transform.localScale *= this._coeff;
		} else if (!this._isButtonActivated && !this.HasNormalScale) {
			this._theBall.transform.localScale = this._normalScale;
		}
	}
}
