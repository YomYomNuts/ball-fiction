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
		if(ball != null) {
			// Variable locale contenant la velocité de la bille
			Vector3 velocity = collision.gameObject.rigidbody.velocity;
			// Variables locales permettant de savoir si la bille peut être poussée dans chacune des direction
			// Elle peut être poussée si le maximum n'est pas encore atteint ou si on l'ignore (le max)
			bool forwardPossible = this._ignoreMaximalForceBall || velocity.z < ball._absolueVectorForceBall.z;
			bool backPossible = this._ignoreMaximalForceBall || velocity.z > -ball._absolueVectorForceBall.z;
			bool leftPossible = this._ignoreMaximalForceBall || velocity.x > -ball._absolueVectorForceBall.x;
			bool rightPossible = this._ignoreMaximalForceBall || velocity.x < ball._absolueVectorForceBall.x;
			bool upPossible = this._ignoreMaximalForceBall || velocity.y < ball._absolueVectorForceBall.y;
			bool downPossible = this._ignoreMaximalForceBall || velocity.y > -ball._absolueVectorForceBall.y;
			// On applique la force selon la direction (en vérifiant si on peut lui appliquer la force)
			if(this._ballDirection == Utils.Direction.Forward && forwardPossible) {
				collision.gameObject.rigidbody.AddForce(Vector3.forward * this._ballForce);
			} else if(this._ballDirection == Utils.Direction.Back && backPossible) {
				collision.gameObject.rigidbody.AddForce(Vector3.back * this._ballForce);
			} else if(this._ballDirection == Utils.Direction.Left && leftPossible) {
				collision.gameObject.rigidbody.AddForce(Vector3.left * this._ballForce);
			} else if(this._ballDirection == Utils.Direction.Right && rightPossible) {
				collision.gameObject.rigidbody.AddForce(Vector3.right * this._ballForce);
			} else if(this._ballDirection == Utils.Direction.Up && upPossible) {
				collision.gameObject.rigidbody.AddForce(Vector3.up * this._ballForce);
			} else if(this._ballDirection == Utils.Direction.Down && downPossible) {
				collision.gameObject.rigidbody.AddForce(Vector3.down * this._ballForce);
			}
		}
	}
	
	/// <summary>
	/// Inverse la direction du tapis
	/// </summary>
	public void InverseDirection() {
		Transform theAppearanceChild = null;
		foreach(Transform child in this.transform) {
			if(child.name.Contains("Appearance")) {
				theAppearanceChild = child;
			}
		}
		if(theAppearanceChild == null) {
			return;
		}
		if(this._ballDirection == Utils.Direction.Forward) {
			this._ballDirection = Utils.Direction.Back;
			if(!this._ignoreMaximalForceBall) {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/back_arrow") as Texture;
			} else {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/back_arrow_accelerator") as Texture;
			}
		} else if(this._ballDirection == Utils.Direction.Back) {
			this._ballDirection = Utils.Direction.Forward;
			if(!this._ignoreMaximalForceBall) {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/forward_arrow") as Texture;
			} else {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/forward_arrow_accelerator") as Texture;
			}
		} else if(this._ballDirection == Utils.Direction.Left) {
			this._ballDirection = Utils.Direction.Right;
			if(!this._ignoreMaximalForceBall) {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/left_arrow") as Texture;
			} else {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/left_arrow_accelerator") as Texture;
			}
		} else if(this._ballDirection == Utils.Direction.Right) {
			this._ballDirection = Utils.Direction.Left;
			if(!this._ignoreMaximalForceBall) {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/right_arrow") as Texture;
			} else {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/right_arrow_accelerator") as Texture;
			}
		} else if(this._ballDirection == Utils.Direction.Up) {
			this._ballDirection = Utils.Direction.Down;
			if(!this._ignoreMaximalForceBall) {
			theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/up_arrow") as Texture;
			} else {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/up_arrow_accelerator") as Texture;
			}
		} else if(this._ballDirection == Utils.Direction.Down) {
			this._ballDirection = Utils.Direction.Up;
			if(!this._ignoreMaximalForceBall) {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/down_arrow") as Texture;
			} else {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/down_arrow_accelerator") as Texture;
			}
		}
	}
}
