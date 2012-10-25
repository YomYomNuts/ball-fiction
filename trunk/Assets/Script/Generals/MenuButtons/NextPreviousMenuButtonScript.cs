using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement des bouton de menu pour page suivante et précédente
/// </summary>
public class NextPreviousMenuButtonScript : MenuButtonScript {
	public bool _isNextButton = true;
	// Use this for initialization
	void Start () {
		// Initialisation du bouton
		this.InitMenuButton();
		//Ajout du listener
		this.GetComponent<ClickListenerScript>().OnClicked += new ClickListenerScript.ActionEventClick(
		() => {
			if(this._isNextButton) {
				PagesNavigatorScript.Instance.NextPage();
			} else {
				PagesNavigatorScript.Instance.PreviousPage();
			}
		});
	}
}




























