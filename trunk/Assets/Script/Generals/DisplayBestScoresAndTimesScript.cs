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
			this._bestScore1.GetComponent<TextMesh>().text = UtilsScript.FormatScore(PlayerPrefs.GetInt(string.Concat("BestScore",GameClasseScript.Instance.CurrentLevelName)));
		}
		
		if(this._bestScore2 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("second best score", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestScore2.GetComponent<TextMesh>().text = UtilsScript.FormatScore(PlayerPrefs.GetInt(string.Concat("SecondBestScore",GameClasseScript.Instance.CurrentLevelName)));
		}
		
		if(this._bestScore3 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("third best score", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestScore3.GetComponent<TextMesh>().text = UtilsScript.FormatScore(PlayerPrefs.GetInt(string.Concat("ThirdBestScore",GameClasseScript.Instance.CurrentLevelName)));
		}
		
		// Affichage des meilleurs temps
		if(this._bestTime1 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("best time", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestTime1.GetComponent<TextMesh>().text = UtilsScript.FormatTime(PlayerPrefs.GetFloat(string.Concat("BestTime",GameClasseScript.Instance.CurrentLevelName)));
		}
		
		if(this._bestTime2 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("second best time", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestTime2.GetComponent<TextMesh>().text = UtilsScript.FormatTime(PlayerPrefs.GetFloat(string.Concat("SecondBestTime",GameClasseScript.Instance.CurrentLevelName)));
		}
		
		if(this._bestTime3 == null) {
			UtilsScript.WarningMessageWhenNoGameObjectAssigned("third best time", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestTime3.GetComponent<TextMesh>().text = UtilsScript.FormatTime(PlayerPrefs.GetFloat(string.Concat("ThirdBestTime",GameClasseScript.Instance.CurrentLevelName)));
		}
	}
	#endregion
}
