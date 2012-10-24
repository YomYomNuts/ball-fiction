using UnityEngine;

/// <summary>
/// Script gérant l'affichage du score
/// </summary>
public class DisplayScoreScript : MonoBehaviour {
	// Instance de la classe
    private static DisplayScoreScript _instance;
	
	/// <summary>
	/// Propriété pour accéder publiquement à l'instance de la classe
	/// </summary>
    public static DisplayScoreScript Instance {
        get {
			// Si l'instance n'existe pas, on la crée
            if (DisplayScoreScript._instance == null) {
                DisplayScoreScript._instance = new DisplayScoreScript();
			}
            return DisplayScoreScript._instance;
        }
    }
	
	// Constructeur privé pour être sûr qu'il n'y ait qu'une seule instance
    private DisplayScoreScript() {}
	
	// Le texte pour afficher le score
    private TextMesh _textMesh;

	void Awake () {
		// Unity créera l'objet même si le constructeur est privé donc on doit initialiser l'instance de notre singleton ici
        if (DisplayScoreScript._instance == null) {
            DisplayScoreScript._instance = this;
        } else if (DisplayScoreScript._instance != this) {
            Destroy(this.gameObject);
        }
		// On récupère le textMesh associé
        this._textMesh = this.GetComponent<TextMesh>();
        if (this._textMesh == null) {
            Destroy(this.gameObject);
		}
        this.DisplayScore();
	}
	
	public void DisplayScore() {
        if (this._textMesh != null) {
            this._textMesh.text = GameClasse.Instance.FormatedScore;
		}
	}

}
