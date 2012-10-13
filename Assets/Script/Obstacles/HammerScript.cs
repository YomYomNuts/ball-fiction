using UnityEngine;
using System.Collections;

// TODO

/// <summary>
/// Script de comportement des marteaux
/// </summary>
public class HammerScript : MonoBehaviour {
	/// <summary>
	/// La latence entre 2 collisions, pour ne pas que la collision s'exécute plusieurs fois en une seule
	/// </summary>
	public float _latency = 3f;
	
	// Le moment de la dernière collision
	private float _lastCollision = -1f;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}
	
	void OnCollisionEnter(Collision collision) {
		Debug.Log(collision.contacts[0].point.y + " / " + this.transform.position.y);
		// On enlève 0.1 à la position du marteau sinon,
		// quand la bille touche la face verticale du marteau, le point a un Y à 0.0[...]03 et enlève du score...
		if(collision.contacts[0].point.y < this.transform.position.y-0.1 && Time.time - this._latency >= this._lastCollision) {
			Debug.Log("Aie"); // A remplacer par ce qu'il faut
			this._lastCollision = Time.time;
		}
	}
}
