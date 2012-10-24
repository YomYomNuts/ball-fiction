using UnityEngine;
using System;

/// <summary>
/// Script de comportement d'un bouton qui ouvre et ferme la porte quand on appuie dessus
/// </summary>
public class OnOffButtonForDoorScript : OnOffButtonScript {
	/// <summary>
	/// La porte que le bouton ouvre
	/// </summary>
    public GameObject _theDoor;
	
	// True s'il faut ouvrir la porte
	private bool _hasToBeOpened = false;
	// True s'il faut fermer la porte
	private bool _hasToBeClosed = false;
	
	// Use this for initialization
	void Start () {
		if(this._theBall == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
		if(this._theDoor == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("door", this.GetType().ToString(), this.gameObject.name);
		} else if(this._theDoor.GetComponent<DoorScript>() == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("door script", this.GetType().ToString(), this.gameObject.name);
		}
	}
	
	// Action effectuée lorsque le bouton est activé
	override protected void ActionWhenActivated() {
		this._hasToBeOpened = true;
	}
	// Action effectuée lorsque le bouton est activé
	override protected void ActionWhenNonActivated() {
		this._hasToBeClosed = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(this._theDoor != null && this._theDoor.GetComponent<DoorScript>() != null) {
			if(this._hasToBeOpened) {
				this._theDoor.GetComponent<DoorScript>().OpenTheDoor();
				if(this._theDoor.GetComponent<DoorScript>().IsOpened) {
					this._hasToBeOpened = false;
				}
			} else if(this._hasToBeClosed) {
				this._theDoor.GetComponent<DoorScript>().CloseTheDoor();
				if( ! this._theDoor.GetComponent<DoorScript>().IsOpened) {
					this._hasToBeClosed = false;
				}
			}
		}
	}
}
