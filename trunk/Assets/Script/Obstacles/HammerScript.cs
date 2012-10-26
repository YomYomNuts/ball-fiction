using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement des marteaux
/// </summary>
public class HammerScript : MonoBehaviour {
	#region Attributes
	/// <summary>
	/// La puissance du marche, détermine le nombre de point qu'il enlève
	/// </summary>
	public int _hammerPower = 5;
	/// <summary>
	/// La bille
	/// </summary>
	public GameObject _theBall;
	
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
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	void Start () {
		if(this.TheBall == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
	}
	
	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject == this.TheBall) {
			// On joue le son associé
			if(this.audio != null && this.audio.clip != null) {
				AudioSource.PlayClipAtPoint(this.audio.clip, Camera.main.transform.position);
			}
			GameClasseScript.Instance.IncrementScore(-this._hammerPower);
		}
	}
	#endregion
}
