using UnityEngine;

/// <summary>
/// Script gérant l'affichage du score et du temps
/// </summary>
public class DisplayScoreAndTime {
	private static DisplayScoreAndTime _instance;
	
	public static DisplayScoreAndTime Instance {
		get {
			if(DisplayScoreAndTime._instance == null) {
				DisplayScoreAndTime._instance = new DisplayScoreAndTime();
			}
			return DisplayScoreAndTime._instance;
		}
	}
	
	private DisplayScoreAndTime() {}
	
	private GameObject _scoreText;
	private GameObject _timeText;
	
	private GameObject ScoreText {
		get {
			if(this._scoreText == null) {
				this._scoreText = GameObject.Find("ScoreText");
			}
			return this._scoreText;
		}
	}
	
	private GameObject TimeText {
		get {
			if(this._timeText == null) {
				this._timeText = GameObject.Find("TimeText");
			}
			return this._timeText;
		}
	}
	
	public void DisplayScore() {
		this.ScoreText.GetComponent<TextMesh>().text = GameClasse.Instance.FormatedScore;
	}
	public void DisplayTime() {
		this.TimeText.GetComponent<TextMesh>().text = GameClasse.Instance.FormatedGameTime;
	}
}
