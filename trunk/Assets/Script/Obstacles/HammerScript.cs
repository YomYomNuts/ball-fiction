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

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}
	
	void OnTriggerEnter(Collider collision) {
		GameClasse.Instance.IncrementScore(-this._hammerPower);
	}
}
