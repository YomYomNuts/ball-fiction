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
		() => {
			// Chargement du bon level selon le type de bouton
			if(_buttonType == Utils.MenuButton.LevelProto) {
				GameClasse.Instance.CurrentLevelName = Utils.SceneLevelProto;
				Application.LoadLevel(Utils.SceneLevelProto);
			} else if(_buttonType == Utils.MenuButton.LevelDemo){
				GameClasse.Instance.CurrentLevelName = Utils.SceneLevelDemo;
				Application.LoadLevel(Utils.SceneLevelDemo);
			} else if(_buttonType == Utils.MenuButton.RestartLevel){
				Application.LoadLevel(GameClasse.Instance.CurrentLevelName);
			} else if(_buttonType == Utils.MenuButton.Menu){
				GameClasse.Instance.CurrentLevelName = Utils.SceneMenu;
				Application.LoadLevel(Utils.SceneMenu);
			} else if(_buttonType == Utils.MenuButton.Quitter){
				Application.Quit();
			}
		});
	}
	
	// Update is called once per frame
	void Update () {
	}
}
