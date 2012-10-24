using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement des bouton de menu
/// </summary>
public class PauseMenuButtonScript : MenuButtonScript {
	public GameObject[] _objectsToActivate;
	public GameObject[] _objectsToDeactivate;
	
	// Use this for initialization
	void Start () {
		this.InitMenuButton();
		if(this._objectsToDeactivate == null || this._objectsToDeactivate.Length == 0) {
			Utils.WarningMessageWhenNoGameObjectAssigned("objects to deactivate", this.GetType().ToString(), this.gameObject.name);
		}
		if(this._objectsToActivate == null || this._objectsToActivate.Length == 0) {
			Utils.WarningMessageWhenNoGameObjectAssigned("objects to activate", this.GetType().ToString(), this.gameObject.name);
		} else {
			for(int i = 0; i < this._objectsToActivate.Length; i++) {
				this._objectsToActivate[i].transform.localPosition += new Vector3(Utils.Decalage, 0, 0);
			}
		}
		//Ajout du listener
		this.GetComponent<ClickListenerScript>().OnClicked += new ClickListenerScript.ActionEventClick(
		() => {
			Time.timeScale = 0;
			if(this._objectsToActivate != null) {
				for(int i = 0; i < this._objectsToActivate.Length; i++) {
					this._objectsToActivate[i].transform.localPosition -= new Vector3(Utils.Decalage, 0, 0);
				}
			}
			if(this._objectsToDeactivate != null) {
				for(int i = 0; i < this._objectsToDeactivate.Length; i++) {
					this._objectsToDeactivate[i].transform.localPosition += new Vector3(Utils.Decalage, 0, 0);
				}
			}
		});
	}
}




























