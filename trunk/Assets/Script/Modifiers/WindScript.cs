using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement du vent
/// </summary>
public class WindScript : MonoBehaviour {
	#region Attributes
	/// <summary>
	/// La force avec laquelle le vent agit sur la bille
	/// </summary>
    public float _windForce = 5f;
	/// <summary>
	/// Direction dans laquelle le vent "pousse" la bille
	/// </summary>
    public UtilsScript.Direction _windDirection = UtilsScript.Direction.Left;
	#endregion
	
	#region Unity Methods
	// Fonction effectuée au moment où un objet entre dans le trigger
	void OnTriggerEnter(Collider collider) {
		// On joue le son associé
		if(this.audio != null && this.audio.clip != null) {
			AudioSource.PlayClipAtPoint(this.audio.clip, Camera.main.transform.position);
		}
	}
	
	// Fonction effectuée pendant que le objet est dans le trigger
	void OnTriggerStay(Collider collider) {
		// On applique la force selon la direction
		if(this._windDirection == UtilsScript.Direction.Forward) {
			collider.gameObject.rigidbody.AddForce(Vector3.forward * this._windForce);
		} else if(this._windDirection == UtilsScript.Direction.Back) {
			collider.gameObject.rigidbody.AddForce(Vector3.back * this._windForce);
		} else if(this._windDirection == UtilsScript.Direction.Left) {
			collider.gameObject.rigidbody.AddForce(Vector3.left * this._windForce);
		} else if(this._windDirection == UtilsScript.Direction.Right) {
			collider.gameObject.rigidbody.AddForce(Vector3.right * this._windForce);
		} else if(this._windDirection == UtilsScript.Direction.Up) {
			collider.gameObject.rigidbody.AddForce(Vector3.up * this._windForce);
		} else if(this._windDirection == UtilsScript.Direction.Down) {
			collider.gameObject.rigidbody.AddForce(Vector3.down * this._windForce);
		}
	}
	#endregion
}
