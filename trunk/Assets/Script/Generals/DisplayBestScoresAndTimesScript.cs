using UnityEngine;

/// <summary>
/// Script gérant l'affichage des meilleurs scores et temps
/// </summary>
public class DisplayBestScoresAndTimesScript : MonoBehaviour {
	
	private GameObject _bestScore1;
	private GameObject _bestScore2;
	private GameObject _bestScore3;
	
	private GameObject _bestTime1;
	private GameObject _bestTime2;
	private GameObject _bestTime3;
	
	private GameObject BestScore1 {
		get {
			if(this._bestScore1 == null) {
				this._bestScore1 = GameObject.Find("BestScore1");
			}
			return this._bestScore1;
		}
	}
	private GameObject BestScore2 {
		get {
			if(this._bestScore2 == null) {
				this._bestScore2 = GameObject.Find("BestScore2");
			}
			return this._bestScore2;
		}
	}
	private GameObject BestScore3 {
		get {
			if(this._bestScore3 == null) {
				this._bestScore3 = GameObject.Find("BestScore3");
			}
			return this._bestScore3;
		}
	}
	
	private GameObject BestTime1 {
		get {
			if(this._bestTime1 == null) {
				this._bestTime1 = GameObject.Find("BestTime1");
			}
			return this._bestTime1;
		}
	}
	private GameObject BestTime2 {
		get {
			if(this._bestTime2 == null) {
				this._bestTime2 = GameObject.Find("BestTime2");
			}
			return this._bestTime2;
		}
	}
	private GameObject BestTime3 {
		get {
			if(this._bestTime3 == null) {
				this._bestTime3 = GameObject.Find("BestTime3");
			}
			return this._bestTime3;
		}
	}
	
	void Start() {
		this.BestScore1.GetComponent<TextMesh>().text = Utils.FormatScore(PlayerPrefs.GetInt(string.Concat("BestScore",GameClasse.Instance.CurrentLevelName)));
		this.BestScore2.GetComponent<TextMesh>().text = Utils.FormatScore(PlayerPrefs.GetInt(string.Concat("SecondBestScore",GameClasse.Instance.CurrentLevelName)));
		this.BestScore3.GetComponent<TextMesh>().text = Utils.FormatScore(PlayerPrefs.GetInt(string.Concat("ThirdBestScore",GameClasse.Instance.CurrentLevelName)));
		
		this.BestTime1.GetComponent<TextMesh>().text = Utils.FormatTime(PlayerPrefs.GetFloat(string.Concat("BestTime",GameClasse.Instance.CurrentLevelName)));
		this.BestTime2.GetComponent<TextMesh>().text = Utils.FormatTime(PlayerPrefs.GetFloat(string.Concat("SecondBestTime",GameClasse.Instance.CurrentLevelName)));
		this.BestTime3.GetComponent<TextMesh>().text = Utils.FormatTime(PlayerPrefs.GetFloat(string.Concat("ThirdBestTime",GameClasse.Instance.CurrentLevelName)));
	}
}
