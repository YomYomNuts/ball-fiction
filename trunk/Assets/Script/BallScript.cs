using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement de la bille
/// </summary>
public class BallScript : MonoBehaviour {
	public GameObject mainCamera;
	
	/// <summary>
	/// Force maximale sur l'objet
	/// </summary>
    public Vector3 _absolueVectorForceBall = new Vector3(2,2,2);
	
	/// <summary>
	/// La hauteur de la caméra par rapport à la bille
	/// </summary>
	public float _hauteurCamera = 4f;
	
	/// <summary>
	/// Le recul de la caméra par rapport à la bille
	/// </summary>
	public float _reculCamera = 3f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.mainCamera.transform.position = new Vector3(this.gameObject.transform.position.x,
														 this.gameObject.transform.position.y + this._hauteurCamera,
														 this.gameObject.transform.position.z - this._reculCamera);
	}
}
