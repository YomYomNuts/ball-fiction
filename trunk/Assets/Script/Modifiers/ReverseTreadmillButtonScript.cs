using UnityEngine;
using System.Collections;

/// <summary>
/// Script général de comportement d'un bouton qui est activé/désactivé quand on appuie dessus
/// </summary>
public class ReverseTreadmillButtonScript : OnOffButtonScript {
	/// <summary>
	/// The breadmils which have to be inversed
	/// </summary>
	public GameObject _theTreadmills;
	
	// Use this for initialization
	void Start () {
		if(this.TheBall == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
		if(this._theTreadmills == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("treadmills", this.GetType().ToString(), this.gameObject.name);
		}
	}
	
	// Update is called once per frame
	void Update () {}
	
	override protected void ActionWhenActivated() {
		if(this._theTreadmills != null) {
			foreach(Transform current in this._theTreadmills.transform) {
				current.gameObject.GetComponent<TreadmillScript>().InverseDirection();
			}
		}
	}
	
	override protected void ActionWhenNonActivated() {
		this.ActionWhenActivated();
	}
}
