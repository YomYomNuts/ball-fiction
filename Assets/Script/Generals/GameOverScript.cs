using UnityEngine;
using System.Collections;

/// <summary>
/// Script permettant de terminer le jeu
/// </summary>
public class GameOverScript : MonoBehaviour {
	#region Attributes
    // Définition du type d'évènement
    public delegate void ActionEvent();
	
	/// <summary>
	/// Permet de capturer l'appuie sur le bouton correspondant à l'abandon
	/// </summary>
    static public event ActionEvent OnAbandon;
	
	/// <summary>
	/// True si la boule est arrivée à la fin
	/// </summary>
	public bool _isSolved = false;
		/// <summary>
	/// True si la partie est abandonnée
	/// </summary>
	public bool _isAbandoned = false;
	#endregion
	
	#region Unity Methods
	// Evènement déclanché lors de l'appui sur le bouton gauche
    void OnAbandonEventReceived() {
        this._isAbandoned = true;
    }
	
	// Collision pour finir le niveau
	void OnTriggerEnter(Collider collider) {
		this._isSolved = true;
	}
	
	// Use this for initialization
	void Start () {
        GameOverScript.OnAbandon += new ActionEvent(this.OnAbandonEventReceived);
	}
	
	// Update is called once per frame
	void Update () {
		// Capture de l'appuie sur le bouton d'abandon
		if(Input.GetButton("Abandon")) {
            GameOverScript.OnAbandon();
		}
		
		// Si le level est terminé, on charge le menu correspondant
		if(this._isSolved) {
			GameClasseScript.Instance.LevelSolved();
		} else if(this._isAbandoned) {
			GameClasseScript.Instance.LevelAbandoned();
		}
	}
	#endregion
}
