using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement des pièces
/// </summary>
public class CoinScript : PonctualButtonScript {
	#region Attributes
	/// <summary>
	/// Valeur de la pièce
	/// </summary>
    public int _valueCoins = 1;
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	void Start () {
		if(this.TheBall == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	#endregion
	
	#region Methods
	// Action effectuée lorsque le bouton est activé
	override protected void ActionWhenActivated() {
		GameClasseScript.Instance.IncrementScore(this._valueCoins);
		this.gameObject.SetActiveRecursively(false);
	}
	#endregion
}
