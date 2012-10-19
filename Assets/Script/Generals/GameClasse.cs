using UnityEngine;

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
	// Temps à la fin du niveau en seconde
    private float _endLevelTime = 0f;
	// Le nom du level en cours
	private string _currentLevelName = Utils.SceneMenu;
	// La gravité au début du niveau (pour la réinitialiser quand le level est terminé)
	private Vector3 _originalGravity;
	
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
	private GameClasse() {}
	
	/// <summary>
	/// Propriété liée au score
	/// </summary>
	public int Score {
		get {
			return this._score;
		}
		private set {
			this._score = value;
			DisplayScoreAndTime.Instance.DisplayScore();
		}
	}
	
	/// <summary>
	/// Permet d'obtenir le score sous forme de string
	/// </summary>
	public string FormatedScore {
		get {
			return Utils.FormatScore(this.Score);
		}
	}
	
	/// <summary>
	/// Propriété liée au nom du level en cours
	/// </summary>
	public string CurrentLevelName {
		get {
			return this._currentLevelName;
		}
		set {
			this._currentLevelName = value;
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
	/// Propriété liée au temps à la fin du niveau
	/// </summary>
	public float EndLevelTime {
		get {
			return this._endLevelTime;
		}
		private set {
			this._endLevelTime = value;
		}
	}
	
	/// <summary>
	/// Propriété liée au temps de jeu
	/// </summary>
	public Vector3 OriginalGravity {
		get {
			return this._originalGravity;
		}
		private set {
			this._originalGravity = value;
		}
	}
	
	/// <summary>
	/// Permet d'obtenir le temps de jeu total
	/// </summary>
	public float GameTime {
		get {
			if(this.EndLevelTime == 0) {
				return Time.time - this.StartGameTime + this.GapTime;
			} else {
				return this.EndLevelTime;
			}
		}
	}
	
	/// <summary>
	/// Permet d'obtenir le temps de jeu total sous la forme "H:MM:SS.SSS"
	/// </summary>
	public string FormatedGameTime {
		get {
			return Utils.FormatTime(this.GameTime);
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
	/// Initialise la partie
	/// </summary>
	public void InitGame() {
		this.OriginalGravity = Physics.gravity;
		this.Score = 0;
		this.GapTime = 0;
		this.EndLevelTime = 0f;
		this.StartGameTime = Time.time;
	}
	
	/// <summary>
	/// Méthode à appeler quand le level est abandonné
	/// </summary>
	public void LevelAbandoned() {
		Physics.gravity = this.OriginalGravity;
		Application.LoadLevel(Utils.SceneLevelAbandoned);
	}
	
	/// <summary>
	/// Méthode à appeler quand le level est perdu (sortie du plateau)
	/// </summary>
	public void LevelLost() {
		Physics.gravity = this.OriginalGravity;
		Application.LoadLevel(Utils.SceneLevelLost);
	}
	
	/// <summary>
	/// Méthode à appeler quand le level est réussi
	/// </summary>
	public void LevelSolved() {
		this.EndLevelTime = this.GameTime;
		Physics.gravity = this.OriginalGravity;
		this.SaveScoreAndTime();
		Application.LoadLevel(Utils.SceneLevelSolved);
	}
	
	private void SaveScoreAndTime() {
		int[] bestScores = new int[3];
		float[] bestTimes = new float[3];
		
		int currentScore = this.Score;
		float currentGameTime = this.GameTime;
		
		bestScores[0] = PlayerPrefs.GetInt(string.Concat("BestScore",GameClasse.Instance.CurrentLevelName));
		bestScores[1] = PlayerPrefs.GetInt(string.Concat("SecondBestScore",GameClasse.Instance.CurrentLevelName));
		bestScores[2] = PlayerPrefs.GetInt(string.Concat("ThirdBestScore",GameClasse.Instance.CurrentLevelName));
		
		bestTimes[0] = PlayerPrefs.GetFloat(string.Concat("BestTime",GameClasse.Instance.CurrentLevelName));
		bestTimes[1] = PlayerPrefs.GetFloat(string.Concat("SecondBestTime",GameClasse.Instance.CurrentLevelName));
		bestTimes[2] = PlayerPrefs.GetFloat(string.Concat("ThirdBestTime",GameClasse.Instance.CurrentLevelName));
		
		if(!PlayerPrefs.HasKey(string.Concat("BestScore",GameClasse.Instance.CurrentLevelName)) || currentScore >= bestScores[0]) {
			PlayerPrefs.SetInt(string.Concat("ThirdBestScore",GameClasse.Instance.CurrentLevelName), bestScores[1]);
			PlayerPrefs.SetInt(string.Concat("SecondBestScore",GameClasse.Instance.CurrentLevelName), bestScores[0]);
			PlayerPrefs.SetInt(string.Concat("BestScore",GameClasse.Instance.CurrentLevelName), currentScore);
		} else if(!PlayerPrefs.HasKey(string.Concat("SecondBestScore",GameClasse.Instance.CurrentLevelName)) || currentScore >= bestScores[1]) {
			PlayerPrefs.SetInt(string.Concat("ThirdBestScore",GameClasse.Instance.CurrentLevelName), bestScores[1]);
			PlayerPrefs.SetInt(string.Concat("SecondBestScore",GameClasse.Instance.CurrentLevelName), currentScore);
		} else if(!PlayerPrefs.HasKey(string.Concat("ThirdBestScore",GameClasse.Instance.CurrentLevelName)) || currentScore >= bestScores[2]) {
			PlayerPrefs.SetInt(string.Concat("ThirdBestScore",GameClasse.Instance.CurrentLevelName), currentScore);
		}
		
		if(!PlayerPrefs.HasKey(string.Concat("BestTime",GameClasse.Instance.CurrentLevelName)) || currentGameTime <= bestTimes[0]) {
			PlayerPrefs.SetFloat(string.Concat("ThirdBestTime",GameClasse.Instance.CurrentLevelName), bestTimes[1]);
			PlayerPrefs.SetFloat(string.Concat("SecondBestTime",GameClasse.Instance.CurrentLevelName), bestTimes[0]);
			PlayerPrefs.SetFloat(string.Concat("BestTime",GameClasse.Instance.CurrentLevelName), currentGameTime);
		} else if(!PlayerPrefs.HasKey(string.Concat("SecondBestTime",GameClasse.Instance.CurrentLevelName)) || currentGameTime <= bestTimes[1]) {
			PlayerPrefs.SetFloat(string.Concat("ThirdBestTime",GameClasse.Instance.CurrentLevelName), bestTimes[1]);
			PlayerPrefs.SetFloat(string.Concat("SecondBestTime",GameClasse.Instance.CurrentLevelName), currentGameTime);
		} else if(!PlayerPrefs.HasKey(string.Concat("ThirdBestTime",GameClasse.Instance.CurrentLevelName)) || currentGameTime <= bestTimes[2]) {
			PlayerPrefs.SetFloat(string.Concat("ThirdBestTime",GameClasse.Instance.CurrentLevelName), currentGameTime);
		}
	}
}
