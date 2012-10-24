using UnityEngine;
using System.Collections;

/// <summary>
/// Script de comportement de la bille
/// </summary>
public class BallScript : MonoBehaviour {
	/// <summary>
	/// La caméra qui film la bille
	/// </summary>
	public GameObject _theCamera;
	
	/// <summary>
	/// Force maximale sur l'objet
	/// </summary>
    public Vector3 _absolueVectorForceBall = new Vector3(2,2,2);
	
	/// <summary>
	/// La hauteur de la caméra par rapport à la bille
	/// </summary>
	public float _cameraHigh = 8f;
	
	/// <summary>
	/// Le recul de la caméra par rapport à la bille
	/// </summary>
	public float _cameraRetreat = 8f;
	
	// Use this for initialization
	void Start () {
		if(this._theCamera == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("camera", this.GetType().ToString(), this.gameObject.name);
		}
		PlayerPrefs.DeleteAll(); // Pour ne pas poluer le PlayerPrefs pendant les tests
	}
	
	// Update is called once per frame
	void Update () {
		if(this._theCamera != null) {
			// On place la caméra derrière la bille
			this._theCamera.transform.position = new Vector3(this.gameObject.transform.position.x,
															 this.gameObject.transform.position.y + this._cameraHigh,
															 this.gameObject.transform.position.z - this._cameraRetreat);
		}
		DisplayScoreAndTime.Instance.DisplayTime();
	}
}
