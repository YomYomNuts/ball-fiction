using UnityEngine;

/// <summary>
/// Script gérant l'affichage du temps
/// </summary>
public class DisplayTimeScript :MonoBehaviour {
	void Update() {
		TextMesh theText = this.GetComponent<TextMesh>();
		if(theText != null) {
			theText.text = GameClasse.Instance.FormatedGameTime;
		}
	}
}
