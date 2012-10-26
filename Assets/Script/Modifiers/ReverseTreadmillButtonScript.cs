using UnityEngine;
using System.Collections;

/// <summary>
/// Script général de comportement d'un bouton qui est activé/désactivé quand on appuie dessus
/// </summary>
public class ReverseTreadmillButtonScript : OnOffButtonScript {
	#region Attributes
	/// <summary>
	/// The breadmils which have to be inversed
	/// </summary>
	public GameObject _theTreadmills;
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	void Start () {
		if(this.TheBall == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
		if(this._theTreadmills == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("treadmills", this.GetType().ToString(), this.gameObject.name);
		}
	}
	#endregion
	
	// Actions à effectuées lorsque le bouton est activé
	override protected void ActionWhenActivated() {
		if(this._theTreadmills != null) {
			foreach(Transform current in this._theTreadmills.transform) {
				current.gameObject.GetComponent<TreadmillScript>().InverseDirection();
			}
		}
	}
	
	// Actions à effectuées lorsque le bouton est desactivé
	override protected void ActionWhenNonActivated() {
		this.ActionWhenActivated();
	}
}
