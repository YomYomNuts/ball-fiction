using UnityEngine;
using System.Collections;

public class BreadmillScript : MonoBehaviour {
    public float _ballForce = 0.5f;
    public Direction _ballDirection = Direction.Forward;

	// Use this for initialization
	void Start () {
		Texture texture = null;
		if(this._ballDirection == Direction.Forward) {
			texture = Resources.Load("Data/forward_arrow", typeof(Texture)) as Texture;
		} else if(this._ballDirection == Direction.Back) {
			texture = Resources.Load("Data/back_arrow", typeof(Texture)) as Texture;
//		} else if(this._ballDirection == Direction.Left) {
//			texture = Resources.Load("Data/back_arrow", typeof(Texture)) as Texture;
//		} else if(this._ballDirection == Direction.Right) {
//			texture = Resources.Load("Data/back_arrow", typeof(Texture)) as Texture;
//		} else if(this._ballDirection == Direction.Up) {
//			texture = Resources.Load("Data/back_arrow", typeof(Texture)) as Texture;
//		} else if(this._ballDirection == Direction.Down) {
//			texture = Resources.Load("Data/back_arrow", typeof(Texture)) as Texture;
		}
		this.gameObject.renderer.material.mainTexture = texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Collision pour faire bouger la bille
	void OnCollisionStay(Collision collision) {
		BallScript ball = collision.gameObject.GetComponent<BallScript>();
		if(Mathf.Abs(collision.gameObject.rigidbody.velocity.x) < Mathf.Abs(ball._absolueVectorForceBall.x) && 
			Mathf.Abs(collision.gameObject.rigidbody.velocity.y) < Mathf.Abs(ball._absolueVectorForceBall.y) && 
			Mathf.Abs(collision.gameObject.rigidbody.velocity.z) < Mathf.Abs(ball._absolueVectorForceBall.z)) {
			if(this._ballDirection == Direction.Forward) {
				collision.gameObject.rigidbody.AddForce(Vector3.forward * this._ballForce);
			} else if(this._ballDirection == Direction.Back) {
				collision.gameObject.rigidbody.AddForce(Vector3.back * this._ballForce);
			} else if(this._ballDirection == Direction.Left) {
				collision.gameObject.rigidbody.AddForce(Vector3.left * this._ballForce);
			} else if(this._ballDirection == Direction.Right) {
				collision.gameObject.rigidbody.AddForce(Vector3.right * this._ballForce);
			} else if(this._ballDirection == Direction.Up) {
				collision.gameObject.rigidbody.AddForce(Vector3.up * this._ballForce);
			} else if(this._ballDirection == Direction.Down) {
				collision.gameObject.rigidbody.AddForce(Vector3.down * this._ballForce);
			}
		}
	}
}
