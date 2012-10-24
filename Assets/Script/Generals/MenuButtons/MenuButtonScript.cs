using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement des bouton de menu
/// </summary>
public class MenuButtonScript : MonoBehaviour {
	/// <summary>
	/// Type du bouton (détermine de l'action à effectuer)
	/// </summary>
	public Utils.MenuButton _buttonType = Utils.MenuButton.Menu;
	/// <summary>
	/// The _coeff.
	/// </summary>
	public float _coeff = 1.5f;
	// Les éléments qui tournent autour du bouton
	public GameObject _animations;
	
	// Permet de savoir si la souris est sur le bouton ou non
	protected bool _isOnMouseOver = false;
	
	// Use this for initialization
	void Start () {
		this.InitMenuButton();
		this.AddTheClickListener();
	}
	
	// Update is called once per frame
	void Update () {}
	
	void OnMouseEnter() {
		this.StartOnMouseEnterActions();
	}
	
	void OnMouseExit() {
		this.StartOnMouseExitActions();
	}
	
	protected void StartOnMouseEnterActions() {
		if(this._animations != null) {
			this._animations.SetActiveRecursively(true);
		}
		if(this.transform.parent != null) {
			if(this.transform.parent.gameObject.animation != null) {
				this.transform.parent.gameObject.animation.enabled = false;
			}
			if(this.transform.parent.parent != null) {
				this.transform.parent.parent.localScale *= this._coeff;
			}
		}
		if(this.light != null) {
			this.light.enabled = true;
		}
		this._isOnMouseOver = true;
	}
	
	protected void StartOnMouseExitActions() {
		if(this._animations != null) {
			this._animations.SetActiveRecursively(false);
		}
		if(this.transform.parent != null) {
			if(this.transform.parent.gameObject.animation != null) {
				this.transform.parent.gameObject.animation.enabled = true;
			}
			if(this.transform.parent.parent != null) {
				this.transform.parent.parent.localScale /= this._coeff;
			}
		}
		if(this.light != null) {
			this.light.enabled = false;
		}
		this._isOnMouseOver = false;
	}
	
	public void InitMenuButton() {
		if(this._animations == null) {
			this._animations = this.transform.parent.FindChild("Animations").gameObject;
		}
		if(this._animations == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("animations", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._animations.SetActiveRecursively(false);
		}
	}
	protected void AddTheClickListener() {
		//Ajout du listener
		this.GetComponent<ClickListenerScript>().OnClicked += new ClickListenerScript.ActionEventClick(
		() => {
			// Chargement du bon level selon le type de bouton
			if(this._buttonType == Utils.MenuButton.LevelDemo){
				GameClasse.Instance.CurrentLevelName = Utils.SceneLevelDemo;
				Application.LoadLevel(GameClasse.Instance.CurrentLevelName);
				
			} else if(this._buttonType == Utils.MenuButton.Menu){
				GameClasse.Instance.CurrentLevelName = Utils.SceneMenu;
				Application.LoadLevel(GameClasse.Instance.CurrentLevelName);
				
			} else if(this._buttonType == Utils.MenuButton.Quitter){
				Application.Quit();
				
			} else if(this._buttonType == Utils.MenuButton.Level1) {
				GameClasse.Instance.CurrentLevelName = Utils.SceneLevel1;
				Application.LoadLevel(GameClasse.Instance.CurrentLevelName);
				
			} else if(this._buttonType == Utils.MenuButton.Level2) {
				GameClasse.Instance.CurrentLevelName = Utils.SceneLevel2;
				Application.LoadLevel(GameClasse.Instance.CurrentLevelName);
				
			} else if(this._buttonType == Utils.MenuButton.Level3) {
				GameClasse.Instance.CurrentLevelName = Utils.SceneLevel3;
				Application.LoadLevel(GameClasse.Instance.CurrentLevelName);
				
			} else if(this._buttonType == Utils.MenuButton.RestartLevel) {
				Application.LoadLevel(GameClasse.Instance.CurrentLevelName);
				
			}
		});
	}
}




























