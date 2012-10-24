using UnityEngine;
using System.Collections;
/// <summary>
/// Script de comportement de l'aggrandissement de la bille (ponctuel)
/// </summary>
public class PonctualChangeViewScript : PonctualButtonScript {
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
	
	// Use this for initialization
	void Start () {
		if(this.TheBall == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		} else if(this.TheBall.GetComponent<BallScript>() == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("ball script", this.GetType().ToString(), this.gameObject.name);
		}
	}
	
	// Update is called once per frame
	override protected void ActionWhenActivated() {
		if(this.TheBall != null && this.TheBall.GetComponent<BallScript>() != null) {
			this.TheBall.GetComponent<BallScript>()._cameraHigh = this._cameraHigh;
			this.TheBall.GetComponent<BallScript>()._cameraRetreat = this._cameraRetreat;
		}
	}
}
