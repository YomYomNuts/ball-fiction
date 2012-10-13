using UnityEngine;
using System.Collections;

/// <summary>
/// Script parent pour tous les éléments pouvant être activé par un bouton
/// </summary>
public class ElementScript : MonoBehaviour {
	/// <summary>
	/// True si le bouton a été activé
	/// </summary>
    public bool _isButtonActivated = false;
	
	/// <summary>
	/// Vitesse de l'action effectué lors de l'activation du bouton
	/// </summary>
	public float _elementSpeed = 0.1f;
	
	/// <summary>
	/// Le temps que l'objet attend avant de revenir à sa forme initiale
	/// </summary>
	public float _time = 150f;
	
	/// <summary>
	/// Vitesse à laquelle le temps augmente
	/// </summary>
	public float _timeSpeed = 1f;
	
	/// <summary>
	/// True si le temps de l'animation est terminé
	/// </summary>
	public bool isTimeOver {
		get {
			return this._currentTime >= this._time;
		}
	}
	
	/// <summary>
	/// Le temps passé depuis l'activation
	/// </summary>
	private float _currentTime = 0.0f;
	
	/// <summary>
	/// Met à jour l'état de l'élément, en cours d'animation => fin d'animation
	/// </summary>
	public void UpdateState() {
		// On vérifie que "l'animation" a débuté, si c'est le cas, on incrémente le "timer" jusqu'à la fin
		if(this._isButtonActivated) {
			if(this.isTimeOver) {
				this._currentTime = 0.0f;
				this._isButtonActivated = false;
			} else {
				this._currentTime += this._timeSpeed;
			}
		}
	}
}
