using UnityEngine;
using System.Collections;

// TODO

/// <summary>
/// Script de comportement des marteaux
/// </summary>
public class HammerScript : MonoBehaviour {
	/// <summary>
	/// La puissance du marche, détermine le nombre de point qu'il enlève
	/// </summary>
	public int _hammerPower = 5;
	
	public GameObject _theBall;

	// Use this for initialization
	void Start () {
		if(this._theBall == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
	}
	
	// Update is called once per frame
	void Update () {}
	
	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject == this._theBall) {
			GameClasse.Instance.IncrementScore(-this._hammerPower);
		}
	}
}
