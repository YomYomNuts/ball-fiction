using UnityEngine;
using System.Collections;

/// <summary>
/// Script permettant de terminer le jeu
/// </summary>
public class GameOverScript : MonoBehaviour {
	/// <summary>
	/// La bille
	/// </summary>
	public GameObject _theBall;
	
	/// <summary>
	/// True si la boule est arrivée à la fin
	/// </summary>
	public bool _isSolved = false;
	
	/// <summary>
	/// True si la partie est finie (niveau réussi ou abandon)
	/// </summary>
	public bool _isEnded = false;
	
	
	private Vector3 _initialPosition;
	
    // Définition du type d'évènement
    public delegate void ActionEvent();
	
	/// <summary>
	/// Permet de capturer l'appuie sur le bouton correspondant à l'abandon
	/// </summary>
    static public event ActionEvent OnAbandon;
	
	// Evènement déclanché lors de l'appui sur le bouton gauche
    void OnAbandonEventReceived() {
        this._isEnded = true;
    }
	
	// Collision pour finir le niveau
	void OnTriggerEnter(Collider collision) {
		this._isSolved = true;
	}
	
	// Use this for initialization
	void Start () {
		this._initialPosition = this._theBall.transform.position;
        GameOverScript.OnAbandon += new ActionEvent(this.OnAbandonEventReceived);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Abandon")) {
            GameOverScript.OnAbandon();
		}
		if(this._isSolved) {
			Debug.Log ("BRAVO !!");
			this._isSolved = false;
			this._isEnded = false;
		} else if(this._isEnded) {
			Debug.Log("Dommage");
			this._isSolved = false;
			this._isEnded = false;
			this._theBall.transform.position = this._initialPosition;
			this._theBall.rigidbody.velocity = new Vector3(0, 0, 0);
		}
	}
}
