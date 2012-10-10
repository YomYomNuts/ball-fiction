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
				Application.LoadLevel(Utils.SceneLevelProto);
			} else if(_buttonType == Utils.MenuButton.LevelDemo){
				Application.LoadLevel(Utils.SceneLevelDemo);
			} else if(_buttonType == Utils.MenuButton.Quitter){
				Application.Quit();
			} else if(_buttonType == Utils.MenuButton.Menu){
				Application.LoadLevel(Utils.SceneMenu);
			}
		});
	}
	
	// Update is called once per frame
	void Update () {
	}
}
