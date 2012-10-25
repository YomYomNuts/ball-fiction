using UnityEngine;
using System;

/// <summary>
/// Script de comportement d'une porte qui s'ouvre puis attend un moment avant de se refermer
/// </summary>
public class TimedButtonForDoorScript : TimedButtonScript {
	/// <summary>
	/// La porte que le bouton ouvre
	/// </summary>
    public GameObject _theDoor;
	
	// Use this for initialization
	void Start () {
		if(this.TheBall == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
		if(this._theDoor == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("door", this.GetType().ToString(), this.gameObject.name);
		} else if(this._theDoor.GetComponent<DoorScript>() == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("door script", this.GetType().ToString(), this.gameObject.name);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(this._theDoor != null) {
			base.UpdateState();
			if(this.IsActivated) {
				this._theDoor.GetComponent<DoorScript>().OpenTheDoor();
				// On joue le son associé
				if(this.audio != null) {
					AudioSource.PlayClipAtPoint(this.audio.clip, Camera.main.transform.position);
				}
			} else {
				this._theDoor.GetComponent<DoorScript>().CloseTheDoor();
			}
		}
	}
}
