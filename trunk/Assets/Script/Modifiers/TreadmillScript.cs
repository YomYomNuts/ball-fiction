using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement des tapis roulants
/// </summary>
public class TreadmillScript : MonoBehaviour {
	#region Attributes
	/// <summary>
	/// La force avec laquelle les tapis roulants agissent sur la bille
	/// </summary>
    public float _ballForce = 0.5f;
	/// <summary>
	/// Direction dans laquelle le tapis roulants "pousse" la bille
	/// </summary>
    public UtilsScript.Direction _ballDirection = UtilsScript.Direction.Forward;
	/// <summary>
	/// Prise en compte ou non de la force maximale de la bille
	/// </summary>
    public bool _ignoreMaximalForceBall = false;
	#endregion
	
	#region Unity Methods
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
			if(this._ballDirection == UtilsScript.Direction.Forward && forwardPossible) {
				collision.gameObject.rigidbody.AddForce(Vector3.forward * this._ballForce);
			} else if(this._ballDirection == UtilsScript.Direction.Back && backPossible) {
				collision.gameObject.rigidbody.AddForce(Vector3.back * this._ballForce);
			} else if(this._ballDirection == UtilsScript.Direction.Left && leftPossible) {
				collision.gameObject.rigidbody.AddForce(Vector3.left * this._ballForce);
			} else if(this._ballDirection == UtilsScript.Direction.Right && rightPossible) {
				collision.gameObject.rigidbody.AddForce(Vector3.right * this._ballForce);
			} else if(this._ballDirection == UtilsScript.Direction.Up && upPossible) {
				collision.gameObject.rigidbody.AddForce(Vector3.up * this._ballForce);
			} else if(this._ballDirection == UtilsScript.Direction.Down && downPossible) {
				// Le tapis roulant "down" n'existe pas mais il est déjà géré, au cas où une idée nous viendrait
				collision.gameObject.rigidbody.AddForce(Vector3.down * this._ballForce);
			}
			// On joue le son associé
			if(this.audio != null && this.audio.clip != null) {
				AudioSource.PlayClipAtPoint(this.audio.clip, Camera.main.transform.position);
			}
		}
	}
	#endregion
	
	#region Methods
	/// <summary>
	/// Inverse la direction du tapis
	/// </summary>
	public void InverseDirection() {
		// On récupère l'objet qui gère l'apparence du bouton parmi ces enfants
		Transform theAppearanceChild = null;
		foreach(Transform child in this.transform) {
			if(child.name.Contains("Appearance")) {
				theAppearanceChild = child;
			}
		}
		if(theAppearanceChild == null) {
			return;
		}
		
		// On inverse la direction du tapis roulant en modifiant la texture de son fils gérant l'apparence
		if(this._ballDirection == UtilsScript.Direction.Forward) {
			this._ballDirection = UtilsScript.Direction.Back;
			if(!this._ignoreMaximalForceBall) {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/LevelDesign/back_arrow") as Texture;
			} else {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/LevelDesign/back_arrow_accelerator") as Texture;
			}
			
		} else if(this._ballDirection == UtilsScript.Direction.Back) {
			this._ballDirection = UtilsScript.Direction.Forward;
			if(!this._ignoreMaximalForceBall) {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/LevelDesign/forward_arrow") as Texture;
			} else {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/LevelDesign/forward_arrow_accelerator") as Texture;
			}
			
		} else if(this._ballDirection == UtilsScript.Direction.Left) {
			this._ballDirection = UtilsScript.Direction.Right;
			if(!this._ignoreMaximalForceBall) {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/LevelDesign/left_arrow") as Texture;
			} else {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/LevelDesign/left_arrow_accelerator") as Texture;
			}
			
		} else if(this._ballDirection == UtilsScript.Direction.Right) {
			this._ballDirection = UtilsScript.Direction.Left;
			if(!this._ignoreMaximalForceBall) {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/LevelDesign/right_arrow") as Texture;
			} else {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/LevelDesign/right_arrow_accelerator") as Texture;
			}
			
		} else if(this._ballDirection == UtilsScript.Direction.Up) {
			this._ballDirection = UtilsScript.Direction.Down;
			if(!this._ignoreMaximalForceBall) {
			theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/LevelDesign/up_arrow") as Texture;
			} else {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/LevelDesign/up_arrow_accelerator") as Texture;
			}
			
		} else if(this._ballDirection == UtilsScript.Direction.Down) {
			// Le tapis roulant "down" n'existe pas mais il est déjà géré pour une future utilisation
			this._ballDirection = UtilsScript.Direction.Up;
			if(!this._ignoreMaximalForceBall) {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/LevelDesign/down_arrow") as Texture;
			} else {
				theAppearanceChild.renderer.material.mainTexture = Resources.Load("Data/LevelDesign/down_arrow_accelerator") as Texture;
			}
		}
	}
	#endregion
}
