using UnityEngine;
using System.Collections;

/// <summary>
/// Script général de comportement d'un bouton qui est activé/désactivé quand on appuie dessus
/// </summary>
public class ReduceBallSpeedScript : PonctualButtonScript {
	/// <summary>
	/// The breadmils which have to be inversed
	/// </summary>
	public GameObject _theBall;
	
	// Use this for initialization
	void Start () {
		if(this._theBall == null) {
			Debug.LogWarning("There is no ball assigned to a ReduceBallSpeedScript");
		}
	}
	
	// Update is called once per frame
	void Update () {}
	
	override protected void ActionWhenActivated() {
		if(this._theBall != null) {
			this._theBall.rigidbody.velocity = Vector3.zero;
		}
	}
	
	override protected void ActionWhenNonActivated() {
		this.ActionWhenActivated();
	}
}
