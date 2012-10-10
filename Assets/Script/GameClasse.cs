using UnityEngine;
using System.Collections;

/// <summary>
/// Classe du jeu
/// </summary>
public class GameClasse {
	// Score
    private static int _score = 0;
	// Temps de décalage du jeu en seconde
    private static float _gapTime = 0f;
	// Temps au début du jeu en seconde
    private static float _startGameTime = 0f;
	
	/// <summary>
	/// Propriété liée au score
	/// </summary>
	public static int Score {
		get {
			return GameClasse._score;
		}
		private set {
			GameClasse._score = value;
		}
	}
	
	/// <summary>
	/// Propriété liée au décalage du temps de jeu
	/// </summary>
	public static float GapTime {
		get {
			return GameClasse._gapTime;
		}
		private set {
			GameClasse._gapTime = value;
		}
	}
	
	/// <summary>
	/// Propriété liée au temps de jeu
	/// </summary>
	public static float StartGameTime {
		get {
			return GameClasse._startGameTime;
		}
		private set {
			GameClasse._startGameTime = value;
		}
	}
	
	/// <summary>
	/// Permet d'obtenir le temps de jeu total
	/// </summary>
	public static float GameTime {
		get {
			return Time.time - GameClasse.StartGameTime + GameClasse.GapTime;
		}
	}
	
	/// <summary>
	/// Incrémente le score
	/// </summary>
	public static void IncrementScore(int incrementation) {
		GameClasse.Score += incrementation;
	}
	
	/// <summary>
	/// Incrémente le décalage du temps de jeu
	/// </summary>
	public static void IncrementGapTime(float incrementation) {
		GameClasse.GapTime += incrementation;
	}
	
	/// <summary>
	/// Remise à zéro de la partie
	/// </summary>
	public static void ResetGame() {
		GameClasse.Score = 0;
		GameClasse.GapTime = 0;
		GameClasse.StartGameTime = Time.time;
	}
}
