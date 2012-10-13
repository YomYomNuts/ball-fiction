using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement des tapis roulants
/// </summary>
public class TreadmillScript : MonoBehaviour {
	/// <summary>
	/// La force avec laquelle les tapis roulants agissent sur la bille
	/// </summary>
    public float _ballForce = 0.5f;
	/// <summary>
	/// Direction dans laquelle le tapis roulants "pousse" la bille
	/// </summary>
    public Utils.Direction _ballDirection = Utils.Direction.Forward;
	/// <summary>
	/// Prise en compte ou non de la force maximale de la bille
	/// </summary>
    public bool _ignoreMaximalForceBall = false;

	// Use this for initialization
	void Start () {
	
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
		if(ball == null) {
			Debug.LogError("The BallScript can't be obtained in BreadmillScript");
		} else {
			// Variable locale contenant la velocité de la bille
			Vector3 velocity = collision.gameObject.rigidbody.velocity;
			// On vérifie que la bille n'a pas encore atteint sa vitesse maximale ou que l'on ignore sa vitesse maximale
			if(this._ignoreMaximalForceBall ||
				(Mathf.Abs(velocity.x) < Mathf.Abs(ball._absolueVectorForceBall.x) && 
				Mathf.Abs(velocity.y) < Mathf.Abs(ball._absolueVectorForceBall.y) && 
				Mathf.Abs(velocity.z) < Mathf.Abs(ball._absolueVectorForceBall.z))) {
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
	
	/// <summary>
	/// Inverse la direction du tapis
	/// </summary>
	public void InverseDirection() {
			if(this._ballDirection == Utils.Direction.Forward) {
				this._ballDirection = Utils.Direction.Back;
				if(!this._ignoreMaximalForceBall) {
					this.renderer.material.mainTexture = Resources.Load("Data/back_arrow") as Texture;
				} else {
					this.renderer.material.mainTexture = Resources.Load("Data/back_arrow_accelerator") as Texture;
				}
			} else if(this._ballDirection == Utils.Direction.Back) {
				this._ballDirection = Utils.Direction.Forward;
				if(!this._ignoreMaximalForceBall) {
					this.renderer.material.mainTexture = Resources.Load("Data/forward_arrow") as Texture;
				} else {
					this.renderer.material.mainTexture = Resources.Load("Data/forward_arrow_accelerator") as Texture;
				}
			} else if(this._ballDirection == Utils.Direction.Left) {
				this._ballDirection = Utils.Direction.Right;
//				if(!this._IgnoreMaximalForceBall) {
//					this.renderer.material.mainTexture = Resources.Load("Data/left_arrow") as Texture;
//				} else {
//					this.renderer.material.mainTexture = Resources.Load("Data/left_arrow_accelerator") as Texture;
//				}
			} else if(this._ballDirection == Utils.Direction.Right) {
				this._ballDirection = Utils.Direction.Left;
//				if(!this._IgnoreMaximalForceBall) {
//					this.renderer.material.mainTexture = Resources.Load("Data/right_arrow") as Texture;
//				} else {
//					this.renderer.material.mainTexture = Resources.Load("Data/right_arrow_accelerator") as Texture;
//				}
			} else if(this._ballDirection == Utils.Direction.Up) {
				this._ballDirection = Utils.Direction.Down;
//				if(!this._IgnoreMaximalForceBall) {
					this.renderer.material.mainTexture = Resources.Load("Data/up_arrow") as Texture;
//				} else {
//					this.renderer.material.mainTexture = Resources.Load("Data/up_arrow_accelerator") as Texture;
//				}
			} else if(this._ballDirection == Utils.Direction.Down) {
				this._ballDirection = Utils.Direction.Up;
//				if(!this._IgnoreMaximalForceBall) {
//					this.renderer.material.mainTexture = Resources.Load("Data/down_arrow") as Texture;
//				} else {
//					this.renderer.material.mainTexture = Resources.Load("Data/down_arrow_accelerator") as Texture;
//				}
			}
	}
}
