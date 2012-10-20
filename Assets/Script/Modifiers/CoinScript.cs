using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement des pièces
/// </summary>
public class CoinScript : PonctualButtonScript {
	/// <summary>
	/// Valeur de la pièce
	/// </summary>
    public int _valueCoins = 1;

	// Use this for initialization
	void Start () {
		if(this._theBall == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Action effectuée lorsque le bouton est activé
	override protected void ActionWhenActivated() {
		GameClasse.Instance.IncrementScore(this._valueCoins);
		this.gameObject.active = false;
	}
	// Action effectuée lorsque le bouton est activé
	override protected void ActionWhenNonActivated() {}
}
