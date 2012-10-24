using UnityEngine;

/// <summary>
/// Script gérant l'affichage des scores et temps dans le menu de levelSolved
/// </summary>
public class DisplayBestScoresAndTimesScript : MonoBehaviour {
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
	
	void Start() {
		// Affichage du score et du temps actuels
		DisplayScoreScript.Instance.DisplayScore();
		DisplayTimeScript.Instance.DisplayTime();
		
		// Affichage des meilleurs score
		if(this._bestScore1 == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("best score", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestScore1.GetComponent<TextMesh>().text = Utils.FormatScore(PlayerPrefs.GetInt(string.Concat("BestScore",GameClasse.Instance.CurrentLevelName)));
		}
		
		if(this._bestScore2 == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("second best score", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestScore2.GetComponent<TextMesh>().text = Utils.FormatScore(PlayerPrefs.GetInt(string.Concat("SecondBestScore",GameClasse.Instance.CurrentLevelName)));
		}
		
		if(this._bestScore3 == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("third best score", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestScore3.GetComponent<TextMesh>().text = Utils.FormatScore(PlayerPrefs.GetInt(string.Concat("ThirdBestScore",GameClasse.Instance.CurrentLevelName)));
		}
		
		// Affichage des meilleurs temps
		if(this._bestTime1 == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("best time", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestTime1.GetComponent<TextMesh>().text = Utils.FormatTime(PlayerPrefs.GetFloat(string.Concat("BestTime",GameClasse.Instance.CurrentLevelName)));
		}
		
		if(this._bestTime2 == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("second best time", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestTime2.GetComponent<TextMesh>().text = Utils.FormatTime(PlayerPrefs.GetFloat(string.Concat("SecondBestTime",GameClasse.Instance.CurrentLevelName)));
		}
		
		if(this._bestTime3 == null) {
			Utils.WarningMessageWhenNoGameObjectAssigned("third best time", this.GetType().ToString(), this.gameObject.name);
		} else {
			this._bestTime3.GetComponent<TextMesh>().text = Utils.FormatTime(PlayerPrefs.GetFloat(string.Concat("ThirdBestTime",GameClasse.Instance.CurrentLevelName)));
		}
	}
}
