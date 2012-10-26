using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement des bouton de menu
/// </summary>
public class MenuButtonScript : MonoBehaviour {
	#region Attributes
	/// <summary>
	/// Type du bouton (détermine de l'action à effectuer)
	/// </summary>
	public UtilsScript.MenuButton _buttonType = UtilsScript.MenuButton.Menu;
	/// <summary>
	/// The _coeff.
	/// </summary>
	public float _coeff = 1.5f;
	// Les éléments qui tournent autour du bouton
	public GameObject _animations;
	
	// Permet de savoir si la souris est sur le bouton ou non
	protected bool _isOnMouseOver = false;
	#endregion
	
	#region Untiy Methods
	// Use this for initialization
	void Start () {
		// Initialisation du bouton
		this.InitMenuButton();
		this.AddTheClickListener();
	}
	
	// Quand la souris passe sur le bouton, on exécute les actions adéquates
	void OnMouseEnter() {
		this.StartOnMouseEnterActions();
	}
	// Quand la souris n'est plus sur le bouton, on exécute les actions adéquates
	void OnMouseExit() {
		this.StartOnMouseExitActions();
	}
	#endregion
	
	#region Methods
	// Actions exécutées lorsque la souris passe sur le bouton
	protected void StartOnMouseEnterActions() {
		// On active les animations qu'il faut
		if(this._animations != null) {
			this._animations.SetActiveRecursively(true);
		}
		if(this.transform.parent != null) {
			// On désactive les animations du bouton qui doivent être exécutées quand il n'a pas le focus
			if(this.transform.parent.gameObject.animation != null) {
				this.transform.parent.gameObject.animation.enabled = false;
			}
			// On aggrandit le bouton pour le mettre en avant
			if(this.transform.parent.parent != null) {
				this.transform.parent.parent.localScale *= this._coeff;
			}
		}
		// On active la lumière pour l'éclairer un peu
		if(this.light != null) {
			this.light.enabled = true;
		}
		// On enregistre le fait que la souris est sur le bouton
		this._isOnMouseOver = true;
	}
	
	// Actions exécutées lorsque la souris n'est plus sur le bouton (inverse de la méthode précédente)
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
	
	/// <summary>
	/// Permet d'initialiser le bouton de menu
	/// </summary>
	public void InitMenuButton() {
		if(this._animations == null) {
			// Si aucune animation n'est liée au bouton, on le signale dans les logs
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("animations", this.GetType().ToString(), this.gameObject.name);
		} else {
			// Au début, les animations qui doivent être affichées lors du "mouse over" doivent être désactivées
			this._animations.SetActiveRecursively(false);
		}
	}
	
	// Permet d'ajouter le listener pour le bouton
	protected void AddTheClickListener() {
		//Ajout du listener
		this.GetComponent<ClickListenerScript>().OnClicked += new ClickListenerScript.ActionEventClick(
		() => {
			// Actions effectuées selon le type de bouton
			if(this._buttonType == UtilsScript.MenuButton.LevelDemo){
				// Lancement du Level Demo
				GameClasseScript.Instance.CurrentLevelName = UtilsScript.SceneLevelDemo;
			} else if(this._buttonType == UtilsScript.MenuButton.Menu){
				// Retour au menu
				GameClasseScript.Instance.CurrentLevelName = UtilsScript.SceneMenu;
			} else if(this._buttonType == UtilsScript.MenuButton.Quit){
				// Quitter l'application
				Application.Quit();
			} else if(this._buttonType == UtilsScript.MenuButton.Level1) {
				// Lancement du Level 1
				GameClasseScript.Instance.CurrentLevelName = UtilsScript.SceneLevel1;
			} else if(this._buttonType == UtilsScript.MenuButton.Level2) {
				// Lancement du Level 2
				GameClasseScript.Instance.CurrentLevelName = UtilsScript.SceneLevel2;
			} else if(this._buttonType == UtilsScript.MenuButton.Level3) {
				// Lancement du Level 3
				GameClasseScript.Instance.CurrentLevelName = UtilsScript.SceneLevel3;
				
			} else if(this._buttonType == UtilsScript.MenuButton.RestartLevel) {
				// Lancement du Level en cours, rien à faire, le level est charger à la fin de la méthode
				// On laise le if au cas où dans l'avenir il faut exécuter des actions
			} else if(this._buttonType == UtilsScript.MenuButton.Info) {
				// Lancement de la vue Info
				GameClasseScript.Instance.CurrentLevelName = UtilsScript.SceneInfo;
			} else if(this._buttonType == UtilsScript.MenuButton.Credits) {
				// Lancement de la vue Credits
				GameClasseScript.Instance.CurrentLevelName = UtilsScript.SceneCredits;
			}
			Application.LoadLevel(GameClasseScript.Instance.CurrentLevelName);
		});
	}
	#endregion
}




























