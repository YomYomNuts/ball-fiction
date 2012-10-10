using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement des bouton de menu
/// </summary>
public class MenuButtonScript : MonoBehaviour {
	
	/// <summary>
	/// Type du bouton (détermine de l'action à effectuer)
	/// </summary>
	public Utils.MenuButton _buttonType = Utils.MenuButton.Quitter;
	
	// Use this for initialization
	void Start () {
		//Ajout du listener
		this.GetComponent<ClickListenerScript>().OnClicked += new ClickListenerScript.ActionEventClick(
		() => { // Chargement du bon level selon le type de bouton
			if(_buttonType == Utils.MenuButton.LevelProto) {
				Debug.Log("Level Proto");
				Application.LoadLevel(Utils.SceneLevelProto);
			} else if(_buttonType == Utils.MenuButton.Quitter){
				Debug.Log("Quitter");
				Application.Quit();
			} else if(_buttonType == Utils.MenuButton.Menu){
				Debug.Log("Menu");
				Application.LoadLevel(Utils.SceneMenu);
			}
		});
	}
	
	// Update is called once per frame
	void Update () {
	}
}
