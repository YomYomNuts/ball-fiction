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
	
	// Les cubes qui tournent autour du bouton
	private GameObject _cubes;
	
	// Use this for initialization
	void Start () {
		this._cubes = this.transform.parent.FindChild("Cubes").gameObject;
		this._cubes.SetActiveRecursively(false);
		//Ajout du listener
		this.GetComponent<ClickListenerScript>().OnClicked += new ClickListenerScript.ActionEventClick(
		() => {
			// Chargement du bon level selon le type de bouton
			if(_buttonType == Utils.MenuButton.LevelDemo){
				GameClasse.Instance.CurrentLevelName = Utils.SceneLevelDemo;
				
			} else if(_buttonType == Utils.MenuButton.Menu){
				GameClasse.Instance.CurrentLevelName = Utils.SceneMenu;
				
			} else if(_buttonType == Utils.MenuButton.Quitter){
				Application.Quit();
				
			} else if(_buttonType == Utils.MenuButton.Level1) {
				GameClasse.Instance.CurrentLevelName = Utils.SceneLevel1;
				
			} else if(_buttonType == Utils.MenuButton.Level2) {
				GameClasse.Instance.CurrentLevelName = Utils.SceneLevel2;
				
			} else if(_buttonType == Utils.MenuButton.Level3) {
				GameClasse.Instance.CurrentLevelName = Utils.SceneLevel3;
			}
			Application.LoadLevel(GameClasse.Instance.CurrentLevelName);
		});
	}
	
	// Update is called once per frame
	void Update () {}
	
	void OnMouseEnter() {
		this._cubes.SetActiveRecursively(true);
	}
	
	void OnMouseExit() {
		this._cubes.SetActiveRecursively(false);
	}
}
