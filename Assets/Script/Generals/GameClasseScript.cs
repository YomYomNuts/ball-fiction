using UnityEngine;

/// <summary>
/// Classe du jeu
/// </summary>
public class GameClasseScript {
	#region Static Elements
	// Instance de la classe
    private static GameClasseScript _instance;
	
	/// <summary>
	/// Propriété pour accéder publiquement à l'instance de la classe
	/// </summary>
    public static GameClasseScript Instance {
        get {
			// Si l'instance n'existe pas, on la crée
            if (GameClasseScript._instance == null) {
                GameClasseScript._instance = new GameClasseScript();
			}
            return GameClasseScript._instance;
        }
    }
	#endregion
	
	#region Attributes
	// Le score
    private int _score = 0;
	// Temps de décalage du jeu en seconde
    private float _gapTime = 0f;
	// Temps au début du jeu en seconde
    private float _startGameTime = 0f;
	// Temps à la fin du niveau en seconde
    private float _endLevelTime = 0f;
	// Le nom du level en cours
	private string _currentLevelName = UtilsScript.SceneMenu;
	// Le nom du dernier level charger
	private string _lastLevelName = UtilsScript.SceneMenu;
	// La gravité au début du niveau (pour la réinitialiser quand le level est terminé)
	private Vector3 _originalGravity;
	// Le nom du joueur
    private string _playerName = "";
	#endregion
	
	#region Properties
	/// <summary>
	/// Propriété liée au score
	/// </summary>
	public int Score {
		get {
			return this._score;
		}
		private set {
			this._score = value;
			// A chaque fois qu'on modifie le score, on l'affiche de nouveau
			DisplayScoreScript.Instance.DisplayScore();
		}
	}
	/// <summary>
	/// Permet d'obtenir le score sous forme de string
	/// </summary>
	public string FormatedScore {
		get {
			return UtilsScript.FormatScore(this.Score);
		}
	}
	
	/// <summary>
	/// Propriété liée au décalage du temps de jeu
	/// La fonctionnalité associées n'a pas encore été développée
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
			return UtilsScript.FormatTime(this.GameTime);
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
	/// Propriété liée au nom du dernier level chargé
	/// </summary>
	public string LastLevelName {
		get {
			return this._lastLevelName;
		}
		set {
			this._lastLevelName = value;
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
			if(this.OriginalGravity == Vector3.zero) {
				this._originalGravity = value;
			}
		}
	}
	/// <summary>
	/// Propriété liée au nom du joueur
	/// </summary>
	public string PlayerName {
		get {
			return this._playerName;
		}
		set {
			this._playerName = value;
		}
	}
	#endregion
	
	#region Methods
	/// <summary>
	/// Constructeur
	/// </summary>
	private GameClasseScript() {
		this.OriginalGravity = Physics.gravity; // On enregistre la gravité d'origine
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
		Physics.gravity = this.OriginalGravity;
		this.Score = 0;
		this.GapTime = 0;
		this.EndLevelTime = 0f;
		this.StartGameTime = Time.time;
	}
	
	/// <summary>
	/// Méthode à appeler quand le level est abandonné
	/// </summary>
	public void LevelAbandoned() {
		Physics.gravity = this.OriginalGravity; // On réinitialise la gravité
		Application.LoadLevel(UtilsScript.SceneLevelAbandoned);
	}
	
	/// <summary>
	/// Méthode à appeler quand le level est perdu (sortie du plateau)
	/// </summary>
	public void LevelLost() {
		Physics.gravity = this.OriginalGravity; // On réinitialise la gravité
		Application.LoadLevel(UtilsScript.SceneLevelLost);
	}
	
	/// <summary>
	/// Méthode à appeler quand le level est réussi
	/// </summary>
	public void LevelSolved() {
		this.EndLevelTime = this.GameTime; // On enregistre le temps de jeu
		Physics.gravity = this.OriginalGravity; // On réinitialise la gravité
		Application.LoadLevel(UtilsScript.SceneLevelPlayerName);
	}
	
	// Permet de sauvegarder le score, le temps et le nom du joueur dans les PlayerPrefs
	public void SaveScoreTimeAndPlayerName() {
		int[] bestScores = new int[3]; // Contiendra les 3 meilleurs score actuels
		string[] bestScoresNames = new string[3]; // Contiendra les 3 noms des personnes qui ont réalisés les meilleurs score actuels
		float[] bestTimes = new float[3]; // Contiendra les 3 meilleurs temps actuels
		string[] bestTimesNames = new string[3]; // Contiendra les 3 noms des personnes qui ont réalisés les meilleurs temps actuels
		
		// Le score, le temps et le nom du joueur effectué la dernière fois
		int currentScore = this.Score;
		float currentGameTime = this.GameTime;
		string currentPlayerName = this.PlayerName;
		
		// On récupère les meilleurs scores et temps
		bestScores[0] = PlayerPrefs.GetInt(string.Concat("BestScore",GameClasseScript.Instance.LastLevelName));
		bestScores[1] = PlayerPrefs.GetInt(string.Concat("SecondBestScore",GameClasseScript.Instance.LastLevelName));
		bestScores[2] = PlayerPrefs.GetInt(string.Concat("ThirdBestScore",GameClasseScript.Instance.LastLevelName));
		bestScoresNames[0] = PlayerPrefs.GetString(string.Concat("BestScoreName",GameClasseScript.Instance.LastLevelName));
		bestScoresNames[1] = PlayerPrefs.GetString(string.Concat("SecondBestScoreName",GameClasseScript.Instance.LastLevelName));
		bestScoresNames[2] = PlayerPrefs.GetString(string.Concat("ThirdBestScoreName",GameClasseScript.Instance.LastLevelName));
		
		bestTimes[0] = PlayerPrefs.GetFloat(string.Concat("BestTime",GameClasseScript.Instance.LastLevelName));
		bestTimes[1] = PlayerPrefs.GetFloat(string.Concat("SecondBestTime",GameClasseScript.Instance.LastLevelName));
		bestTimes[2] = PlayerPrefs.GetFloat(string.Concat("ThirdBestTime",GameClasseScript.Instance.LastLevelName));
		bestTimesNames[0] = PlayerPrefs.GetString(string.Concat("BestTimeName",GameClasseScript.Instance.LastLevelName));
		bestTimesNames[1] = PlayerPrefs.GetString(string.Concat("SecondBestTimeName",GameClasseScript.Instance.LastLevelName));
		bestTimesNames[2] = PlayerPrefs.GetString(string.Concat("ThirdBestTimeName",GameClasseScript.Instance.LastLevelName));
		
		// Si le score actuel est meilleur que l'un des 3 meilleurs actuels, on remplace
		if(!PlayerPrefs.HasKey(string.Concat("BestScore",GameClasseScript.Instance.LastLevelName)) || currentScore >= bestScores[0]) {
			// S'il est meilleur que le premier, on décale le 2e et le 1er et on le place à la première place
			// On ne décale que s'il y a une valeur à décaler
			// S'il n'y a pas encore de second meilleur score, on ne le décale pas sur le 3e score
			if(PlayerPrefs.HasKey(string.Concat("SecondBestScore",GameClasseScript.Instance.LastLevelName))) {
				PlayerPrefs.SetInt(string.Concat("ThirdBestScore",GameClasseScript.Instance.LastLevelName), bestScores[1]);
				PlayerPrefs.SetString(string.Concat("ThirdBestScoreName",GameClasseScript.Instance.LastLevelName), bestScoresNames[1]);
			}
			// S'il n'y a pas encore de meilleur score, on ne le décale pas sur le 2e score
			if(PlayerPrefs.HasKey(string.Concat("BestScore",GameClasseScript.Instance.LastLevelName))) {
				PlayerPrefs.SetInt(string.Concat("SecondBestScore",GameClasseScript.Instance.LastLevelName), bestScores[0]);
				PlayerPrefs.SetString(string.Concat("SecondBestScoreName",GameClasseScript.Instance.LastLevelName), bestScoresNames[0]);
			}
			PlayerPrefs.SetInt(string.Concat("BestScore",GameClasseScript.Instance.LastLevelName), currentScore);
			PlayerPrefs.SetString(string.Concat("BestScoreName",GameClasseScript.Instance.LastLevelName), currentPlayerName);
		} else if(!PlayerPrefs.HasKey(string.Concat("SecondBestScore",GameClasseScript.Instance.LastLevelName)) || currentScore >= bestScores[1]) {
			// S'il est meilleur que le second, on décale le 2e et on le place à la 2e place
			if(PlayerPrefs.HasKey(string.Concat("SecondBestScore",GameClasseScript.Instance.LastLevelName))) {
				PlayerPrefs.SetInt(string.Concat("ThirdBestScore",GameClasseScript.Instance.LastLevelName), bestScores[1]);
				PlayerPrefs.SetString(string.Concat("ThirdBestScoreName",GameClasseScript.Instance.LastLevelName), bestScoresNames[1]);
			}
			PlayerPrefs.SetInt(string.Concat("SecondBestScore",GameClasseScript.Instance.LastLevelName), currentScore);
			PlayerPrefs.SetString(string.Concat("SecondBestScoreName",GameClasseScript.Instance.LastLevelName), currentPlayerName);
		} else if(!PlayerPrefs.HasKey(string.Concat("ThirdBestScore",GameClasseScript.Instance.LastLevelName)) || currentScore >= bestScores[2]) {
			// S'il est meilleur que le 3e, on le place à la 3e place
			PlayerPrefs.SetInt(string.Concat("ThirdBestScore",GameClasseScript.Instance.LastLevelName), currentScore);
			PlayerPrefs.SetString(string.Concat("ThirdBestScoreName",GameClasseScript.Instance.LastLevelName), currentPlayerName);
		}
		
		// Pareil pour le temps
		if(!PlayerPrefs.HasKey(string.Concat("BestTime",GameClasseScript.Instance.LastLevelName)) || currentGameTime <= bestTimes[0]) {
			if(PlayerPrefs.HasKey(string.Concat("SecondBestTime",GameClasseScript.Instance.LastLevelName))) {
				PlayerPrefs.SetFloat(string.Concat("ThirdBestTime",GameClasseScript.Instance.LastLevelName), bestTimes[1]);
				PlayerPrefs.SetString(string.Concat("ThirdBestTimeName",GameClasseScript.Instance.LastLevelName), bestTimesNames[1]);
			}
			if(PlayerPrefs.HasKey(string.Concat("BestTime",GameClasseScript.Instance.LastLevelName))) {
				PlayerPrefs.SetFloat(string.Concat("SecondBestTime",GameClasseScript.Instance.LastLevelName), bestTimes[0]);
				PlayerPrefs.SetString(string.Concat("SecondBestTimeName",GameClasseScript.Instance.LastLevelName), bestTimesNames[0]);
			}
			PlayerPrefs.SetFloat(string.Concat("BestTime",GameClasseScript.Instance.LastLevelName), currentGameTime);
			PlayerPrefs.SetString(string.Concat("BestTimeName",GameClasseScript.Instance.LastLevelName), currentPlayerName);
		} else if(!PlayerPrefs.HasKey(string.Concat("SecondBestTime",GameClasseScript.Instance.LastLevelName)) || currentGameTime <= bestTimes[1]) {
			if(PlayerPrefs.HasKey(string.Concat("SecondBestTime",GameClasseScript.Instance.LastLevelName))) {
				PlayerPrefs.SetFloat(string.Concat("ThirdBestTime",GameClasseScript.Instance.LastLevelName), bestTimes[1]);
				PlayerPrefs.SetString(string.Concat("ThirdBestTimeName",GameClasseScript.Instance.LastLevelName), bestTimesNames[1]);
			}
			PlayerPrefs.SetFloat(string.Concat("SecondBestTime",GameClasseScript.Instance.LastLevelName), currentGameTime);
			PlayerPrefs.SetString(string.Concat("SecondBestTimeName",GameClasseScript.Instance.LastLevelName), currentPlayerName);
		} else if(!PlayerPrefs.HasKey(string.Concat("ThirdBestTime",GameClasseScript.Instance.LastLevelName)) || currentGameTime <= bestTimes[2]) {
			PlayerPrefs.SetFloat(string.Concat("ThirdBestTime",GameClasseScript.Instance.LastLevelName), currentGameTime);
			PlayerPrefs.SetString(string.Concat("ThirdBestTimeName",GameClasseScript.Instance.LastLevelName), currentPlayerName);
		}
	}
	#endregion
}
