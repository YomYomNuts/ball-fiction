using UnityEngine;
using System.Collections;

/// <summary>
/// Script gérant le comportement de basculement du plateau
/// </summary>
public class TrayScript : MonoBehaviour {
	/// <summary>
	/// La vitesse à laquelle la rotation s'effectue
	/// </summary>
    public float _rotationSpeedTray = 0.3f;
	/// <summary>
	/// La force de répulsion du plateau (vers le haut)
	/// </summary>
    public float _repulsionForce = 0.01f;
	
	/// <summary>
	/// La limite de droite
	/// </summary>
	public float _maximumRight = -0.15f;
	/// <summary>
	/// La limite de gauche
	/// </summary>
	public float _maximumLeft = 0.15f;
	
    // Définition du type d'évènement
    public delegate void ActionEvent();
	
	/// <summary>
	/// Event appelé quand on bascule le plateau vers la gauche
	/// </summary>
    static public event ActionEvent OnLeft;
	/// <summary>
	/// Event appelé quand on bascule le plateau vers la droite
	/// </summary>
    static public event ActionEvent OnRight;
	
	/// <summary>
	/// Evènement déclenché lors de l'appui sur le bouton qui doit faire basculer le plateau vers la gauche
	/// </summary>
    void OnLeftEventReceived() {
		if(this.transform.rotation.z < this._maximumLeft) {
        	this.transform.RotateAround(Vector3.forward, this._rotationSpeedTray * Time.deltaTime);
			Physics.gravity = Quaternion.Euler(0, 0, this._rotationSpeedTray * Time.deltaTime * 100) * Physics.gravity;
		}
    }
	/// <summary>
	/// Evènement déclenché lors de l'appui sur le bouton qui doit faire basculer le plateau vers la droite
	/// </summary>
    void OnRightEventReceived() {
		if(this.transform.rotation.z > this._maximumRight) {
	        this.transform.RotateAround(Vector3.back, this._rotationSpeedTray * Time.deltaTime);
			Physics.gravity = Quaternion.Euler(0, 0, -this._rotationSpeedTray * Time.deltaTime * 100) * Physics.gravity;
		}
    }
	
	// Use this for initialization
	void Start () {
		//Ajout des évènements lors du basculement vers la gauche ou la droite
        TrayScript.OnLeft += new ActionEvent(OnLeftEventReceived);
        TrayScript.OnRight += new ActionEvent(OnRightEventReceived);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Left")) {
            TrayScript.OnLeft();
		}
		if(Input.GetButton("Right")) {
            TrayScript.OnRight();
		}
	}
	
	// Ajout d'une force de répulsion
	void OnCollisionStay(Collision collision) {
		collision.gameObject.rigidbody.AddForce(Vector3.up * _repulsionForce);
	}
}
