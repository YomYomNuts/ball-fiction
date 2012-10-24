using UnityEngine;
using System.Collections;

/// <summary>
/// Script gérant le comportement de basculement du plateau
/// </summary>
public class TrayScript : MonoBehaviour {
	/// <summary>
	/// La bille
	/// </summary>
	public GameObject _theBall;
	/// <summary>
	/// La vitesse à laquelle la rotation s'effectue
	/// </summary>
    public float _rotationSpeedTray = 0.3f;
	/// <summary>
	/// La force de répulsion du plateau (vers le haut)
	/// </summary>
    public float _repulsionForce = 0.01f;
	/// <summary>
	/// Angle maximal de rotation
	/// </summary>
	public float _maximumRotationAngle = 10f;
	/// <summary>
	/// Delta de l'angle maximal de rotation
	/// </summary>
	public float _maximumRotationAngleDelta = 5f;
	
	public GameObject TheBall {
		get {
			if(this._theBall == null) {
				this._theBall = BallScript.Instance.gameObject;
			}
			return this._theBall;
		}
	}
	
    // Définition du type d'évènement
    public delegate void ActionEvent();
	
	/// <summary>
	/// Event appelé quand on bascule le plateau vers la gauche
	/// </summary>
    public event ActionEvent OnLeft;
	/// <summary>
	/// Event appelé quand on bascule le plateau vers la droite
	/// </summary>
    public event ActionEvent OnRight;
	
	/// <summary>
	/// Evènement déclenché lors de l'appui sur le bouton qui doit faire basculer le plateau vers la gauche
	/// </summary>
    void OnLeftEventReceived() {
		//Vérification de l'angle maximal avant d'appliquer une nouvelle gravité
		if(this.transform.rotation.eulerAngles.z > (360 - this._maximumRotationAngle)
		   || this.transform.rotation.eulerAngles.z < this._maximumRotationAngle + this._maximumRotationAngleDelta) {
			if(this.TheBall != null) {
				// Ajout d'une force de répulsion
				this.TheBall.rigidbody.AddForce(Vector3.up * _repulsionForce);
			}
        	this.transform.RotateAround(Vector3.back, this._rotationSpeedTray * Time.deltaTime);
			Physics.gravity = Quaternion.Euler(0, 0, -this._rotationSpeedTray * Time.deltaTime * 100) * Physics.gravity;
		}
    }
	/// <summary>
	/// Evènement déclenché lors de l'appui sur le bouton qui doit faire basculer le plateau vers la droite
	/// </summary>
    void OnRightEventReceived() {
		//Vérification de l'angle maximal avant d'appliquer une nouvelle gravité
		if(this.transform.rotation.eulerAngles.z < this._maximumRotationAngle
		   || this.transform.rotation.eulerAngles.z > (360 - this._maximumRotationAngle - this._maximumRotationAngleDelta)) {
			if(this.TheBall != null) {
				// Ajout d'une force de répulsion
				this.TheBall.rigidbody.AddForce(Vector3.up * _repulsionForce);
			}
	        this.transform.RotateAround(Vector3.forward, this._rotationSpeedTray * Time.deltaTime);
			Physics.gravity = Quaternion.Euler(0, 0, this._rotationSpeedTray * Time.deltaTime * 100) * Physics.gravity;
		}
    }
	
	// Use this for initialization
	void Start () {
		if(this.TheBall == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("ball", this.GetType().ToString(), this.gameObject.name);
		}
		GameClasse.Instance.InitGame();
		//Ajout des évènements lors du basculement vers la gauche ou la droite
        this.OnLeft += new ActionEvent(OnLeftEventReceived);
        this.OnRight += new ActionEvent(OnRightEventReceived);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Left")) {
            this.OnLeft();
		}
		if(Input.GetButton("Right")) {
            this.OnRight();
		}
	}
}
