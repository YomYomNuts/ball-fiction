using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement d'un bouton avec timer
/// </summary>
public class TimedButtonScript : MonoBehaviour {
	#region Attributes
	// Le temps passé depuis l'activation
	private float _currentTime = 0.0f;
	
	/// <summary>
	/// La bille
	/// </summary>
	public GameObject _theBall;
	/// <summary>
	/// Permet de savoir si le bouton est activé ou désactivé
	/// </summary>
	public bool _isActivated = false;
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
	/// <summary>
	/// True si le temps de l'animation est terminé
	/// </summary>
	public bool isTimeOver {
		get {
			return this._currentTime >= this._time;
		}
	}
	#endregion
	
	#region Unity Methods
	/// <summary>
	/// Met à jour l'état de l'élément, en cours d'animation => fin d'animation
	/// </summary>
	public void UpdateState() {
		// On vérifie que "l'animation" a débuté, si c'est le cas, on incrémente le "timer" jusqu'à la fin
		if(Time.timeScale == 1 && this.IsActivated) {
			if(this.isTimeOver) {
				this._currentTime = 0.0f;
				this.IsActivated = false;
			} else {
				this._currentTime += this._timeSpeed;
			}
		}
	}
	
	// Trigger pour activer le boutton
	void OnTriggerEnter(Collider collider) {
		if(this._onEnter) {
			this.ActivateTheButton(collider);
		}
	}
	
	// Trigger pour activer le boutton
	void OnTriggerExit(Collider collider) {
		if(! this._onEnter) {
			this.ActivateTheButton(collider);
		}
	}
	#endregion
	
	#region Methods
	private void ActivateTheButton(Collider collider) {
		if(this.TheBall == collider.gameObject) {
			// On joue le son associé
			if(this.audio != null && this.audio.clip != null) {
				AudioSource.PlayClipAtPoint(this.audio.clip, Camera.main.transform.position);
			}
			this._currentTime = 0.0f;
			this.IsActivated = true;
		}
	}
	#endregion
}
