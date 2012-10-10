using UnityEngine;
using System.Collections;

/// <summary>
/// Script permettant de terminer le jeu
/// </summary>
public class GameOverScript : MonoBehaviour {
	/// <summary>
	/// True si la boule est arrivée à la fin
	/// </summary>
	public bool _isSolved = false;
	
	/// <summary>
	/// True si la partie est finie (niveau réussi ou abandon)
	/// </summary>
	public bool _isEnded = false;
	
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
        GameOverScript.OnAbandon += new ActionEvent(this.OnAbandonEventReceived);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Abandon")) {
            GameOverScript.OnAbandon();
		}
		if(this._isSolved) {
			Debug.Log ("BRAVO !!");
			Application.LoadLevel(Utils.SceneLevelSolved);
		} else if(this._isEnded) {
			Debug.Log("Dommage");
			Application.LoadLevel(Utils.SceneLevelAbandoned);
		}
	}
}
