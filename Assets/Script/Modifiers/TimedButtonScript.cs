using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement d'un bouton avec timer
/// </summary>
public class TimedButtonScript : MonoBehaviour {
	// Permet de savoir si le bouton est activé ou désactivé
	public bool _isActivated = false;
	// Le temps passé depuis l'activation
	private float _currentTime = 0.0f;
	
	/// <summary>
	/// True si on veut que l'activation se déroule OnEnter, false si on veut OnExit
	/// </summary>
    public bool _onEnter = true;
	/// <summary>
	/// Le temps que l'objet attend avant de revenir à sa forme initiale
	/// </summary>
	public float _time = 150f;
	/// <summary>
	/// Vitesse à laquelle le temps augmente
	/// </summary>
	public float _timeSpeed = 1f;
	
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
	/// <summary>
	/// True si le temps de l'animation est terminé
	/// </summary>
	public bool isTimeOver {
		get {
			return this._currentTime >= this._time;
		}
	}
	
	/// <summary>
	/// Met à jour l'état de l'élément, en cours d'animation => fin d'animation
	/// </summary>
	public void UpdateState() {
		// On vérifie que "l'animation" a débuté, si c'est le cas, on incrémente le "timer" jusqu'à la fin
		if(this.IsActivated) {
			if(this.isTimeOver) {
				this._currentTime = 0.0f;
				this.IsActivated = false;
			} else {
				this._currentTime += this._timeSpeed;
			}
		}
	}
	
	// Trigger pour activer le boutton
	void OnTriggerEnter(Collider collision) {
		if(this._onEnter) {
			this.ActivateTheButton();
		}
	}
	
	// Trigger pour activer le boutton
	void OnTriggerExit(Collider collision) {
		if(! this._onEnter) {
			this.ActivateTheButton();
		}
	}
	
	private void ActivateTheButton() {
		this._currentTime = 0.0f;
		this.IsActivated = true;
	}
}
