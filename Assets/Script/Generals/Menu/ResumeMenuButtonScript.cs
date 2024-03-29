using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement du bouton de reprise de pause
/// </summary>
public class ResumeMenuButtonScript : MenuButtonInPauseScript {
	#region Attributes
	/// <summary>
	/// Les objets qui doivent être "activés" lors de la reprise de pause (notamment le bouton de pause)
	/// </summary>
	public GameObject[] _objectsToActivate;
	/// <summary>
	/// Les objets qui doivent être "désactivés" lors de la reprise de pause (notamment le menu de pause)
	/// </summary>
	public GameObject[] _objectsToDeactivate;
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	void Start () {
		// On initialise le MenuButton (voir la classe MenuButton)
		this.InitMenuButton();
		
		// Si aucun objet à "désactiver" ou à "activer" n'est lié au bouton, on le signale dans les logs
		if(this._objectsToDeactivate == null || this._objectsToDeactivate.Length == 0) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("objects to deactivate", this.GetType().ToString(), this.gameObject.name);
		}
		if(this._objectsToActivate == null || this._objectsToActivate.Length == 0) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("objects to activate", this.GetType().ToString(), this.gameObject.name);
		}
		//Ajout du listener
		this.GetComponent<ClickListenerScript>().OnClicked += new ClickListenerScript.ActionEventClick(
		() => {
			// On "active" les objets à "activer"
			if(this._objectsToActivate != null) {
				for(int i = 0; i < this._objectsToActivate.Length; i++) {
					UtilsScript.ShowObject(this._objectsToActivate[i]);
				}
			}
			// On "désactive" les objets à "désactiver"
			if(this._objectsToDeactivate != null) {
				for(int i = 0; i < this._objectsToDeactivate.Length; i++) {
					UtilsScript.HideObject(this._objectsToDeactivate[i]);
				}
			}
			// On relance le jeu
			Time.timeScale = 1;
		});
	}
	
	// Update is called once per frame
	void Update () {
		// Les boutons du menu de pause doivent être animés même quand le TimeScale est à 0
		this.AnimationWithoutTimeScale();
	}
	#endregion
}




























