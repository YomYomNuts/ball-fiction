using UnityEngine;
using System.Collections;

/// <summary>
/// Classe du jeu
/// </summary>
public class GameClasse {
	// Singleton
    private static GameClasse _instance;
	// Score
    private int _score = 0;
	// Temps de décalage du jeu en seconde
    private float _gapTime = 0f;
	// Temps au début du jeu en seconde
    private float _startGameTime = 0f;
	
	/// <summary>
	/// Propriété liée à la classe
	/// </summary>
	public static GameClasse Instance {
		get {
			if(GameClasse._instance == null) {
				GameClasse._instance = new GameClasse();
			}
			return GameClasse._instance;
		}
	}
	
	/// <summary>
	/// Constructeur
	/// </summary>
	private GameClasse() {
	}
	
	/// <summary>
	/// Propriété liée au score
	/// </summary>
	public int Score {
		get {
			return this._score;
		}
		private set {
			this._score = value;
		}
	}
	
	/// <summary>
	/// Propriété liée au décalage du temps de jeu
	/// </summary>
	public float GapTime {
		get {
			return this._gapTime;
		}
		private set {
			this._gapTime = value;
		}
	}
	
	/// <summary>
	/// Propriété liée au temps de jeu
	/// </summary>
	public float StartGameTime {
		get {
			return this._startGameTime;
		}
		private set {
			this._startGameTime = value;
		}
	}
	
	/// <summary>
	/// Permet d'obtenir le temps de jeu total
	/// </summary>
	public float GameTime {
		get {
			return Time.time - this.StartGameTime + this.GapTime;
		}
	}
	
	/// <summary>
	/// Incrémente le score
	/// </summary>
	public void IncrementScore(int incrementation) {
		this.Score += incrementation;
	}
	
	/// <summary>
	/// Incrémente le décalage du temps de jeu
	/// </summary>
	public void IncrementGapTime(float incrementation) {
		this.GapTime += incrementation;
	}
	
	/// <summary>
	/// Remise à zéro de la partie
	/// </summary>
	public void ResetGame() {
		this.Score = 0;
		this.GapTime = 0;
		this.StartGameTime = Time.time;
	}
}
