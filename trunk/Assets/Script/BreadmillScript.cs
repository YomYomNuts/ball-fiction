using UnityEngine;
using System.Collections;

public class BreadmillScript : MonoBehaviour {
    public float _ballForce = 0.5f;
    public Direction _ballDirection = Direction.Forward;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Collision pour faire bouger la bille
	void OnCollisionStay(Collision collision) {
		//Debug.Log(collision.gameObject.rigidbody.velocity);
		BallScript ball = collision.gameObject.GetComponent<BallScript>();
		//if(collision.gameObject.rigidbody.velocity < ball._absolueVectorForceBall) {
			if(_ballDirection == Direction.Forward) {
				collision.gameObject.rigidbody.AddForce(Vector3.forward * _ballForce);
			} else if(_ballDirection == Direction.Back) {
				collision.gameObject.rigidbody.AddForce(Vector3.back * _ballForce);
			} else if(_ballDirection == Direction.Left) {
				collision.gameObject.rigidbody.AddForce(Vector3.left * _ballForce);
			} else if(_ballDirection == Direction.Right) {
				collision.gameObject.rigidbody.AddForce(Vector3.right * _ballForce);
			} else if(_ballDirection == Direction.Up) {
				collision.gameObject.rigidbody.AddForce(Vector3.up * _ballForce);
			} else if(_ballDirection == Direction.Down) {
				collision.gameObject.rigidbody.AddForce(Vector3.down * _ballForce);
			}
		//}
	}
}
