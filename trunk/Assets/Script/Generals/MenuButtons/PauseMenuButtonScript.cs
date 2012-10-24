using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement des bouton de menu
/// </summary>
public class PauseMenuButtonScript : MenuButtonScript {
	public GameObject _pauseMenu;
	public GameObject[] _objectsToDeactivate;
	
	// Use this for initialization
	void Start () {
		this.InitMenuButton();
		if(this._pauseMenu == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("pause menu", this.GetType().ToString(), this.gameObject.name);
		}
		if(this._objectsToDeactivate == null || this._objectsToDeactivate.Length == 0) {
			Utils.WarningMessageWhenNoGameObjectAssigned("animations to deactivate", this.GetType().ToString(), this.gameObject.name);
		}
		//Ajout du listener
		this.GetComponent<ClickListenerScript>().OnClicked += new ClickListenerScript.ActionEventClick(
		() => {
			Time.timeScale = 0;
			this.StartOnMouseExitActions();
			this.transform.parent.gameObject.SetActiveRecursively(false);
			if(this._pauseMenu != null) {
				this._pauseMenu.SetActiveRecursively(true);
			}
			if(this._objectsToDeactivate != null) {
				for(int i = 0; i < this._objectsToDeactivate.Length; i++) {
					this._objectsToDeactivate[i].SetActiveRecursively(false);
				}
			}
		});
	}
}




























