using UnityEngine;

/// <summary>
/// Script gérant l'affichage du score
/// </summary>
public class DisplayScoreScript :MonoBehaviour {
	void Update() {
		TextMesh theText = this.GetComponent<TextMesh>();
		if(theText != null) {
			theText.text = GameClasse.Instance.FormatedScore;
		}
	}
}
