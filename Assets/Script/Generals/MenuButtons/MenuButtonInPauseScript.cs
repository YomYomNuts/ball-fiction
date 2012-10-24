using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement des boutons dans le menu de pause
/// </summary>
public class MenuButtonInPauseScript : MenuButtonScript {
	// Permet de faire avancer l'animation normalement avec le time scale à 0
	private float lastRealTime = 0.0f;
	
	// Use this for initialization
	void Start () {
		//Ajout du listener
		this.GetComponent<ClickListenerScript>().OnClicked += new ClickListenerScript.ActionEventClick(
		() => {
			Time.timeScale = 1; // Quand on clique sur un bouton du menu pause, ça arrête la pause
		});
		// On initialise le MenuButton et on ajoute le listener général (voir la classe MenuButton)
		this.InitMenuButton();
		this.AddTheClickListener();
	}
	// Update is called once per frame
	void Update () {
		// Les boutons du menu de pause doivent être animés même quand le TimeScale est à 0
		this.AnimationWithoutTimeScale();
	}
	
	/// <summary>
	/// Permet de faire fonctionner l'animation quand le TimeScale est à 0
	/// </summary>
	protected void AnimationWithoutTimeScale() {
		if(Time.timeScale == 0) { // On vérifie qu'il est à 0, sinon, l'animation va 2 fois plus vite s'il est à 1
			// La boucle suivante permet d'obtenir les animations des boules autour du bouton (OnMouseOver)
			foreach(Transform current in this._animations.transform) {
			    foreach(AnimationState state in current.animation) {
			    	state.weight = 1;
					if(this._isOnMouseOver) { // On ne l'affiche seulement si la souris est sur le bouton
			    		state.enabled = true;
					}
					// Cette ligne permet de faire avancer l'animation
			        state.time += (Time.realtimeSinceStartup - lastRealTime);
				}
			}
			// La boucle suivante permet d'obtenir les animations du bouton
	        foreach(AnimationState state in this.transform.parent.animation) {
	        	state.weight = 1;
					if(!this._isOnMouseOver) {
			    		state.enabled = true; // On ne l'affiche seulement si la souris N'est PAS sur le bouton
					}
		        state.time += (Time.realtimeSinceStartup - lastRealTime);
			}
			// On enregistre le lastRealTime pour pouvoir faire avancer l'animation
	        lastRealTime = Time.realtimeSinceStartup;
		}
	}
}




























