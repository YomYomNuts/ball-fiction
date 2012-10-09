using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement des tapis roulants
/// </summary>
public class BreadmillScript : MonoBehaviour {
	/// <summary>
	/// La force avec laquelle les tapis roulants agissent sur la bille
	/// </summary>
    public float _ballForce = 0.5f;
	
	/// <summary>
	/// Direction dans laquelle le tapis roulants "pousse" la bille
	/// </summary>
    public Utils.Direction _ballDirection = Utils.Direction.Forward;

	// Use this for initialization
	void Start () {
		// On affiche la bonne texture selon la direction
		Texture texture = null;
		if(this._ballDirection == Utils.Direction.Forward) {
			texture = Resources.Load("Data/forward_arrow", typeof(Texture)) as Texture;
		} else if(this._ballDirection == Utils.Direction.Back) {
			texture = Resources.Load("Data/back_arrow", typeof(Texture)) as Texture;
			
			// TODO textures non encore implémentés
			
//		} else if(this._ballDirection == Utils.Direction.Left) {
//			texture = Resources.Load("Data/back_arrow", typeof(Texture)) as Texture;
//		} else if(this._ballDirection == Utils.Direction.Right) {
//			texture = Resources.Load("Data/back_arrow", typeof(Texture)) as Texture;
//		} else if(this._ballDirection == Utils.Direction.Up) {
//			texture = Resources.Load("Data/back_arrow", typeof(Texture)) as Texture;
//		} else if(this._ballDirection == Utils.Direction.Down) {
//			texture = Resources.Load("Data/back_arrow", typeof(Texture)) as Texture;
			
		}
		this.gameObject.renderer.material.mainTexture = texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/// <summary>
	/// Collision pour faire bouger la bille
	/// </summary>
	/// <param name='collision'>
	/// Collision.
	/// </param>
	void OnCollisionStay(Collision collision) {
		// Variable locale contenant le script BallScript
		BallScript ball = collision.gameObject.GetComponent<BallScript>();
		// On vérifie que la bille n'a pas encore atteint sa vitesse maximale
		if(Mathf.Abs(collision.gameObject.rigidbody.velocity.x) < Mathf.Abs(ball._absolueVectorForceBall.x) && 
			Mathf.Abs(collision.gameObject.rigidbody.velocity.y) < Mathf.Abs(ball._absolueVectorForceBall.y) && 
			Mathf.Abs(collision.gameObject.rigidbody.velocity.z) < Mathf.Abs(ball._absolueVectorForceBall.z)) {
			// On applique la force selon la direction
			if(this._ballDirection == Utils.Direction.Forward) {
				collision.gameObject.rigidbody.AddForce(Vector3.forward * this._ballForce);
			} else if(this._ballDirection == Utils.Direction.Back) {
				collision.gameObject.rigidbody.AddForce(Vector3.back * this._ballForce);
			} else if(this._ballDirection == Utils.Direction.Left) {
				collision.gameObject.rigidbody.AddForce(Vector3.left * this._ballForce);
			} else if(this._ballDirection == Utils.Direction.Right) {
				collision.gameObject.rigidbody.AddForce(Vector3.right * this._ballForce);
			} else if(this._ballDirection == Utils.Direction.Up) {
				collision.gameObject.rigidbody.AddForce(Vector3.up * this._ballForce);
			} else if(this._ballDirection == Utils.Direction.Down) {
				collision.gameObject.rigidbody.AddForce(Vector3.down * this._ballForce);
			}
		}
	}
}
