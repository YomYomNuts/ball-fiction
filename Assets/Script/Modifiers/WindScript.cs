using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement du vent
/// </summary>
public class WindScript : MonoBehaviour {
	/// <summary>
	/// La force avec laquelle le vent agit sur la bille
	/// </summary>
    public float _windForce = 5f;
	/// <summary>
	/// Direction dans laquelle le vent "pousse" la bille
	/// </summary>
    public Utils.Direction _windDirection = Utils.Direction.Left;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Trigger pour augmenter le score
	void OnTriggerStay(Collider collider) {
		// On applique la force selon la direction
		if(this._windDirection == Utils.Direction.Forward) {
			collider.gameObject.rigidbody.AddForce(Vector3.forward * this._windForce);
		} else if(this._windDirection == Utils.Direction.Back) {
			collider.gameObject.rigidbody.AddForce(Vector3.back * this._windForce);
		} else if(this._windDirection == Utils.Direction.Left) {
			collider.gameObject.rigidbody.AddForce(Vector3.left * this._windForce);
		} else if(this._windDirection == Utils.Direction.Right) {
			collider.gameObject.rigidbody.AddForce(Vector3.right * this._windForce);
		} else if(this._windDirection == Utils.Direction.Up) {
			collider.gameObject.rigidbody.AddForce(Vector3.up * this._windForce);
		} else if(this._windDirection == Utils.Direction.Down) {
			collider.gameObject.rigidbody.AddForce(Vector3.down * this._windForce);
		}
	}
}
