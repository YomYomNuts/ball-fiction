using UnityEngine;
using System;

/// <summary>
/// Script de comportement d'une porte qui s'ouvre puis attend un moment avant de se refermer
/// </summary>
public class TimedButtonForDoorScript : TimedButtonScript {
	#region Attributes
	/// <summary>
	/// La porte que le bouton ouvre
	/// </summary>
    public GameObject _theDoor;
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
		if(this._theDoor != null) {
			base.UpdateState();
			if(this.IsActivated) {
				this._theDoor.GetComponent<DoorScript>().OpenTheDoor();
			} else {
				this._theDoor.GetComponent<DoorScript>().CloseTheDoor();
			}
		}
	}
	#endregion
}
