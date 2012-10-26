using UnityEngine;
using System;

/// <summary>
/// Script de comportement d'un bouton qui ouvre ou ferme une porte
/// </summary>
public class PonctualButtonForDoorScript : PonctualButtonScript {
	#region Attributes
	// True s'il faut ouvrir la porte
	private bool _hasToBeOpened = false;
	// True s'il faut fermer la porte
	private bool _hasToBeClosed = false;
	
	/// <summary>
	/// La porte que le bouton ouvre
	/// </summary>
    public GameObject _theDoor;
	/// <summary>
	/// Permet de savoir si le script est fait pour ouvrir la porte, ou pour la fermer
	/// </summary>
	public bool _isToOpen = true;
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	void Start () {
		if(this.TheBall == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
		if(this._theDoor == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("door", this.GetType().ToString(), this.gameObject.name);
		} else if(this._theDoor.GetComponent<DoorScript>() == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("door script", this.GetType().ToString(), this.gameObject.name);
		}
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
	#endregion
	
	#region Methods
	// Action effectuée lorsque le bouton est activé
	override protected void ActionWhenActivated() {
		if(this._isToOpen) {
			this._hasToBeOpened = true;
		} else {
			this._hasToBeClosed = true;
		}
	}
	#endregion
}
