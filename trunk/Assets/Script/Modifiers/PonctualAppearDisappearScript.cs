using UnityEngine;
using System.Collections;
/// <summary>
/// Script de comportement de l'aggrandissement de la bille
/// </summary>
public class PonctualAppearDisappearScript : PonctualButtonScript {
	#region Attributes
	/// <summary>
	/// Permet de déterminer s'il s'agit d'un bouton pour aparaître (si false, c'est un bouton pour disparaître)
	/// </summary>
	public bool _isAppearButton = false;
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	void Start () {
		if(this.TheBall == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
	}
	#endregion
	
	#region Methods
	// Action effectuée lorsqu'on active le bouton
	override protected void ActionWhenActivated() {
		if(this.TheBall != null && this.IsActivated) {
			// Quand le bouton est activé, on faire apparaître ou disparaître la bille selon le bouton
			this.TheBall.renderer.enabled = _isAppearButton;
		}
	}
	#endregion
}
