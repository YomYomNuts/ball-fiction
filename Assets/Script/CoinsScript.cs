using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement des pièces
/// </summary>
public class CoinsScript : MonoBehaviour {
	/// <summary>
	/// Valeur de la pièce
	/// </summary>
    public int _valueCoins = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Collision pour augmenter le score
	void OnTriggerEnter(Collider collision) {
		GameClasse.Instance.IncrementScore(this._valueCoins);
		this.gameObject.active = false;
	}
}