using UnityEngine;
using System.Collections;
/// <summary>
/// Script de comportement du changement de caméra
/// </summary>
public class PonctualChangeViewScript : PonctualButtonScript {
	#region Attributes
	// Le scale de base de la bille
	private Vector3 _normalScale;
	
	/// <summary>
	/// La hauteur de la caméra par rapport à la bille
	/// </summary>
	public float _cameraHigh = 0f;
	/// <summary>
	/// Le recul de la caméra par rapport à la bille
	/// </summary>
	public float _cameraRetreat = 0f;
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	void Start () {
		if(this.TheBall == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		} else if(this.TheBall.GetComponent<BallScript>() == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("ball script", this.GetType().ToString(), this.gameObject.name);
		}
	}
	#endregion
	
	#region Methods
	// Action effectuée lorsqu'on active le bouton
	override protected void ActionWhenActivated() {
		if(this.TheBall != null && this.TheBall.GetComponent<BallScript>() != null) {
			// On change la position de la camera
			this.TheBall.GetComponent<BallScript>()._cameraHigh = this._cameraHigh;
			this.TheBall.GetComponent<BallScript>()._cameraRetreat = this._cameraRetreat;
		}
	}
	#endregion
}
