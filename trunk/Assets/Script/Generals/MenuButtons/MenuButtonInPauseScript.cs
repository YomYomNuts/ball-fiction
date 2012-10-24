using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement des bouton de menu
/// </summary>
public class MenuButtonInPauseScript : MenuButtonScript {
	private float lastRealTime = 0.0f;
	
	// Use this for initialization
	void Start () {
		//Ajout du listener
		this.GetComponent<ClickListenerScript>().OnClicked += new ClickListenerScript.ActionEventClick(
		() => {
			Time.timeScale = 1;
		});
		this.InitMenuButton();
		this.AddTheClickListener();
	}
	// Update is called once per frame
	void Update () {
		this.AnimationWithoutTimeScale();
	}
	
	protected void AnimationWithoutTimeScale() {
		if(Time.timeScale == 0) {
			foreach(Transform current in this._animations.transform) {
			    foreach(AnimationState state in current.animation) {
			    	state.weight = 1;
					if(this._isOnMouseOver) {
			    		state.enabled = true;
					}
			        state.time += (Time.realtimeSinceStartup - lastRealTime);
				}
			}
	        foreach(AnimationState state in this.transform.parent.animation) {
	        	state.weight = 1;
					if(!this._isOnMouseOver) {
			    		state.enabled = true;
					}
		        state.time += (Time.realtimeSinceStartup - lastRealTime);
			}
	        lastRealTime = Time.realtimeSinceStartup;
		}
	}
}




























