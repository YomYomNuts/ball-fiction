using UnityEngine;

/// <summary>
/// Script gérant l'affichage des scores et temps dans le menu de levelSolved
/// </summary>
public class DisplayBestScoresAndTimesScript : MonoBehaviour {
	#region Attributes
	/// <summary>
	/// L'emplacement où afficher le meilleur score
	/// </summary>
	public GameObject _bestScore1;
	/// <summary>
	/// L'emplacement où afficher le second meilleur score
	/// </summary>
	public GameObject _bestScore2;
	/// <summary>
	/// L'emplacement où afficher le troisième meilleur score
	/// </summary>
	public GameObject _bestScore3;
	/// <summary>
	/// L'emplacement où afficher le nom du joueur qui a fait meilleur score
	/// </summary>
	public GameObject _bestScoreName1;
	/// <summary>
	/// L'emplacement où afficher le nom du joueur qui a fait second meilleur score
	/// </summary>
	public GameObject _bestScoreName2;
	/// <summary>
	/// L'emplacement où afficher le nom du joueur qui a fait troisième meilleur score
	/// </summary>
	public GameObject _bestScoreName3;
	
	/// <summary>
	/// L'emplacement où afficher le meilleur temps
	/// </summary>
	public GameObject _bestTime1;
	/// <summary>
	/// L'emplacement où afficher le second meilleur temps
	/// </summary>
	public GameObject _bestTime2;
	/// <summary>
	/// L'emplacement où afficher le troisième meilleur temps
	/// </summary>
	public GameObject _bestTime3;
	/// <summary>
	/// L'emplacement où afficher le nom du joueur qui a fait meilleur temps
	/// </summary>
	public GameObject _bestTimeName1;
	/// <summary>
	/// L'emplacement où afficher le nom du joueur qui a fait second meilleur temps
	/// </summary>
	public GameObject _bestTimeName2;
	/// <summary>
	/// L'emplacement où afficher le nom du joueur qui a fait troisième meilleur temps
	/// </summary>
	public GameObject _bestTimeName3;
	#endregion
	
	#region Unity Methods
	// Use this for initialization
	void Start() {
		// Affichage du score et du temps actuels
		DisplayScoreScript.Instance.DisplayScore();
		DisplayTimeScript.Instance.DisplayTime();
		
		// Affichage des meilleurs score
		if(this._bestScore1 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("best score", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestScore1.GetComponent<TextMesh>().text = UtilsScript.FormatScore(PlayerPrefs.GetInt(string.Concat("BestScore",GameClasseScript.Instance.LastLevelName)));
		}
		if(this._bestScore2 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("second best score", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestScore2.GetComponent<TextMesh>().text = UtilsScript.FormatScore(PlayerPrefs.GetInt(string.Concat("SecondBestScore",GameClasseScript.Instance.LastLevelName)));
		}
		if(this._bestScore3 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("third best score", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestScore3.GetComponent<TextMesh>().text = UtilsScript.FormatScore(PlayerPrefs.GetInt(string.Concat("ThirdBestScore",GameClasseScript.Instance.LastLevelName)));
		}
		
		if(this._bestScoreName1 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("best score name", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestScoreName1.GetComponent<TextMesh>().text = PlayerPrefs.GetString(string.Concat("BestScoreName",GameClasseScript.Instance.LastLevelName));
		}
		if(this._bestScoreName2 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("second best score name", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestScoreName2.GetComponent<TextMesh>().text = PlayerPrefs.GetString(string.Concat("SecondBestScoreName",GameClasseScript.Instance.LastLevelName));
		}
		if(this._bestScoreName3 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("third best score name", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestScoreName3.GetComponent<TextMesh>().text = PlayerPrefs.GetString(string.Concat("ThirdBestScoreName",GameClasseScript.Instance.LastLevelName));
		}
		
		// Affichage des meilleurs temps
		if(this._bestTime1 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("best time", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestTime1.GetComponent<TextMesh>().text = UtilsScript.FormatTime(PlayerPrefs.GetFloat(string.Concat("BestTime",GameClasseScript.Instance.LastLevelName)));
		}
		if(this._bestTime2 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("second best time", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestTime2.GetComponent<TextMesh>().text = UtilsScript.FormatTime(PlayerPrefs.GetFloat(string.Concat("SecondBestTime",GameClasseScript.Instance.LastLevelName)));
		}
		if(this._bestTime3 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("third best time", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestTime3.GetComponent<TextMesh>().text = UtilsScript.FormatTime(PlayerPrefs.GetFloat(string.Concat("ThirdBestTime",GameClasseScript.Instance.LastLevelName)));
		}
		
		if(this._bestTimeName1 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("best time name", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestTimeName1.GetComponent<TextMesh>().text = PlayerPrefs.GetString(string.Concat("BestTimeName",GameClasseScript.Instance.LastLevelName));
		}
		if(this._bestTimeName2 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("second best time name", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestTimeName2.GetComponent<TextMesh>().text = PlayerPrefs.GetString(string.Concat("SecondBestTimeName",GameClasseScript.Instance.LastLevelName));
		}
		if(this._bestTimeName3 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("third best time name", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestTimeName3.GetComponent<TextMesh>().text = PlayerPrefs.GetString(string.Concat("ThirdBestTimeName",GameClasseScript.Instance.LastLevelName));
		}
	}
	#endregion
}
