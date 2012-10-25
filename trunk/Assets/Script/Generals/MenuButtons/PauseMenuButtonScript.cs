using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement du bouton de pause
/// </summary>
public class PauseMenuButtonScript : MenuButtonScript {
	/// <summary>
	/// Les objets qui doivent être "activés" lors de la pause (notamment le menu de pause)
	/// </summary>
	public GameObject[] _objectsToActivate;
	/// <summary>
	/// Les objets qui doivent être "désactivés" lors de la pause (notamment le bouton de pause lui-même)
	/// </summary>
	public GameObject[] _objectsToDeactivate;
	
	// Use this for initialization
	void Start () {
		// On initialise le MenuButton (voir la classe MenuButton)
		this.InitMenuButton();
		
		// Si aucun objet à "désactiver" ou à "activer" n'est lié au bouton, on le signale dans les logs
		if(this._objectsToDeactivate == null || this._objectsToDeactivate.Length == 0) {
			Utils.WarningMessageWhenNoGameObjectAssigned("objects to deactivate", this.GetType().ToString(), this.gameObject.name);
		}
		if(this._objectsToActivate == null || this._objectsToActivate.Length == 0) {
			Utils.WarningMessageWhenNoGameObjectAssigned("objects to activate", this.GetType().ToString(), this.gameObject.name);
		} else { // Si les objets à "activer" lors de la pause sont présents, on les "désactive" pour l'instant
			for(int i = 0; i < this._objectsToActivate.Length; i++) {
				// La "désactivation" consiste au déplacement de l'objet pour qu'il ne soit plus visible par la caméra
				//this._objectsToActivate[i].transform.localPosition += new Vector3(Utils.Decalage, 0, 0);
				Utils.HideObject(this._objectsToActivate[i]);
			}
		}
		//Ajout du listener
		this.GetComponent<ClickListenerScript>().OnClicked += new ClickListenerScript.ActionEventClick(
		() => {
			Time.timeScale = 0; // On met le jeu en pause
			// On "active" les objets à "activer"
			if(this._objectsToActivate != null) {
				for(int i = 0; i < this._objectsToActivate.Length; i++) {
					//this._objectsToActivate[i].transform.localPosition -= new Vector3(Utils.Decalage, 0, 0);
					Utils.ShowObject(this._objectsToActivate[i]);
				}
			}
			// On "désactive" les objets à "désactiver"
			if(this._objectsToDeactivate != null) {
				for(int i = 0; i < this._objectsToDeactivate.Length; i++) {
					//this._objectsToDeactivate[i].transform.localPosition += new Vector3(Utils.Decalage, 0, 0);
					Utils.HideObject(this._objectsToDeactivate[i]);
				}
			}
		});
	}
}




























